using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Silicon.models;
using System.Text;

namespace Silicon.Controllers
{
    public class ContactController(HttpClient http) : Controller
    {
        private readonly HttpClient _http = http;

        public async Task<IActionResult> ContactRegistration(ContactViewModel form)
        {
            if ( ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "Application/json");
                var response = await _http.PostAsync("https://localhost:7088/api/ContactApi", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Home", "Default");
                }
                else
                {
                    return RedirectToAction("NotAvailable", "Default");
                }
                
            }
            return View();
        }
    }
}
