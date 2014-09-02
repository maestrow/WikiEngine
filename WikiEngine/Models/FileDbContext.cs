using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FiletableDataContext.Domain;

namespace WikiEngine.Models
{
    public class FileDbContext: FiletableDbContext<File>
    {
        public FileDbContext(): base("name=WikiEngineContext")
        {
        }
    }
}