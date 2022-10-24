using System;
using System.IO;
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
            return File(mergeResult, "application/pdf", "result.pdf");
        }

        [HttpGet]
        public IActionResult SplitResult()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SplitResult(int index, IFormFile files)
        {
            var splitResult = await _fileService.splitPDF(files, index);
            if (splitResult == null)
            {
                return View("Error");
            }
            var zip = _fileService.CreateZipResult(splitResult);
            return File(zip, "application/octet-stream", "SplitResult.zip");
        }
    }
}
