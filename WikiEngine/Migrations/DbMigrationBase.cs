using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WikiEngine.Migrations
{
    public abstract class DbMigrationBase: DbMigration
    {
        protected string DbName
        {
            get
            {
                var connBuilder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["WikiEngineContext"].ConnectionString);
                return connBuilder.InitialCatalog;
            }
        }

    }
}