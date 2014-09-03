using FiletableDataContext.Domain;

namespace WikiEngine.Dal.Models
{
    public class FileDbContext: FiletableDbContext<File>
    {
        public FileDbContext(): base("name=WikiEngineContext")
        {
        }
    }
}