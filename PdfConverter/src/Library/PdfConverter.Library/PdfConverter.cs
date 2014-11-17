namespace Contoso.PdfConverter.Library
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.Threading.Tasks;

    using Contoso.PdfConverter.Library.Contracts;
    using Contoso.PdfConverter.Library.Helpers;

    public class PdfConverter
    {
        #region Declarations
       
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfConverter"/> class.
        /// </summary>
        /// <exception cref="SecurityException"> Invalid License
        /// </exception>
        public PdfConverter()
        {
            this.CheckIfLicenseExists();
            if (!this.IsLicenseValid)
            {
                throw new SecurityException("Invalid License"); // you cannot proceed further if you don't have valid license
            }

            this.PdfConversionService = new PdfConversionService();
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the pdf conversion service.
        /// </summary>
        private IPdfConversionService PdfConversionService
        {
            get;
            set;
        }

        private bool IsLicenseValid { get; set; }
        
        #endregion

        #region Methods
        /// <summary>
        /// This method will be used by all thick clients to convert. The core pdf conversion service is abstracted from the thick client via private property
        /// </summary>
        /// <param name="inputFilePath">
        /// The input file path.
        /// </param>
        /// <param name="outputFilePath">
        /// The output file path.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<AppResponse<bool>> ConvertToPdf(string inputFilePath, string outputFilePath)
        {
            if (inputFilePath == null)  // defensive programming
            {
                throw new ArgumentNullException("inputFilePath");
            }

            if (outputFilePath == null)
            {
                throw new ArgumentNullException("outputFilePath");
            }

            // double check for license
            if (!this.IsLicenseValid)
            {
                return new AppResponse<bool>
                           {
                               Response = false,
                               Exceptions = new Dictionary<string, string> { { "Error", "Invalid License" } }
                           };
            }

           
                var fileBytes = File.ReadAllBytes(inputFilePath);
                var response = await this.PdfConversionService.Convert(fileBytes, inputFilePath);
                var returnResponse = new AppResponse<bool>();
                if (!response.Exceptions.Any())
                {
                    // conversion was successful
                    File.WriteAllBytes(outputFilePath, response.Response);
                    returnResponse.Response = true;
                }
                else
                {
                    returnResponse.Exceptions = response.Exceptions;
                    returnResponse.Response = false; // error occurred
                }

                return returnResponse;
            
        }

        /// <summary>
        /// The check if license exists.
        /// </summary>
        private void CheckIfLicenseExists()
        {
            // write here logic of checking the license key for the desktop
            // Component.A file should exists and should have a valid lic key 4
            this.IsLicenseValid = true; // license is ok for this demo
        } 
        #endregion
    }
}
