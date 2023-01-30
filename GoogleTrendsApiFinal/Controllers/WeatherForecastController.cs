using DemoGoogleTrends;
using Microsoft.AspNetCore.Mvc;

namespace GoogleTrendsApiFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WController : ControllerBase
    {
        [HttpGet(Name = "GetTrends")]
        public async Task<TrendsJsonResponse> Get()
        {
            //var ins = new DemoGoogleTrends.Ap();

            //var query = new Query("react", "IL", ins.LastMonth);
            ////query.AddItem("angular", "IL", "today 1-m");

            //return await ins.FetchData(query);


            var ins = new DemoGoogleTrends.Api();
            return await ins.FetchDataByOneQuery("react", "IL", ins.LastMonth);
        }
    }
}