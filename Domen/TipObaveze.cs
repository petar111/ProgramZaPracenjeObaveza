using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class TipObaveze : IDomenskiObjekat
    {
        public int IdTipaObaveze { get; set; }

        public string Naziv { get; set; }

        public string Table => "TipObaveze";

        public string InsertValues => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string Join => "";

        public string SearchId => "IdTipaObaveze";

        public object ColumnId => IdTipaObaveze;

        public string SearchColumns => throw new NotImplementedException();

        public List<List<IDomenskiObjekat>> WeakObjects => throw new NotImplementedException();

        public string DependentObjectID => throw new NotImplementedException();

        public string AssociativeTable => throw new NotImplementedException();

        public List<List<IDomenskiObjekat>> AssociativeObjects => throw new NotImplementedException();

        public override string ToString()
        {
            return Naziv;
        }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> result = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                TipObaveze tipObaveze = new TipObaveze()
                {
                    IdTipaObaveze = (int)reader["IdTipaObaveze"],
                    Naziv = (string)reader["NazivTipaObaveze"]
                };

                result.Add(tipObaveze);
            }

            return result;
        }

        public string SearchById()
        {
            throw new NotImplementedException();
        }

        public string SearchWhere(string criteria)
        {
            throw new NotImplementedException();
        }

        public void FillWeakObjects(List<IDomenskiObjekat> weakObjectList)
        {
            throw new NotImplementedException();
        }

        public void FillAssociativeObjects(List<IDomenskiObjekat> associativeObjectList)
        {
            throw new NotImplementedException();
        }
    }
}
