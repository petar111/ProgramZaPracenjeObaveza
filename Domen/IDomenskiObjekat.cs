using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {

        string Table { get; }

        string AssociativeTable { get; }

        string InsertValues { get; }

        string UpdateValues { get; }

        string Join { get; }

        string SearchWhere(string criteria);

        string SearchId { get; }

        object ColumnId { get; }

        string SearchColumns { get;}

        string DependentObjectID { get; }

        List<List<IDomenskiObjekat>> WeakObjects { get; }

        List<List<IDomenskiObjekat>> AssociativeObjects { get; }

        List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader);
        string SearchById();
        void FillWeakObjects(List<IDomenskiObjekat> weakObjectList);
        void FillAssociativeObjects(List<IDomenskiObjekat> associativeObjectList);
    }
}
