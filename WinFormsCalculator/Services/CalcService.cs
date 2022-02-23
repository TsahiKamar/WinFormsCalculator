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
            List<Calc> calculations;

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(baseUrl + "Get").GetAwaiter().GetResult();
                    calculations = response.Content.ReadAsAsync<List<Calc>>().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return calculations; 
        }

        public async Task<List<Calc>> GetAsyncCalcHistory()  
        {
            List<Calc> calculations;

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(baseUrl + "Get"); 
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                calculations = response.Content.ReadAsAsync<List<Calc>>().Result;
            }
            catch (Exception ex)
            {
                throw;
            }
            return calculations;
        }



        public Calc AddNewCalc(Calc request)
        {
            Calc result;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(request);
                    StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var response = httpClient.PostAsync(baseUrl + "AddCalc", httpContent).GetAwaiter().GetResult();
                    result = response.Content.ReadAsAsync<Calc>().GetAwaiter().GetResult();

                }
            }
            catch (Exception ex)
            {
                    throw;
            }
            return result;
        }
    }
}




