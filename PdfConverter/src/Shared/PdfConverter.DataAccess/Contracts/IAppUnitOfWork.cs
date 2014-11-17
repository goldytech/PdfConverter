namespace Contoso.PdfConverter.DataAccess.Contracts
{
    using System.Threading.Tasks;

    /// <summary>
    /// The AppUnitOfWork interface.
    /// </summary>
    public interface IAppUnitOfWork
    {
       /// <summary>
       /// Gets the client repository.
       /// </summary>
       IClientRepository ClientRepository
       {
           get;
       }

       /// <summary>
       /// Gets the document repository.
       /// </summary>
       IDocumentRepository DocumentRepository
       {
           get;
       }

       /// <summary>
       /// The save changes async.
       /// </summary>
       /// <returns>
       /// The <see cref="Task"/>.
       /// </returns>
       Task<int> SaveChangesAsync();
    }
}
