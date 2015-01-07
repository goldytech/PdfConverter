namespace Contoso.PdfConverter.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;

    using Contoso.PdfConverter.Library.Contracts;
    using Contoso.PdfConverter.WebApi.Models;

    /// <summary>
    /// The pdf converter controller.
    /// </summary>
    [RoutePrefix("services/pdf-conversion")]
    public class PdfConverterController : ApiController
    {
        private readonly IPdfConversionService pdfConversionService;

        public PdfConverterController(IPdfConversionService pdfConversionService)
        {
            this.pdfConversionService = pdfConversionService;
        }

        [Route("v1")]
        [HttpPost]
        public async Task<IHttpActionResult> ConvertToPdf([FromBody] InputFile inputFile)
        {
            if (inputFile == null)
            {
                return this.BadRequest();
            }

           var response = await this.pdfConversionService.Convert(inputFile.Contents, inputFile.FileName);
            if (response.Exceptions.Any())
            {
                // error occurred
                return this.InternalServerError(new Exception(response.Exceptions.FirstOrDefault().Value));
            }

            return this.Ok(response.Response); 
        }

        public IHttpActionResult PostStream()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return this.BadRequest();
            }

            var provider = new CustomStreamProvider(HttpContext.Current.Server.MapPath("App_Data"));


        }


    }

    internal class CustomStreamProvider : MultipartFileStreamProvider
    {
        public CustomStreamProvider(string rootPath)
            : base(rootPath)
        {
        }

        public CustomStreamProvider(string rootPath, int bufferSize)
            : base(rootPath, bufferSize)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace(@"\", string.Empty);
        }
    }
}
