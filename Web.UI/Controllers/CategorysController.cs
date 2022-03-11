using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class CategorysController : Controller
    {
        private string baseApiURL ="http://localhost:60868/api/Categorys";
        public async Task<IActionResult> Index()
        {
            var obj = await Insert(new Categorys() { Name = "Snacks", Description = "Snacks Desc"});
            return View();
        }

        public List<Categorys> GetCategorys()
        {
            List<Categorys> list = new List<Categorys>();
            return list;
        }

        public  async Task<Categorys> GetById(int id)
        {
            var category = new Categorys();

            using (HttpClient client = new HttpClient())
            {
                string endPoint = $"{baseApiURL}/getById/{id}";  //localhost.com/api/Categorys/getById/3

                using (var response =await client.GetAsync(endPoint))
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();
                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr); //Deserialize Result

                    if (jsonResponse.IsSuccess)
                    {
                        category = JsonConvert.DeserializeObject<Categorys>(jsonResponse.Data.ToString());
                    }
                    else
                    {

                    }
                }

             }

            return category;
        }

        public async Task<IActionResult> Insert(Categorys model)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = $"{baseApiURL}";
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), 
                                                                                         Encoding.UTF8, "application/json");


                using (var response = await client.PostAsync(endPoint, content))
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result.ToString();
                    var jsonResponse = JsonConvert.DeserializeObject<JsonResponse>(resultStr); //Deserialize Result
                }
            }
            return View();
        }
    }
}
