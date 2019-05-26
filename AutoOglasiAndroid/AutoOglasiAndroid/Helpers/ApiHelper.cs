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
        public ObservableCollection<AutomobiliModel> automobiliModels { get; set; }
        public ObservableCollection<AutomobiliModel> FilteredAutomobiliModels { get; set; }
        private static HttpClient client = new HttpClient();
        public ObservableCollection <BrendAutomobilaModel> CarBrands { get; set; }
        public ObservableCollection<KomentariModel> Komentari { get; set; }
        public UserModel UserModel { get; set; }

        public ObservableCollection<AutomobiliModel> CarsForUser { get; set; }
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
                httpResponse = client.SendAsync(httpRequest).Result;
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

        public  async Task GetAllBrandsAsync()
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

        public async Task GetAllCarsAsync()
        {
            string obj = string.Empty;
            Uri path = new Uri($"http://10.0.2.2:58830/api/Cars");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            List<AutomobiliModel> model = new List<AutomobiliModel>();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse = client.SendAsync(httpRequest).Result;//.GetAwaiter().GetResult();
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    obj = await content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<AutomobiliModel>>(obj);
                }
            }
            catch
            {
                model = null;
            }
            automobiliModels = model.ToObservableCollection();

        }
        public async Task GetCarsForUser(int id)
        {
            CarsForUser = new ObservableCollection<AutomobiliModel>();
            string obj = string.Empty;
            Uri path = new Uri($"http://10.0.2.2:58830/api/Cars/{id}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            List<AutomobiliModel> model = new List<AutomobiliModel>();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse = client.SendAsync(httpRequest).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    obj = await content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<AutomobiliModel>>(obj);
                }
            }
            catch(Exception ex)
            {
                
            }
            CarsForUser = model.ToObservableCollection();

           
        }

        public async Task GetCarByCriteria(string brand,string year)
        {
            string obj = string.Empty;
            Uri path = new Uri($"http://10.0.2.2:58830/api/Cars?brand={brand}&year={year}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            List<AutomobiliModel> model = new List<AutomobiliModel>();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse = client.SendAsync(httpRequest).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    obj = await content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<AutomobiliModel>>(obj);
                }
            }
            catch
            {
                model = null;
            }
            automobiliModels = model.ToObservableCollection();
        }

        
        public async Task GetCommentByCarIdAsync(int id)
        {
            Komentari = new ObservableCollection<KomentariModel>();
            Uri path = new Uri($"http://10.0.2.2:58830/api/Comments/{id}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            List<KomentariModel> komentariModel = new List<KomentariModel>();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse =  client.SendAsync(httpRequest).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = httpResponse.Content;
                    var obj = await content.ReadAsStringAsync();
                    komentariModel = JsonConvert.DeserializeObject<List<KomentariModel>>(obj);
                }
            }
            catch
            {
                
            }
            Komentari = komentariModel.ToObservableCollection();
        }
        public  async Task<string> InsertComment(KomentariModel model)
        {
            string res = string.Empty;
            Uri path = new Uri($"http://10.0.2.2:58830/api/Comments?Komentar={model.Komentar}&KorisnikID={model.KorisnikID}&autoID={model.AutomobilID}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Post
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse =  client.SendAsync(httpRequest).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK || httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    res = "OK";

                }
                
            }
            catch
            {
                res = "failed";
            }
            return res;
        }

        public async Task<string> InsertCar(AutomobiliModel model)
        {
            string res = string.Empty;
           
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            var json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Host", "localhost");
            try
            {
                httpResponse = client.PostAsJsonAsync(@"http://10.0.2.2:58830/api/Cars", model).Result;
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK || httpResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    res = "OK";
                }

            }
            catch(Exception ex)
            {
                res = "failed";
            }
            return res;
           
        }
        public async Task<string> DeleteCar(int id)
        {
            string res = string.Empty;
            Uri path = new Uri($"http://10.0.2.2:58830/api/Comments/{id}");
            HttpRequestMessage httpRequest = new HttpRequestMessage
            {
                RequestUri = path,
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("Accept", "application/json");
            httpRequest.Headers.Add("Host", "localhost");
            List<KomentariModel> komentariModel = new List<KomentariModel>();
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse =  client.SendAsync(httpRequest).GetAwaiter().GetResult();
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    res = "OK";
                }
            }
            catch
            {
                res = "failed";
            }
            return res;

        }

    }
}
