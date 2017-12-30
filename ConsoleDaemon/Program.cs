using System;
using ConsoleDaemon.classes;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ConsoleDaemon
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessTimer pc = new ProcessTimer(10000);
            pc.OnClkProcess +=  Pc_OnClkProcessAsync;
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static async Task Pc_OnClkProcessAsync()
        {
            Console.WriteLine("Event!");
            WeatherData data = new WeatherData
            {
                Temperature = 14,
                Pressure = 23
            };
            var client = new HttpClient();
            //client.BaseAddress = new Uri("http://192.168.0.105/WebMonitor");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string weather=JsonConvert.SerializeObject(data);
            HttpResponseMessage response=await client.PostAsync("http://192.168.0.105:5001/Home/AddWeatherData", new StringContent(weather));
            Console.WriteLine(response.StatusCode.ToString());
        }
    }
}
