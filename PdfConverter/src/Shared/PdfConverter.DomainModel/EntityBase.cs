namespace Contoso.PdfConverter.DomainModel
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The entity base.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTimeOffset CreatedAt
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the modified at.
        /// </summary>
        public DateTimeOffset? ModifiedAt
        {
            get; 
            set;
        }

        /// <summary>
        /// Gets or sets the time stamp for concurrency checks. Similar to row version in SQL Server
        /// </summary>
        [Timestamp]
        public byte[] TimeStamp
        {
            get;
            set;
        }
    }
}
