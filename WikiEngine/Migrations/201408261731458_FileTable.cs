using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace WikiEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTable : DbMigrationBase
    {
        public override void Up()
        {
            Sql(string.Format(@"ALTER DATABASE {0} ADD FILEGROUP {0}Group CONTAINS FILESTREAM", DbName), true);
            Sql(string.Format(@"ALTER DATABASE {0}
                ADD FILE (
	                NAME = '{0}Filestream',
	                FILENAME = 'z:\DBs\{0}\Filestream'
                ) TO FILEGROUP {0}Group
                ", DbName), true);
        }
        
        public override void Down()
        {
            Sql(string.Format(@"ALTER DATABASE {0} REMOVE FILE {0}Filestream", DbName), true);
            Sql(string.Format(@"ALTER DATABASE {0} REMOVE FILEGROUP {0}Group", DbName), true);
        }

    }
}
