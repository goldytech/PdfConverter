namespace Contoso.PdfConverter.Library.Helpers
{
    using System.Collections.Generic;

    /// <summary>
    /// The app response.
    /// </summary>
    /// <typeparam name="T"> Generic Type Parameter </typeparam>
    public class AppResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppResponse{T}"/> class. 
       /// </summary>
        public AppResponse()
        {
            this.Exceptions = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// Gets or sets the exceptions.
        /// </summary>
        public Dictionary<string, string> Exceptions { get; set; }
    }
}
