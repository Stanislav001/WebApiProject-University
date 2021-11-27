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
            /* string page = "https://localhost:5001/country";

             using (HttpClient client = new HttpClient())
             using (HttpRequestMessage response = client.GetAsync(page).Result)
             using (HttpContent content = response.Content)
             {
                 string result = content.ReadAsStringAsync().Result;

                 if (result != null && result.Length >= 50)
                 {
                     Console.WriteLine(result.Substring(0,50) + "....");
                 }
             }
            */

            HttpClient httpClient = new HttpClient();
            Task<HttpContent> auth = Task.Run(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));

                var content = JsonConvert.SerializeObject(new User() { UserName = "stanislav", Password = "Stanislav01!@@" });
                StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                return httpClient.PostAsync("https://localhost:5001/api/auth/login", stringContent).Result.Content;
            });

            Task<HttpContent> t = Task.Run(() =>
            {
                var token = auth.Result.ReadAsStringAsync().Result;
                httpClient.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue("Bearer", token);
                return httpClient.GetAsync("https://localhost:5001/api/Continents/countries_cost").Result.Content;

            });
        }
    }
}
