using System;
using System.Net.Http;

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
        }
    }
}
