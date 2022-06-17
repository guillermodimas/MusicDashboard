using MusicDashboard.Models.ITunesAPI;

namespace MusicDashboard.Services
{
    public interface InterfaceItunesAPIService
    {
        Task<ItunesMusicResultsModel> GetItunesMusicResult(string searchBy);
    }
}