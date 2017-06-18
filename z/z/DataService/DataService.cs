using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using z.Models;

namespace z.DataService
{
	
		class DataService
		{
        protected DataService()
        {

        }

        private static readonly DataService _dataService = new DataService();
        private HttpClient _client = new HttpClient();
        private readonly HttpClient _httpClient = new HttpClient
        {
            DefaultRequestHeaders = { IfModifiedSince = DateTimeOffset.Now }
        };

        private readonly string _baseUrl = "http://cv58942.tmweb.ru/horo";
        public static DataService GetInstance()
        {
            return _dataService;
        }
        private async Task<string> PostAsync(string script, string json)
        {
            try
            {
                var response = await _client.PostAsync($"{_baseUrl}/{script}", new StringContent(json));

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            var json = new JObject { { "UserName", userName }, { "Password", password } };
            return await PostAsync("/login.php", json.ToString());
        }

        public async Task<string> RegisterAsync(string userName, string password, string CurrentSign)
        {
            var json = new JObject { { "UserName", userName }, { "Password", password }, { "CurrentSign", CurrentSign } };
            return await PostAsync("/reg.php", json.ToString());
        }

        public async Task<List<ZnaksModel>> GetJsonString()
        {
            var json = new JObject { };
            var response = await PostAsync("/test.json", json.ToString());
            var result = JsonConvert.DeserializeObject<List<ZnaksModel>>(response);
            return result;


        }

    }
	}
