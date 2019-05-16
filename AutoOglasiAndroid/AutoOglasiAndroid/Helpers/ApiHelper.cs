using AutoOglasiAndroid.Models;
using Newtonsoft.Json;
using PolovniAutomobili;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace AutoOglasiAndroid.Helpers
{
    public  class ApiHelper
    {
        public ApiHelper()
        {
           
        }
        private static HttpClient client = new HttpClient();
        public ObservableCollection <BrendAutomobilaModel> CarBrands { get; set; }
        public UserModel UserModel { get; set; }
       
        public  async void RegisterUserAsync(UserModel model)
        {
            UserModel userModel = new UserModel();
            HttpRequestMessage httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri($"http://10.0.2.2:58830/api/Korisnik?email={model.Email}&password={model.Password}&ime={model.ImePrezime}"),
                Method = HttpMethod.Post
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            HttpResponseMessage httpResponse = new HttpResponseMessage();
    
            try
            {
                httpResponse = client.SendAsync(httpRequest).GetAwaiter().GetResult();
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    var obj = await content.ReadAsStringAsync();
                    userModel = JsonConvert.DeserializeObject<UserModel>(obj);
                }
                else
                {
                    userModel.Message = "Nismo u mogucnosti da vas registrujemo";
                }
            }
            catch
            {
                userModel.Message = "Doslo je do greske u konekciji";
            }
            UserModel = userModel;
            //return userModel;

        }
        public  async Task LoginUserAsync(string email, string pass)
        {
            Uri path = new Uri($"http://10.0.2.2:58830/api/Korisnik?email={email}&password={pass}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");

            UserModel model = null;
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse =  client.SendAsync(httpRequest).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    var obj = await content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<UserModel>(obj);
                }
            }
            catch
            {
                model = null;
            }

            UserModel = model;
           
        }

        public  async Task<UserModel> GetUserByIdAsync(int id)
        {
            Uri path = new Uri($"http://10.0.2.2:58830/api/Korisnik/{id}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            UserModel model = null;
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse = await client.SendAsync(httpRequest);
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    var obj = await content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<UserModel>(obj);
                }
            }
            catch
            {
                model = null;
            }

            return model;
        }

        public  async void GetAllBrandsAsync()
        {
            string obj = string.Empty;
            Uri path = new Uri($"http://10.0.2.2:58830/api/CarsBrand");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            List<BrendAutomobilaModel> model = new List<BrendAutomobilaModel>();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse =  client.SendAsync(httpRequest).Result;//.GetAwaiter().GetResult();
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                     obj = await content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BrendAutomobilaModel>>(obj);
                }
            }
            catch
            {
                model = null;
            }
            CarBrands = model.ToObservableCollection();
            //return model.ToObservableCollection();

        }
        public async Task<List<Employee>> ReturnAllObjects()
        {
            List<Employee> employees = new List<Employee>();
            string x = string.Empty;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(@"http://dummy.restapiexample.com/api/v1/employees");
            if (response.IsSuccessStatusCode)
            {
                x = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employee>>(x);
            }
            return employees;
        }
        public async Task<List<Employee>> GetObjs()
        {
            var x = await ReturnAllObjects();
            return x;
        }
    }
}
