using FiletableDataContext.Migrations;

namespace WikiEngine.Dal.Migrations
{
    public partial class InitFilestream : InitDb
    {
        protected override string ConnectionStringName
        {
            get { return "WikiEngineContext"; }
        }

        public override string RootPath
        {
            get { return @"z:\DBs"; }
        }
    }
}
