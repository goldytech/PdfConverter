namespace Contoso.PdfConverter.Library
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DataAccess;
    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.DomainModel;
    using Contoso.PdfConverter.Library.Contracts;
    using Contoso.PdfConverter.Library.Helpers;

    /// <summary>
    /// The main pdf conversion service.
    /// This service will be utilized by the desktop component and WebApi. Here the actual conversion takes place.
    /// </summary>
    public class PdfConversionService : IPdfConversionService
    {

        public PdfConversionService()
        {
            this.AppUnitOfWork = new AppUnitOfWork(new AppDataContext());
        }

        /// <summary>
        /// The convert.
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
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public Task<AppResponse<byte[]>> Convert(byte[] fileBytes, string fileType)
        {
            return Task.Run(async () =>
                    {
                        var response = new AppResponse<byte[]>();
                        try
                        {
                            // Get the extension
                            var extension = Path.GetExtension(fileType);

                            if (extension != null && extension.Equals(".pdf"))
                            {
                                response.Exceptions.Add("Incorrect file","You cannot convert PDF to PDF");
                                return response;
                            }

                            
                            // Create a new file from  raw bytes
                            File.WriteAllBytes(fileType, fileBytes);

                            
                            // Call the actual pdf conversion Component

                            
                            var convertedPdf = new byte[100];
                            var random = new Random();
                            random.NextBytes(convertedPdf); // fill with random bytes
                            // convertedPdf =
                            // somePdfComponent.Convert(File.WriteAllBytes(fileType,
                            // fileBytes))
                            response.Response = convertedPdf;
                            await this.AppUnitOfWork.DocumentRepository.Insert(
                                new Document
                                    {
                                        DocumentId = Guid.NewGuid(),
                                        FileExtension = extension,
                                        CreatedAt =
                                            new DateTimeOffset(
                                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                                    });

                            var isSaved = await this.AppUnitOfWork.SaveChangesAsync() > 0;

                            if (!isSaved)  // operation unsuccessful
                            {
                                response.Exceptions.Add("DbError", "Unable to save");
                                response.Response = null;
                            }

                        }
                            //TODO catch the custom expections of PDF component

                        catch (FileNotFoundException fileNotFoundException)
                        {
                            response.Exceptions.Add("Error2", "Your custom error message");
                        }

                        catch (Exception exception)
                        {
                            response.Exceptions.Add("Error1", "Your custom error message");
                        }
                        return response;
                    });

        }

        public IAppUnitOfWork AppUnitOfWork { get; private set; }
    }
}