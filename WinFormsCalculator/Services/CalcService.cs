using WinFormsCalculator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
//using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace WinFormsCalculator.Services
{
    public class CalcService : ICalcService
    {

            const string baseUrl = "http://localhost:4973/Calc/";

            public CalcService()
            {

            }

 
        public List<Calc> GetCalcHistory() 
        {
            try
            {
                List<Calc> calculations;
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(baseUrl + "Get").GetAwaiter().GetResult();
                    calculations = response.Content.ReadAsAsync<List<Calc>>().GetAwaiter().GetResult();
                    return calculations;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null; 
        }

        public async Task<List<Calc>> GetAsyncCalcHistory()  
        {
            try
            {

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseUrl + "Get"); 
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var calculations = response.Content.ReadAsAsync<List<Calc>>().Result;
                return calculations;
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }



        public Calc AddNewCalc(Calc request)
            {
                try
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    //string apiUrl = API_URIs.baseURI + url;
                    //using (HttpClient client = new HttpClient())
                    //{
                    //    string json = JsonConvert.SerializeObject(request);

                    //    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    //    client.BaseAddress = new Uri(baseUrl + "AddCalc");
                    //    //client.Timeout = TimeSpan.FromSeconds(900);
                    //    //client.DefaultRequestHeaders.Accept.Clear();
                    //    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //    var response = client.PostAsync(baseUrl + "AddCalc", httpContent);
                    //    response.Wait();
                    //    return response;
                    //}

                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(request);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = httpClient.PostAsync(baseUrl + "AddCalc", httpContent).GetAwaiter().GetResult();
                    //calculations = response.Content.ReadAsAsync<List<Calc>>().GetAwaiter().GetResult();
                    var result = response.Content.ReadAsAsync<Calc>().GetAwaiter().GetResult();
                    return result;

                }



            }
            catch (Exception ex)
                {
                    throw;
                }
            }




        }
    }




