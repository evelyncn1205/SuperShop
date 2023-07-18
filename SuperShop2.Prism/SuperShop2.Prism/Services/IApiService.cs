using SuperShop2.Prism.Models;
using System.Threading.Tasks;

namespace SuperShop2.Prism.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}