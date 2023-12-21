using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ProjetoConsultarClimaC_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const string API_KEY = "";

            while (true)
            {
                Console.Write("Digite o nome da cidade: ");
                string city_name = Console.ReadLine();

                string link = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={API_KEY}";

                HttpClient httpClient = new HttpClient();

                var response = await httpClient.GetAsync(link);

                var content = await response.Content.ReadAsStringAsync();

                var tempInfo = JsonConvert.DeserializeObject<ApiResponse>(content);

                Console.WriteLine();

                await Console.Out.WriteLineAsync($"Nome da cidade: {tempInfo.Name}");
                await Console.Out.WriteLineAsync($"Temperatura atual: {Convert.ToInt32(tempInfo.Main.Temp - 273)}C°");
                await Console.Out.WriteLineAsync($"Sensação térmica: {Convert.ToInt32(tempInfo.Main.Feels_like - 273)}C°");
                await Console.Out.WriteLineAsync($"Velocidade do vento: {(tempInfo.Wind.Speed * (decimal)3.6).ToString("F")}Km/h");
                await Console.Out.WriteLineAsync($"Umidade: {tempInfo.Main.Humidity}%");

                Console.WriteLine();

                await Console.Out.WriteAsync("Deseja fazer outra consulta ? [S/N] ");
                string resposta = Console.ReadLine().ToUpper();

                Console.WriteLine();

                if ( resposta == "N")
                {
                    break;
                }

            }
        }
    }
}
