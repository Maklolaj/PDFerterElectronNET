using PDFerterDesktopNet.Core.Interfaces;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Microsoft.Extensions.Logging;
using ICSharpCode.SharpZipLib.Zip;

namespace PDFerterDesktopNet.Core.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task<byte[]> mergeTwoPDFs(IFormFile PdfFileOne, IFormFile PdfFileTwo)
        {
            PdfDocument document = new PdfDocument();

            foreach (var fileStream in new List<Stream>() { PdfFileOne.OpenReadStream(), PdfFileTwo.OpenReadStream() })
            {
                PdfDocument inputPDFDocument = await Task.Run(() => PdfReader.Open(fileStream, PdfDocumentOpenMode.Import));

                document.Version = inputPDFDocument.Version;

                foreach (PdfPage page in inputPDFDocument.Pages)
                {
                    document.AddPage(page);
                }
            }
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            byte[] docBytes = stream.ToArray();
            return docBytes;
        }
    }
}
