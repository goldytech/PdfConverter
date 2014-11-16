using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.PdfConverter.DataAccess
{
    using System.Data.Entity;

    using Contoso.PdfConverter.DataAccess.Migrations;

    public class AppDbInitializer : MigrateDatabaseToLatestVersion<AppDataContext, CodeFirstConfiguration>
    {

    }
}
