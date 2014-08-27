using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace WikiEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /*
        select * from sys.filegroups

        select
            sys.database_files.name
            ,sys.data_spaces.*
        from 
            sys.database_files
            inner join sys.data_spaces on sys.database_files.data_space_id = sys.data_spaces.data_space_id
     **/


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
