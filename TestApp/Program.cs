using Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Register request test
            
            string registerUrl = "https://localhost:5001/api/Identity";

            var user = new UserViewModel()
            {
                UserName = "Tester",
                Password = "Testing_1234567",
                ConfirmPassword = "Testing_1234567",
            };

            var json = JsonConvert.SerializeObject(user);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(registerUrl, data);

            string res = response.Content.ReadAsStringAsync().Result;
            */

            /* Login request test

            string loginUrl = "https://localhost:5001/api/Identity/login";

            var userLogin = new UserViewModel()
            {
                UserName = "Tester",
                Password = "Testing_1234567",
            };

            var jsonLogin = JsonConvert.SerializeObject(userLogin);

            var dataLogin = new StringContent(jsonLogin, Encoding.UTF8, "application/json");

            using var clientLogin = new HttpClient();

            var responseLogin = await clientLogin.PostAsync(loginUrl, dataLogin);

            string resultLogin = responseLogin.Content.ReadAsStringAsync().Result;
            */

            /* Custom requests test

            string regionUrl = "https://localhost:5001/api/Region";

            clientLogin.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", resultLogin);

            HttpResponseMessage resultRegion = await clientLogin.GetAsync(regionUrl);

            string regions = await resultRegion.Content.ReadAsStringAsync();
            */
        }
    }
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PasswordHash { get; set; }
    }
}