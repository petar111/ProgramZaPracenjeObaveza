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
    public class Korisnik : IDomenskiObjekat
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }

        [Browsable(false)]
        public List<IzvrsilacObaveze> IzvrsavaObaveze { get; set; }

        [Browsable(false)]
        public string Sifra { get; set; }
        [Browsable(false)]
        public string Table => "Korisnik";
        [Browsable(false)]
        public string InsertValues => $"'{Ime}','{Prezime}','{KorisnickoIme}','{Sifra}'";
        [Browsable(false)]
        public string UpdateValues => $"Ime = '{Ime}', Prezime = '{Prezime}', KorisnickoIme = '{KorisnickoIme}', Sifra = '{Sifra}'";
        [Browsable(false)]
        public string Join => "";
        [Browsable(false)]
        public string SearchId => "IdKorisnika";
        [Browsable(false)]
        public object ColumnId => Id;

        [Browsable(false)]
        public string SearchColumns => throw new NotImplementedException();
        [Browsable(false)]
        public List<List<IDomenskiObjekat>> WeakObjects => throw new NotImplementedException();
        [Browsable(false)]
        public string DependentObjectID => throw new NotImplementedException();
        [Browsable(false)]
        public string AssociativeTable => "IzvrsilacObaveze";
        [Browsable(false)]
        public List<List<IDomenskiObjekat>> AssociativeObjects => new List<List<IDomenskiObjekat>>() { IzvrsavaObaveze.Cast<IDomenskiObjekat>().ToList() };

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
                Korisnik korisnik = new Korisnik()
                {
                    Id = (int)reader["IdKorisnika"],
                    Ime = (string)reader["Ime"],
                    Prezime = (string)reader["Prezime"],
                    KorisnickoIme = (string)reader["KorisnickoIme"],
                    Sifra = (string)reader["Sifra"]
                };

                result.Add(korisnik);
            }

            return result;
        }

        public string SearchById()
        {
            return $"IdKorisnika = {Id}";
        }

        public string SearchWhere(string criteria)
        {
            return $"WHERE KorisnickoIme = '{KorisnickoIme}' AND Sifra = '{Sifra}'";
        }
    }
}
