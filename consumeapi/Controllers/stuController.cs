using Microsoft.AspNetCore.Mvc;
using consumeapi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace consumeapi.Controllers
{
    public class stuController : Controller
    {
        Uri baseAdress = new Uri("https://localhost:7043/api");
        private readonly HttpClient _httpClient;
        public stuController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAdress;


        }
        [HttpGet]
        public IActionResult Index()
        {
            List<stviewmodel> stlist = new List<stviewmodel>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAdress + "/students").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stlist = JsonConvert.DeserializeObject<List<stviewmodel>>(data);
            }

            return View(stlist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(stviewmodel modell)
        {

            string data = JsonConvert.SerializeObject(modell);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(baseAdress + "/students/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            stviewmodel stv = new stviewmodel();
            HttpResponseMessage response = _httpClient.GetAsync(baseAdress + "/students/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stv = JsonConvert.DeserializeObject<stviewmodel>(data);
            }

            return View(stv);
        }
        [HttpPost]
        public IActionResult edit(stviewmodel modell)
        {

            string data = JsonConvert.SerializeObject(modell);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PutAsync(baseAdress + "/students/" + modell.StudentId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(modell);

        }
        
         [HttpGet]

        public IActionResult Delete(int id)
        {
            stviewmodel stv = new stviewmodel();
            HttpResponseMessage response = _httpClient.GetAsync(baseAdress + "/students/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stv = JsonConvert.DeserializeObject<stviewmodel>(data);
            }

            return View(stv);
        }
       // [HttpDelete("{id}")]

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(baseAdress + "/students/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
    

    

