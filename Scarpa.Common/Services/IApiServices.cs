using Scarpa.Common.Entities;
using Scarpa.Common.Requests;
using Scarpa.Common.Responses;
using System.Threading.Tasks;

namespace Scarpa.Common.Services
{
    public interface IApiServices
    {
        Task<Response<Usuarios>> GetUserByCelularAsync(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, UsrLogin usrLogin);
        Task<Response<asisChecada>> PostChecadaAsync(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, asisChecada checada);                
        Task<bool> CheckConnection(string url);
        Task<Response<TokenResponse>> GetTokenAsync(string urlBase,string servicePrefix,string controller, UsrLogin request);        
    }
}
