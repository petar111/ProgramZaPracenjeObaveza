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
    public class Obaveza : IDomenskiObjekat
    {
        [Browsable(false)]
        public int IdObaveze { get; set; }

        public string Naziv { get; set; }

        public DateTime DatumPostavljanja { get; set; }

        public DateTime DatumRokaIzvrsenja { get; set; }

        public bool Potvrdjena { get; set; }

        public bool Ponistena { get; set; }
        [Browsable(false)]
        public string PotvrdjenaInsert { get { return (Potvrdjena ? "1" : "0"); } }
        [Browsable(false)]
        public string PonistenaInsert { get { return (Ponistena ? "1" : "0"); } }

        public string Postavio { get { return PostavioObavezu.KorisnickoIme; } }

        public TipObaveze TipObaveze { get; set; }

        [Browsable(false)]
        public Korisnik PostavioObavezu { get; set; }

        [Browsable(false)]
        public List<Korisnik> Izvrsavaju { get; set; }

        [Browsable(false)]
        public List<StavkaObaveze> StavkeObaveze { get; set; }

        [Browsable(false)]
        public List<IzvrsilacObaveze> IzvrsiociObaveze { get; set; }

        [Browsable(false)]
        public string NazivPostavio { get { return PostavioObavezu.KorisnickoIme; } }
        [Browsable(false)]
        public string Table => "Obaveza";
        [Browsable(false)]
        public string InsertValues => $"'{Naziv}','{DatumPostavljanja.ToShortDateString()}','{DatumRokaIzvrsenja.ToShortDateString()}',0,0,{PostavioObavezu.Id},{TipObaveze.IdTipaObaveze}";
        [Browsable(false)]
        public string UpdateValues => $"Naziv = '{Naziv}', DatumPostavljanja = '{DatumPostavljanja.ToShortDateString()}', DatumRokaIzvrsenja = '{DatumRokaIzvrsenja.ToShortDateString()}', Potvrdjena = {PotvrdjenaInsert}, Ponistena = {PonistenaInsert}, IdKorisnika = {PostavioObavezu.Id}, IdTipaObaveze = {TipObaveze.IdTipaObaveze}";
        [Browsable(false)]
        public string Join => "JOIN Korisnik korisnik ON obaveza.IdKorisnika = korisnik.IdKorisnika " +
                                    "JOIN TipObaveze tipObaveze ON obaveza.IdTipaObaveze = tipObaveze.IdTipaObaveze " +
                                        "JOIN IzvrsilacObaveze izvrsilacObaveze ON obaveza.IdObaveze = izvrsilacObaveze.IdObaveze";
        [Browsable(false)]
        public string SearchId => "IdObaveze";
        [Browsable(false)]
        public object ColumnId => IdObaveze;

        [Browsable(false)]
        public string SearchColumns => "obaveza.IdObaveze as IdOb, obaveza.Naziv as NazivOb, obaveza.DatumPostavljanja as DatumPostavljanjaOb, obaveza.DatumRokaIzvrsenja as DatumRokaIzvrsenjaOb, " +
                                        "obaveza.Potvrdjena as PotvrdjenaOb, obaveza.Ponistena as PonistenaOb, " +
                                        "korisnik.IdKorisnika as IdKor, korisnik.Ime as ImeKor, korisnik.Prezime as PrezimeKor, korisnik.KorisnickoIme as KorisnickoImeKor, " +
                                        "tipObaveze.IdTipaObaveze as IdTipOb, tipObaveze.NazivTipaObaveze as NazivTipOb," +
                                        "izvrsilacObaveze.IdObaveze as IdObavezeIzvrsioca";

        [Browsable(false)]
        public List<List<IDomenskiObjekat>> WeakObjects { get => new List<List<IDomenskiObjekat>>() { StavkeObaveze.Cast<IDomenskiObjekat>().ToList() }; }

        [Browsable(false)]
        public string DependentObjectID => throw new NotImplementedException();
        [Browsable(false)]
        public string AssociativeTable => throw new NotImplementedException();

        [Browsable(false)]
        public List<List<IDomenskiObjekat>> AssociativeObjects => new List<List<IDomenskiObjekat>>() { IzvrsiociObaveze.Cast<IDomenskiObjekat>().ToList() };

        public void FillAssociativeObjects(List<IDomenskiObjekat> associativeObjectList)
        {
            if (associativeObjectList.Count > 0)
            {
                if (associativeObjectList[0] is IzvrsilacObaveze)
                {
                    this.IzvrsiociObaveze = associativeObjectList.Cast<IzvrsilacObaveze>().ToList();
                    Izvrsavaju = new List<Korisnik>();
                    foreach (var item in IzvrsiociObaveze)
                    {
                        Izvrsavaju.Add(item.Korisnik);
                    }
                }
            }
        }

        public void FillWeakObjects(List<IDomenskiObjekat> weakObjectList)
        {
            try
            {
                this.StavkeObaveze = weakObjectList.Cast<StavkaObaveze>().ToList();
            }
            catch (InvalidCastException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }


            //if (weakObjectList.Count > 0)
            //{
            //    if (weakObjectList[0] is StavkaObaveze)
            //    {
            //        this.StavkeObaveze = weakObjectList.Cast<StavkaObaveze>().ToList();
            //    }
            //}
        }

        public List<IDomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<IDomenskiObjekat> result = new List<IDomenskiObjekat>();

            while (reader.Read())
            {
                Obaveza obaveza = new Obaveza()
                {
                    IdObaveze = (int)reader["IdOb"],
                    Naziv = (string)reader["NazivOb"],
                    DatumPostavljanja = (DateTime)reader["DatumPostavljanjaOb"],
                    DatumRokaIzvrsenja = (DateTime)reader["DatumRokaIzvrsenjaOb"],
                    Potvrdjena = (bool)reader["PotvrdjenaOb"],
                    Ponistena = (bool)reader["PonistenaOb"],
                    PostavioObavezu = new Korisnik()
                    {
                        Id = (int)reader["IdKor"],
                        Ime = (string)reader["ImeKor"],
                        Prezime = (string)reader["PrezimeKor"],
                        KorisnickoIme = (string)reader["KorisnickoImeKor"]
                    },
                    TipObaveze = new TipObaveze()
                    {
                        IdTipaObaveze = (int)reader["IdTipOb"],
                        Naziv = (string)reader["NazivTipOb"]
                    }
                };

                result.Add(obaveza);
            }

            return result;
        }

        public string SearchById()
        {
            return $"IdObaveze = {IdObaveze}";
        }

        public string SearchWhere(string criteria)
        {
            throw new NotImplementedException();
        }

        public Korisnik FindIzvrsilac(Korisnik izvrsilac)
        {
            foreach (var item in Izvrsavaju)
            {
                if (izvrsilac.Id == item.Id)
                    return item;
            }

            return null;
        }
    }
}
