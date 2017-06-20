using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        public async Task<ObservableCollection<ZnakModel>> GetJsonString()
        {
            try
            {
                var response = await _client.PostAsync($"{_baseUrl}/test.json", new StringContent("", Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<ObservableCollection<ZnakModel>>(responseBody);
                return responseJson;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return new ObservableCollection<ZnakModel>();
            }
        }

    }
	}
