using Microsoft.AspNetCore.Http;
using PDFerterDesktopNet.Validators;

namespace PDFerterDesktopNet.Models
{
    public class SplitFileModel
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".pdf" })]
        public IFormFile PdfFile { get; set; }
    }

    public class SplitFileResultModel
    {
        public IFormFile PdfFile { get; set; }
    }
}
