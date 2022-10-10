using Microsoft.AspNetCore.Http;
using PDFerterDesktopNet.Validators;

namespace PDFerterDesktopNet.Models
{
    public class MergeFilesModel
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf" })]
        public IFormFile PdfFileOne { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf" })]
        public IFormFile PdfFileTwo { get; set; }
    }

    public class MergeFilesResultModel
    {
        public IFormFile PdfFile { get; set; }
    }
}