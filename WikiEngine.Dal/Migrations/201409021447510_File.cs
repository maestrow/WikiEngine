using FiletableDataContext.Migrations;

namespace WikiEngine.Dal.Migrations
{
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
