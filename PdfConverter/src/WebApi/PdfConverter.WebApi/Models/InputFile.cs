namespace Contoso.PdfConverter.WebApi.Models
{
    public class InputFile
    {
        public string FileName { get; set; }

        public byte[] Contents { get; set; }
    }
}