namespace GoogleTrends;

class TrendsUtility
{
    public async Task<TrendsRespond> getTrendsRespondSolicitud(Query solicitud)
    {
        Uri url = new Uri($"https://trends.google.com/trends/api/explore?req={JsonConvert.SerializeObject(solicitud)}&hl=he-IL&tz=300");
        var Cookie = await GetCookie(url);
        var data = await GetData(url, Cookie);
        return data.Length > 0 ? JsonConvert.DeserializeObject<TrendsRespond>(data) : new TrendsRespond();
    }

    public async Task<CookieContainer> GetCookie(Uri url)
    {
        var cookieContainer = new CookieContainer();

        using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
        using (var client = new HttpClient(handler))
        {
            HttpRequestMessage request = new(HttpMethod.Post, url.OriginalString);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Host", url.Host);
            await client.SendAsync(request);
            return cookieContainer;
        }
    }

    public async Task<string> GetData(Uri url, CookieContainer cookies = null)
    {
        using (var handler = new HttpClientHandler() { CookieContainer = cookies ?? new CookieContainer() })
        using (var client = new HttpClient(handler) { })
        {
            var cc = url.OriginalString;
            HttpRequestMessage request = new(HttpMethod.Get, cc);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Host", url.Host);
            var a = await client.SendAsync(request);
            var b = await a.Content.ReadAsStringAsync();
            return b.Substring(5);
        }
    }
}