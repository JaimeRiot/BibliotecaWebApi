using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Entidades;
using System.Threading.Tasks;
using SLC;

namespace BibliotecaProxyServices
{
    public class Proxy : IService
    {
        string BaseAddress = "https://biblioteca-a1.firebaseio.com";

        #region Peticiones POST AND GET
        // api/products/createproduct
        public async Task<T> SendPost<T, PostData>(string requestURI, PostData data)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    // URI Absoluto
                    requestURI = BaseAddress + requestURI; 
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var JsonData = JsonConvert.SerializeObject(data);
                    HttpResponseMessage Response =
                        await Client.PostAsync(requestURI,
                        new StringContent(JsonData.ToString(),
                        Encoding.UTF8, "application/json"));
                    var ResultWebAPI = await Response.Content.ReadAsStringAsync();
                    Result = JsonConvert.DeserializeObject<T>(ResultWebAPI);

                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }

        // Peticiones GET
        public async Task<T> SendGet<T>(string requesURI)
        {
            T Result = default(T);
            using (var Client = new HttpClient())
            {
                try
                {
                    requesURI = BaseAddress + requesURI;

                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var ResultJSON = await Client.GetStringAsync(requesURI);
                    Result = JsonConvert.DeserializeObject<T>(ResultJSON);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return Result;
        }
        #endregion

        public async Task<Biblioteca> CreateNewBookAsync(Biblioteca newProduct)
        {
            return await SendPost<Biblioteca, Biblioteca>
                ("/api/Biblioteca", newProduct);
        }
        public Biblioteca CreateNewBook(Biblioteca newProduct)
        {
            Biblioteca Result = null;
            Task.Run(async () => Result = await CreateNewBookAsync(newProduct)).Wait();
            return Result;
        }
    }
}
