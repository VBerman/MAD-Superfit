using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MAD_Superfit
{
    class ApiWorker
    {
        public const string Server = "https://fitness.wsmob.xyz/";
        public async static Task<bool> Auth(UserInfo user)
        {
            var data = new Dictionary<string, string>();
            data.Add("login", user.Email);
            data.Add("password", user.Password);
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"); 

            
            var resultRequest = await App.http.PostAsync($"{Server}api/auth/token", content);
            return resultRequest.IsSuccessStatusCode;

        }

        public async static Task<bool> Registration(UserInfo user)
        {
            var data = new Dictionary<string, string>();
            data.Add("login", user.Email);
            data.Add("password", user.Password);
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var resultRequest = await App.http.PostAsync($"{Server}api/auth/register", content);
            return resultRequest.IsSuccessStatusCode;
        }
       // public async 
    }
}
