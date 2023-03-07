using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Variacao.Application.Commands.VariacaoAtivo;
using Teste.Variacao.Application.DTOs.Request;
using Teste.Variacao.Application.DTOs.Response;
using Teste.Variacao.Application.Exceptions;
using Teste.Variacao.Application.Extensions;
using Teste.Variacao.Application.Interfaces.Queries;
using Teste.Variacao.Application.Refit;
using Teste.Variacao.Domain.Repositories;

namespace Teste.Variacao.Application.Queries
{
    internal class VariacaoAtivoQueryService : IVariacaoAtivoQueryService
    {
        private readonly IVariacaoAtivoRepository _repository;
        private readonly IFinanceYahooRefitService _financeYahooRefitService;
        private readonly IMediator _mediator;

        public VariacaoAtivoQueryService(
            IVariacaoAtivoRepository repository,
            IFinanceYahooRefitService financeYahooRefitService,
            IMediator mediator)
        {
            _repository = repository;
            _financeYahooRefitService = financeYahooRefitService;
            _mediator = mediator;
        }

        public async Task<Result<VariacaoAtivoResponse>> GetByIdAsync(string name)
        {
            var variacaoAtivo = await _repository.GetQueryByNameAsync(name);
            if (variacaoAtivo is null)
            {
                try
                {
                    var resultFinance = await _financeYahooRefitService.GetFinanceYahooByNameAsync(name);
                    await InsertVariacaoAtivo(name, resultFinance);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro call Api Yahoo: {ex.Message}",ex);
                }
            }

            VariacaoAtivoResponse result = await GetValuesAsync(name);
            return Result<VariacaoAtivoResponse>.Success(result);
        }

        private async Task<VariacaoAtivoResponse> GetValuesAsync(string name)
        {
            var list = await _repository.Query()
                            .OrderBy(x => x.Data)
                            .ToListAsync();

            var opens = list.Select(p => p.Valor).ToList();
            var dates = list.Select(p => p.Data).ToList();
            var days = list.Select(p => p.Data.Day).ToList();
            var ids = list.Select(p => p.Id).ToList();

            var firstPrice = opens.FirstOrDefault();
            var firstDate = dates.FirstOrDefault();
            var firstVariation = 0.0;
            if (firstPrice != 0)
            {
                firstVariation = (opens[0] - firstPrice) / firstPrice;
            }

            var dailyVariations = new List<double>();
            for (int i = 1; i < opens.Count; i++)
            {
                var dailyVariation = (opens[i] - opens[i - 1]) / opens[i - 1];
                dailyVariations.Add(dailyVariation);
            }

            var result = new VariacaoAtivoResponse
            {
                Id = ids,
                Nome = name,
                Data = dates,
                Dia = days,
                VariacaoD1 = dailyVariations,
                VariacaoPData = firstVariation,
            };
            return result;
        }

        private async Task InsertVariacaoAtivo(string name, FinanceYahooResponse resultFinance)
        {
            var ativos = resultFinance.Chart.Result[0].Indicators.Quote[0].Open.TakeLast(30).ToList();
            var tempoAtivos = resultFinance.Chart.Result[0].Timestamp.TakeLast(30).ToList();

            var listVariacaoAtivo = new List<VariacaoAtivoRequest>();

            for (int i = 0; i < ativos.Count(); i++)
            {
                var date = DateTimeOffset.FromUnixTimeSeconds((long)tempoAtivos[i]).DateTime;
                var stockPrice = new VariacaoAtivoRequest
                {
                    Nome = name,
                    Data = date,
                    Dia = date.Day,
                    Valor = ativos[i]
                };

                listVariacaoAtivo.Add(stockPrice);
            }

            var requestCommand = new InsertVariacaoAtivoCommand(listVariacaoAtivo);
            var resultInsert = await _mediator.Send(requestCommand);

            if (resultInsert.Data == Guid.Empty)
                throw new ApiException($"Error insert VariacaoAtivo:{name}");
        }
    }
}