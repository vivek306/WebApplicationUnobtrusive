using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationUnobtrusive.Models;
using WebApplicationUnobtrusive.Helpers.Renderers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationUnobtrusive.Controllers
{
    public class SimpleController : Controller
    {
        private readonly RazorViewToStringRenderer _renderer;

        public SimpleController(RazorViewToStringRenderer renderer)
        {
            _renderer = renderer;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(new SimpleModel { DateTimeValue = DateTime.Now.ToString() });
        }

        public string UpdateTime(SimpleModel dateTime)
        {
            string html = "";
            var path = "~/Views/Simple/Partials/_SimpleDateTime.cshtml";
            dateTime.DateTimeValue = DateTime.Now.ToString();
            html = _renderer.RenderViewToString(path, dateTime);
            return html;
        }
    }
}
