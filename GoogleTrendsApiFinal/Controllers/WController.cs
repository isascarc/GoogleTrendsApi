using GoogleTrends;
using Microsoft.AspNetCore.Mvc;

namespace GoogleTrendsApiFinal.Controllers;

[ApiController]
[Route("[controller]")]
public class WController : ControllerBase
{        
    public async Task<string> Get()
    {
        var client = new GoogleTrends.Api();
        return await client.FetchDataAsync(new string[] { "angular", "react" });
    }
}