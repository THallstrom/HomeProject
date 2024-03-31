using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silicon;

public class SiteSettingsController : Controller
{
    public IActionResult Theme(string mode)
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30)
        };
    Response.Cookies.Append("theme", mode, option);
    return Ok();
    }
    public IActionResult Consent()
    {
        var option = new CookieOptions
        {
            Expires = DateTime.Now.AddDays(30),
            HttpOnly = true,
            Secure = true
        };
    Response.Cookies.Append("concent", "true", option);
    return Ok();
    }
}
