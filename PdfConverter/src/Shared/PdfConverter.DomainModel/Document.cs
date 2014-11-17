// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Document.cs" company="Contoso">
//      MIT License
// </copyright>
// <summary>
//   The document entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Contoso.PdfConverter.DomainModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Cache;

    /// <summary>
    /// The document entity.
    /// </summary>
    public class Document : EntityBase
    {
        /// <summary>
        /// Gets or sets the document id.
        /// </summary>
        public Guid DocumentId
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required,MaxLength(100)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the file extension.
        /// </summary>
        [MaxLength(10)]
        public string FileExtension
        {
            get; 
            set;
        }
    }
}
