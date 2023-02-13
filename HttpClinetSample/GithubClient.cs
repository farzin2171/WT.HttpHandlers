using System.Diagnostics;

namespace HttpClinetSample
{
    public class GithubClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GithubClient> _logger;
     

        public GithubClient(HttpClient httpClient , ILogger<GithubClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;  
        }

        public async Task<string> GetHomePageAsync()
        {
            try
            {
              
                var ressponse = await _httpClient.GetAsync("https://github.com");
                return await ressponse.Content.ReadAsStringAsync();


            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }


    }
}
