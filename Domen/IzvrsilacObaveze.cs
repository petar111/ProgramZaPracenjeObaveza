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
    public class IzvrsilacObaveze : IDomenskiObjekat
    {
        [Browsable(false)]
        public Obaveza Obaveza { get; set; }
        [Browsable(false)]
        public Korisnik Korisnik { get; set; }
        public string Prezime { get { return Korisnik.KorisnickoIme; } }
        public string Ime { get { return Korisnik.KorisnickoIme; } }
        public string KorisnickoIme { get { return Korisnik.KorisnickoIme; } }

        [DisplayName("P.I.")]
        public bool Potvrdjena { get; set; }

        [Browsable(false)]
        public string PotvrdjenaInsert { get { return Potvrdjena ? "1" : "0"; } }
        [Browsable(false)]
        public string Table => "IzvrsilacObaveze";
        [Browsable(false)]
        public string AssociativeTable => throw new NotImplementedException();
        [Browsable(false)]
        public string InsertValues => $"{Korisnik.Id},{Obaveza.IdObaveze},{PotvrdjenaInsert}";
        [Browsable(false)]
        public string UpdateValues => $" IdKorisnika = {Korisnik.Id}, IdObaveze = {Obaveza.IdObaveze}, PotvrdioIzvrsenje = {PotvrdjenaInsert} ";
        [Browsable(false)]
        public string Join => " io JOIN Korisnik korisnik ON io.IdKorisnika = korisnik.IdKorisnika " +
                                "JOIN Obaveza obaveza ON io.IdObaveze = obaveza.IdObaveze ";
        [Browsable(false)]
        public string SearchId => "IdObaveze";
        [Browsable(false)]
        public object ColumnId => throw new NotImplementedException();
        [Browsable(false)]
        public string SearchColumns => "io.IdObaveze as ObavezaId, io.IdKorisnika as KorisnikId, io.PotvrdioIzvrsenje as PotvrdioIzvrsilac,korisnik.IdKorisnika as KorisnikId, korisnik.Ime as KorisnikIme, " +
                                        "korisnik.Prezime as KorisnikPrezime, korisnik.KorisnickoIme as KorisnikKorisnickoIme, " +
                                        "obaveza.Naziv as NazivOb, obaveza.DatumPostavljanja as DatumPostavljanjaOb, obaveza.DatumRokaIzvrsenja as DatumRokaIzvrsenjaOb, " +
                                        "obaveza.Potvrdjena as PotvrdjenaOb, obaveza.Ponistena as PonistenaOb ";
        [Browsable(false)]
        public string DependentObjectID => throw new NotImplementedException();
        [Browsable(false)]
        public List<List<IDomenskiObjekat>> WeakObjects => throw new NotImplementedException();
        [Browsable(false)]
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
                IzvrsilacObaveze izvrsilacObaveze = new IzvrsilacObaveze()
                {
                    Korisnik = new Korisnik()
                    {
                        Id = (int)reader["KorisnikID"],
                        Ime = (string)reader["KorisnikIme"],
                        Prezime = (string)reader["KorisnikPrezime"],
                        KorisnickoIme = (string)reader["KorisnikKorisnickoIme"]
                    },
                    Obaveza = new Obaveza()
                    {
                        IdObaveze = (int)reader["ObavezaId"],
                        Naziv = (string)reader["NazivOb"],
                        DatumPostavljanja = (DateTime)reader["DatumPostavljanjaOb"],
                        DatumRokaIzvrsenja = (DateTime)reader["DatumRokaIzvrsenjaOb"],
                        Potvrdjena = (bool)reader["PotvrdjenaOb"],
                        Ponistena = (bool)reader["PonistenaOb"]
                    },
                    Potvrdjena = (bool)reader["PotvrdioIzvrsilac"]
                };

                result.Add(izvrsilacObaveze);
            }

            return result;
        }

        public string SearchById()
        {
            return $"IdObaveze = {Obaveza.IdObaveze} AND IdKorisnika = {Korisnik.Id}";
        }

        public string SearchWhere(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
