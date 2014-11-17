#region Copyrights notice
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Client.cs" company="Contoso">
//       MIT License
// </copyright>
// <summary>
//   The client entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#endregion

namespace Contoso.PdfConverter.DomainModel
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /// <summary>
    /// The client entity.
    /// </summary>
    public class Client : EntityBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClientId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        [NotMapped] // no need to store in db
        public string FullName
        {
            get
            {
                return string.Concat(this.FirstName, " ", this.LastName);
            }
        }

        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        [MaxLength(75)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [MaxLength(35)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether client is active. This flag can be useful if becomes defaulter
        /// </summary>
        public bool IsActive { get; set; }


        #endregion    }
    }
}
