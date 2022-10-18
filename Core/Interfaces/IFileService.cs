using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using System.IO;

namespace PDFerterDesktopNet.Core.Interfaces
{
    public interface IFileService
    {
        Task<byte[]> mergeTwoPDFs(IFormFile PdfFileOne, IFormFile PdfFileTwo);

        Task<List<byte[]>> splitPDF(IFormFile pdfFile, int splitIndex);

        byte[] CreateZipResult(List<byte[]> files);
    }
}
