namespace WikiEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// Данная команда часто завершается по таймауту. Помогает рестарт Sql Server.
    /// </summary>
    public partial class FileStreamProperties : DbMigrationBase
    {
        public override void Up()
        {
            Sql(string.Format(@"ALTER DATABASE {0} SET FILESTREAM ( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = '{0}' )", DbName), true);
        }
        
        public override void Down()
        {
        }
    }
}
