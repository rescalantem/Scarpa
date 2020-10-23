using Scarpa.Common.Requests;
using Scarpa.Common.Responses;
using System.Threading.Tasks;

namespace Scarpa.Common.Services
{
    public interface IApiServices
    {
        Task<Response> GetUserByCelularAsync(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, UsrLogin usrLogin);
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
        Task<bool> CheckConnection(string url);
        Task<Response> GetTokenAsync(string urlBase,string servicePrefix,string controller, UsrLogin request);        
    }
}
