using CadastroDevs.Dto;
using CadastroDevs.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CadastroDevs.Services
{
    public class DevService : IDevService
    {
        private readonly string _baseUrl;

        public DevService()
        {
            _baseUrl = "https://61a170e06c3b400017e69d00.mockapi.io";
        }

        public async Task<List<DevResponseDto>> ObterTodosDevs()
        {
             
            using (HttpClient httpClient = new HttpClient())
            {

                try
                {
                    string apiUrl = $"{_baseUrl}/DevTest/Dev";

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    response.EnsureSuccessStatusCode();

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var result = await JsonSerializer.DeserializeAsync<List<DevResponseDto>>(responseStream);
                        return result;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                    throw;
                }
            }
        }


        public async Task<DevResponseDto> ObterDevPorId(string id)
        {

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string apiUrl = $"{_baseUrl}/DevTest/Dev/{id}";

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    response.EnsureSuccessStatusCode();

                    using (Stream responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var result = await JsonSerializer.DeserializeAsync<DevResponseDto>(responseStream);
                        return result;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<string> CadastrarDev(DevDto requestBody)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

                    string apiUrl = $"{_baseUrl}/DevTest/Dev";

                    StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DevDto>(jsonResponse);
                    return result.id;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task<string> AlterarDev(string id, DevDto dadosDevCadastro)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {

                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(dadosDevCadastro);

                    string apiUrl = $"{_baseUrl}/DevTest/Dev/{id}";

                    StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PutAsync(apiUrl, content);

                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Erro ao consumir a API: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
