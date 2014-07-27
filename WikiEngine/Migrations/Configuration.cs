using WikiEngine.Models;

namespace WikiEngine.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WikiEngine.Models.WikiEngineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WikiEngine.Models.WikiEngineContext";
        }

        protected override void Seed(WikiEngine.Models.WikiEngineContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Pages.AddOrUpdate(page => page.Id,
                new Page() { CreatedAt = new DateTime(2014, 07, 03), LastEditAt = new DateTime(2014, 07, 07), Title = "111", Content = "aaaaa" },
                new Page() { CreatedAt = new DateTime(2014, 07, 04), LastEditAt = new DateTime(2014, 07, 07), Title = "222", Content = "bbbbb" },
                new Page() { CreatedAt = new DateTime(2014, 07, 05), LastEditAt = new DateTime(2014, 07, 07), Title = "333", Content = "ccccc" },
                new Page() { CreatedAt = new DateTime(2014, 07, 06), LastEditAt = new DateTime(2014, 07, 08), Title = "444", Content = "ddddd" },
                new Page() { CreatedAt = new DateTime(2014, 07, 07), LastEditAt = new DateTime(2014, 07, 08), Title = "555", Content = "eeeee" }
                );
        }
    }
}
