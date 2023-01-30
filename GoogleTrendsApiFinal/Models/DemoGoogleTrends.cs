using System.Collections.Generic;

namespace DemoGoogleTrends
{
    public class Api
    {
        public readonly string LastHour = "now 1-H";
        public readonly string LastDay = "now 1-d";
        public readonly string LastWeek = "now 7-d";
        public readonly string LastMonth = "today 1-m";

        public async Task<TrendsJsonResponse> FetchDataByOneQuery(string keyword, string geo, string time)
        {
            return await FetchData(new Query(keyword, geo, time));
        }

        public async Task<TrendsJsonResponse> FetchData(Query query)
        {
            var RespondSolicitud = await new TrendsUtility().getTrendsRespondSolicitud(query);
            var ret = new TrendsGetDataGrafica(RespondSolicitud);
            //var ee = await ret.getTrendsJsonResponseAsync();
            return await ret.getTrendsJsonResponseAsync();
        }


        //public Query CreateQuery(string text, string geo = "IL")
        //{
        //    return new Query(text, geo, "today 1-m");
        //}


        //public TrendsJsonResponse forApi(string text, string geo = "IL")
        //{
        //    Query solicitud = new Query(text, geo, "today 1-m");
        //    var RespondSolicitud = new TrendsUtility().getTrendsRespondSolicitud(solicitud);
        //    return new TrendsGetDataGrafica(RespondSolicitud).getTrendsJsonResponseAsync();
        //}
    }
}