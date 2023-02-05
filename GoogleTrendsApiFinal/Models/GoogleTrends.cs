namespace GoogleTrends;

public class Api
{
    public const string LastHour = "now 1-H";
    public const string LastDay = "now 1-d";
    public const string LastWeek = "now 7-d";
    public const string LastMonth = "today 1-m";
    public const string LastFiveYears = "today 5-y";

    public async Task<string> FetchDataAsync(string[] keyword, string geo = "", string time = LastFiveYears)
    {
        var RespondSolicitud = await new TrendsUtility().getTrendsRespondSolicitud(new Query(geo, time, keyword));
        var ret = new TrendsGetData(RespondSolicitud);
        return await ret.getTrendsJsonResponseAsync();
    }

    public string FetchData(string[] keyword, string geo = "", string time = LastFiveYears)
        => FetchDataAsync(keyword, geo, time).Result;
}