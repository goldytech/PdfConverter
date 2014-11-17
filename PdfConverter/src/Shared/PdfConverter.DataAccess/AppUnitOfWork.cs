namespace Contoso.PdfConverter.DataAccess
{
    using System;
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.DataAccess.Repositories;

    public class AppUnitOfWork : IAppUnitOfWork, IDisposable
    {
          #region Declarations
        /// <summary>
        /// The data context.
        /// </summary>
        protected readonly AppDataContext dataContext;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

      

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AppUnitOfWork"/> class.
        /// </summary>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        public AppUnitOfWork(AppDataContext dataContext)
        {
            this.dataContext = dataContext;
            this.ClientRepository = new ClientRepository(this.dataContext);
        }

        #region IAppUnitOfWork Implementation

        /// <summary>
        /// Gets the client repository.
        /// </summary>
        public IClientRepository ClientRepository
        {
            get; private set;
        }

        public IDocumentRepository DocumentRepository { get; private set; }

        public Task<int> SaveChangesAsync()
        {
             return this.dataContext.SaveChangesAsync();
        } 
        #endregion

        #region IDisposable Implementation

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dataContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
