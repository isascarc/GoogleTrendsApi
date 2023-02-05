﻿namespace GoogleTrends;

internal class TrendsGetData
{
    public Geo geo { get; set; }
    public string time { get; set; }
    public string resolution { get; set; }
    public string locale { get; set; }
    public List<ComparisonItem> comparisonItem { get; set; }
    public RequestOptions requestOptions { get; set; }
    public UserConfig userConfig { get; set; }
    public string lineAnnotationText { get; set; }
    public List<TrendsRespond.Bullet> bullets { get; set; }
    public bool showLegend { get; set; }
    public bool showAverages { get; set; }
    public string token { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string title { get; set; }
    public string template { get; set; }
    public string embedTemplate { get; set; }
    public string version { get; set; }
    public bool isLong { get; set; }
    public bool isCurated { get; set; }
    public string searchInterestLabel { get; set; }
    public string displayMode { get; set; }
    public string color { get; set; }
    public int? index { get; set; }
    public string bullet { get; set; }
    public string keywordName { get; set; }
    private string baseUrl = "https://trends.google.us/trends/api/widgetdata/";

    public TrendsGetData(TrendsRespond RespondSolicitud)
    {
        var req = RespondSolicitud.widgets[0].request;
        this.time = req.time;
        this.resolution = req.resolution;
        this.locale = req.locale;
        this.comparisonItem = new List<ComparisonItem>();

        // Add all expressions to list.
        foreach (var item in req.comparisonItem)
        {
            ComparisonItem comparisonItem = new ComparisonItem();
            Geo mygeo = new Geo();
            mygeo.country = item.geo.country;
            comparisonItem.geo = mygeo;
            comparisonItem.complexKeywordsRestriction = new ComplexKeywordsRestriction();
            comparisonItem.complexKeywordsRestriction.keyword = new List<Keyword>();
            Keyword keyword = new Keyword();
            keyword.value = item.complexKeywordsRestriction.keyword[0].value;
            keyword.type = item.complexKeywordsRestriction.keyword[0].type;
            comparisonItem.complexKeywordsRestriction.keyword.Add(keyword);
            this.comparisonItem.Add(comparisonItem);
        }

        this.requestOptions = new TrendsGetData.RequestOptions();
        this.requestOptions.property = req.requestOptions.property;
        this.requestOptions.backend = req.requestOptions.backend;
        this.userConfig = new TrendsGetData.UserConfig();
        this.userConfig.userType = req.userConfig.userType;
        this.token = RespondSolicitud.widgets[0].token;
    }

    public async Task<string> getTrendsJsonResponseAsync()
    {
        Uri dataUri = new Uri($"{baseUrl}multiline/json?req={JsonConvert.SerializeObject(this)}&token={this.token}&tz=300");
        return await new TrendsUtility().GetData(dataUri);
    }


    public class ComparisonItem
    {
        public Geo geo { get; set; }
        public string time { get; set; }
        public ComplexKeywordsRestriction complexKeywordsRestriction { get; set; }
        public string keyword { get; set; }
    }

    public class ComplexKeywordsRestriction
    {
        public List<Keyword> keyword { get; set; }
    }

    public class Geo
    {
        public string country { get; set; }
    }

    public class Keyword
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class RequestOptions
    {
        public string property { get; set; }
        public string backend { get; set; }
        public int category { get; set; }
    }

    public class UserConfig
    {
        public string userType { get; set; }
    }
}