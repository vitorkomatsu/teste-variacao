using AutoMapper;
using Teste.Variacao.Application.DTOs.Request;
using Teste.Variacao.Application.DTOs.Response;
using Teste.Variacao.Application.Extensions;
using Teste.Variacao.Domain.Entities;

namespace Teste.Variacao.Application.Mappings
{
    public class VariacaoAtivoMapProfile : Profile
    {
        public VariacaoAtivoMapProfile()
        {
            //Request
            CreateMap<VariacaoAtivoRequest, VariacaoAtivo>().ReverseMap();
       
            //Response
            CreateMap<VariacaoAtivoResponse, VariacaoAtivo>()
                .ReverseMap();

            CreateMap(typeof(PaginatedResult<>), typeof(PaginatedResult<>));
            CreateMap(typeof(Result<>), typeof(Result<>));
        }
    }
}