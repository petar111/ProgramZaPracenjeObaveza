using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class StavkaObaveze : IDomenskiObjekat
    {
        [Browsable(false)]
        public int IdObaveze { get; set; }

        [DisplayName("R.B.")]
        public int RedniBroj { get; set; }

        public string Naziv { get; set; }

        public string Napomena { get; set; }

        [Browsable(false)]
        public string Table => "StavkaObaveze";
        [Browsable(false)]
        public string InsertValues => $"{IdObaveze},{RedniBroj},'{Naziv}','{Napomena}'";
        [Browsable(false)]
        public string UpdateValues => "";
        [Browsable(false)]
        public string Join => "";
        [Browsable(false)]
        public string SearchId => "RedniBroj";
        [Browsable(false)]
        public object ColumnId => RedniBroj;
        [Browsable(false)]
        public string SearchColumns => "";
        [Browsable(false)]
        public string DependentObjectID => "IdObaveze";
        [Browsable(false)]
        public List<List<IDomenskiObjekat>> WeakObjects => throw new NotImplementedException();
        [Browsable(false)]
        public string AssociativeTable => throw new NotImplementedException();

        public List<List<IDomenskiObjekat>> AssociativeObjects => throw new NotImplementedException();

        public void FillAssociativeObjects(List<IDomenskiObjekat> associativeObjectList)
        {
            throw new NotImplementedException();
        }

        public void FillWeakObjects(List<IDomenskiObjekat> weakObjectList)
        {
            throw new NotImplementedException();
        }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> result = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                StavkaObaveze stavkaObaveze = new StavkaObaveze()
                {
                    IdObaveze = (int)reader["IdObaveze"],
                    RedniBroj = (int)reader["RedniBroj"],
                    Naziv = (string)reader["Naziv"],
                    Napomena = (string)reader["Napomena"]
                };
                result.Add(stavkaObaveze);
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
    }
}
