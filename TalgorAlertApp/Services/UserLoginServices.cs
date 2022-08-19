using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalgorAlertApp.Modles;

namespace TalgorAlertApp.Services
{
    internal class UserLoginServices
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public UserLoginServices()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<RegInfoResponseObj> AutenticateUser(User user)
        {
            Uri uri = new(string.Format(App.Url + "/User/UpdateuserToken", string.Empty));
            RegInfoResponseObj regInfoResponse = new RegInfoResponseObj();
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                var check = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    regInfoResponse.status = true;
                    regInfoResponse.message = response.Content.ReadAsStringAsync().Result;
                    regInfoResponse.code = ((int)response.StatusCode);
                }
                else
                {
                    regInfoResponse.status = false;
                    regInfoResponse.code = ((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                regInfoResponse.status = false;
                regInfoResponse.message = ex.Message;
                regInfoResponse.code = 500;
            }
            return regInfoResponse;
        }
    }
}

