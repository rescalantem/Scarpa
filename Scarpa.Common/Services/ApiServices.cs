using Newtonsoft.Json;
using Plugin.Connectivity;
using Scarpa.Common.Requests;
using Scarpa.Common.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Scarpa.Common.Services
{
    public class ApiServices : IApiServices
    {
        public async Task<Response> GetUserByCelularAsync(string urlBase,string servicePrefix,string controller,string tokenType,string accessToken,UsrLogin usrLogin)
        {
            try
            {
                
                var requestString = JsonConvert.SerializeObject(usrLogin);
                var content = new StringContent(requestString, Encoding.UTF8, "application/json");
                var client = new HttpClient{BaseAddress = new Uri(urlBase)};

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                var url = $"{servicePrefix}{controller}";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) return new Response { IsSuccess = false, Message = result };                

                var owner = JsonConvert.DeserializeObject<Response>(result);
                return new Response { IsSuccess = true, Result = owner };
            }
            catch (Exception ex)
            {
                return new Response { IsSuccess = false, Message = ex.Message };
            }
        }
        public async Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, UsrLogin request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient {BaseAddress = new Uri(urlBase)};

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<bool> CheckConnection(string url)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return false;
            }
            return await CrossConnectivity.Current.IsRemoteReachable(url);
        }
        public async Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller)
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri(urlBase), };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                List<T> list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }
    }
}
