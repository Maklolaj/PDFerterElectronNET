using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using PDFerterDesktopNet.Models;

namespace PDFerterDesktopNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MergeResult()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MergeResult(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var file = new MyFile()
            {
                PdfFile = files[0]
            };
            return View(file);
        }

        public IActionResult SplitResult()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {

            return View();
        }


        // Pzy Submicie wołam index(file)
        [HttpPost]
        public IActionResult Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var file = new MyFile()
            {
                PdfFile = files[0]
            };
            return View(file);
        }

    }
}
