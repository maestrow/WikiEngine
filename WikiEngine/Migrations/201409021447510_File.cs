using FiletableDataContext.Migrations;

namespace WikiEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File : CreateFiletable
    {
        protected override string ConnectionStringName
        {
            get { return "WikiEngineContext"; }
        }

        protected override string TableName
        {
            get { return "File"; }
        }
    }
}
