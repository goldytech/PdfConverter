using System;

namespace Contoso.PdfConverter.DataAccess.Contracts
{
    using Contoso.PdfConverter.DomainModel;

    /// <summary>
    /// The DocumentRepository interface.
    /// </summary>
    public interface IDocumentRepository : IDataRepository<Document, Guid>
    {
    }
}
