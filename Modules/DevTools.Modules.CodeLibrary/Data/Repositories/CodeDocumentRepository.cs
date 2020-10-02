using DevTools.Modules.CodeLibrary.Model;
using FreeSql;

namespace DevTools.Modules.CodeLibrary.Data.Repositories
{
    public class CodeDocumentRepository : BaseRepository<CodeDocument, int>
    {
        public CodeDocumentRepository(IFreeSql fsql) : base(fsql, null, null)
        {


        }
    }
}
