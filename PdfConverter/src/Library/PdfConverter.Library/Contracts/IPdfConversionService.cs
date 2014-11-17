namespace Contoso.PdfConverter.Library.Contracts
{
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.Library.Helpers;

    /// <summary>
    /// The PdfConversionService interface.
    /// </summary>
    public interface IPdfConversionService
    {
        /// <summary>
        /// Convert the file to pdf.
        /// </summary>
        /// <param name="fileBytes">
        /// The file bytes.
        /// </param>
        /// <param name="fileType">
        /// The file type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<AppResponse<byte[]>> Convert(byte[] fileBytes, string fileType);

        /// <summary>
        /// Gets the app unit of work.
        /// </summary>
        IAppUnitOfWork AppUnitOfWork { get;  }
    }
}
