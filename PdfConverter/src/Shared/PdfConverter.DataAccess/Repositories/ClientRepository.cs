namespace Contoso.PdfConverter.DataAccess.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DataAccess.Contracts;
    using Contoso.PdfConverter.DomainModel;

    public class ClientRepository : IClientRepository
    {
        /// <summary>
        /// The app data context.
        /// </summary>
        private readonly AppDataContext appDataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// </summary>
        /// <param name="appDataContext">
        /// The app data context.
        /// </param>
        public ClientRepository(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public async Task<Client> GetByIdAsync(long id)
        {
            using (this.appDataContext)
            {
                var client = await this.appDataContext.Clients.SingleOrDefaultAsync(e => e.ClientId.Equals(id));
                return client;    
            }
        }

        public Task<IQueryable<Client>> RetrieveAllRecordsAsync()
        {
            return Task.Run(
                () =>
                {
                    var clients = this.appDataContext.Clients.AsQueryable();
                    return clients;
                });
        }

        public Task Insert(Client entity)
        {
            return Task.Run(() => this.appDataContext.Clients.Add(entity));
        }

        public Task Update(Client entity)
        {
            return Task.Run(async () =>
            {
                var original = await this.appDataContext.Clients.FirstOrDefaultAsync(e => e.ClientId.Equals(entity.ClientId));
                if (original != null)
                {
                    this.appDataContext.Entry(original).CurrentValues.SetValues(entity);
                }
            });
        }

        public Task Delete(long id)
        {
            return Task.Run(async () =>
            {
                var clientToBeDeleted = await this.appDataContext.Clients.FirstOrDefaultAsync(e => e.ClientId.Equals(id));
                if (clientToBeDeleted != null)
                {
                    this.appDataContext.Clients.Remove(clientToBeDeleted);
                }
            });
        }

        /// <summary>
        /// The is email unique.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> IsEmailUnique(string email)
        {
            return this.appDataContext.Clients.AnyAsync(e => e.Email.Equals(email));
        }
    }
}
