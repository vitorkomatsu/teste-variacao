using System.Collections.Generic;

namespace Teste.Variacao.Application.DTOs.Response
{
    public class FinanceYahooResponse
    {
        public Chart Chart { get; set; }
    }

    public class Chart
    {
        public List<Result> Result { get; set; }
        public object Error { get; set; }
    }

    public class CurrentTradingPeriod
    {
        public Pre Pre { get; set; }
        public Regular Regular { get; set; }
        public Post Post { get; set; }
    }

    public class Indicators
    {
        public List<Quote> Quote { get; set; }
    }

    public class Meta
    {
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string ExchangeName { get; set; }
        public string InstrumentType { get; set; }
        public int FirstTradeDate { get; set; }
        public int RegularMarketTime { get; set; }
        public int Gmtoffset { get; set; }
        public string Timezone { get; set; }
        public string ExchangeTimezoneName { get; set; }
        public double RegularMarketPrice { get; set; }
        public double ChartPreviousClose { get; set; }
        public double PreviousClose { get; set; }
        public int Scale { get; set; }
        public int PriceHint { get; set; }
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }
        public string DataGranularity { get; set; }
        public string Range { get; set; }
        public List<string> ValidRanges { get; set; }
    }

    public class Post
    {
        public string Timezone { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Gmtoffset { get; set; }
    }

    public class Pre
    {
        public string Timezone { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Gmtoffset { get; set; }
    }

    public class Quote
    {
        public List<double> High { get; set; }
        public List<double> Low { get; set; }
        public List<int> Volume { get; set; }
        public List<double> Close { get; set; }
        public List<double> Open { get; set; }
    }

    public class Regular
    {
        public string Timezone { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Gmtoffset { get; set; }
    }

    public class Result
    {
        public Meta Meta { get; set; }
        public List<int> Timestamp { get; set; }
        public Indicators Indicators { get; set; }
    }
}