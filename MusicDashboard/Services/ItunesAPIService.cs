using MusicDashboard.Models.ITunesAPI;

namespace MusicDashboard.Services
{
    public class ItunesAPIService : InterfaceItunesAPIService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ItunesAPIService> _logger;
        public ItunesAPIService(HttpClient httpClient, ILogger<ItunesAPIService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ItunesMusicResultsModel> GetItunesMusicResult(string searchBy)
        {
            try
            {
                var response = await _httpClient.GetAsync($"search?term={searchBy}");
                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ItunesMusicResultsModel);
                    }    
                    
                    return await response.Content.ReadFromJsonAsync<ItunesMusicResultsModel>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
           
        }

    }
}
