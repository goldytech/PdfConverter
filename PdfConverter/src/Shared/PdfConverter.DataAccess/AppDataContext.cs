namespace Contoso.PdfConverter.DataAccess
{
    using System.Data.Entity;
    using System.Threading;

    using Contoso.PdfConverter.DomainModel;

    /// <summary>
    /// The application data context.
    /// </summary>
    public class AppDataContext : DbContext
    {
        public AppDataContext()
            :base("AppCtx")
        {
           Database.SetInitializer(new AppDbInitializer()); 
        }

        public DbSet<Client> Clients
        {
            get;
            set;
        }

        public DbSet<Document> Documents
        {
            get; 
            set;
        }
    }
}
