namespace WikiEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileTable_Data : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE TABLE data AS FileTable WITH (FILETABLE_STREAMID_UNIQUE_CONSTRAINT_NAME = ui_file_stream)");
        }
        
        public override void Down()
        {
            Sql(@"DROP TABLE data");
        }
    }
}
