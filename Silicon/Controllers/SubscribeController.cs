using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon.Models;
using System.Text;

namespace Silicon.Controllers
{
    public class SubscribeController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        [HttpPost]
        public async Task<IActionResult> Register(SubscribeViewModel form)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7072/api/Sub", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Home", "Default");
                }
                else
                {
                    return RedirectToAction("NotAvailable", "Default");
                }
            }
            return RedirectToAction("Home", "Default");
        }
    }
}
