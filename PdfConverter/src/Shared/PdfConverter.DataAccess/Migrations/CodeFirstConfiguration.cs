namespace Contoso.PdfConverter.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /// <summary>
    /// The code first configuration.
    /// </summary>
    public sealed class CodeFirstConfiguration : DbMigrationsConfiguration<Contoso.PdfConverter.DataAccess.AppDataContext>
    {
        public CodeFirstConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contoso.PdfConverter.DataAccess.AppDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
