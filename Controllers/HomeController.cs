using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PDFerterDesktopNet.Core.Interfaces;
using PDFerterDesktopNet.Models;

namespace PDFerterDesktopNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFileService _fileService;

        public HomeController(ILogger<HomeController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
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
        public async Task<IActionResult> MergeResult(List<IFormFile> files)
        {
            var mergeResult = await _fileService.mergeTwoPDFs(files[0], files[1]);

            return View(mergeResult);
        }

        [HttpGet]
        public IActionResult SplitResult()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SplitResult(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var file = new MyFile()
            {
                PdfFile = files[0]
            };
            return View(file);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {

            return View();
        }
    }
}
