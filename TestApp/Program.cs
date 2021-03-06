using Models;
using Newtonsoft.Json;
using Services.ViewModels;
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
        static async Task Main(string[] args)
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
            

            //Login request test
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
            

            // REQUESTS TESTS

            // GET all regions

            string regionUrl = "https://localhost:5001/api/Region";

            clientLogin.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", resultLogin);

            HttpResponseMessage resultRegion = await clientLogin.GetAsync(regionUrl);

            string regions = await resultRegion.Content.ReadAsStringAsync();
           
            var regionJsonResult = JsonConvert.DeserializeObject(regions);

            Console.WriteLine(regionJsonResult);

            // GET all countries

            string countryUrl = "https://localhost:5001/api/CountryConroller/countries";

            HttpResponseMessage counriesResult = await cl.GetAsync(countryUrl);

            string countries = await counriesResult.Content.ReadAsStringAsync();

            var countryJson = JsonConvert.DeserializeObject(countries);

            Console.WriteLine(countryJson);
             */
        }
    }
   
}