namespace Contoso.PdfConverter.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.DomainModel;

    class DocumentRepository : IDocumentRepository
    {
        public Task<Document> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Document>> RetrieveAllRecordsAsync()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Document entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Document entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}