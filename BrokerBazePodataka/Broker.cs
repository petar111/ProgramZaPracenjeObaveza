using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Domen;

namespace BrokerBazePodataka
{
    public class Broker
    {
        
        private SqlConnection connection;
        private SqlTransaction transaction;

        public int UpdateSlozeniObjekat(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"update {objekat.Table} set {objekat.UpdateValues} where {objekat.SearchById()}";
            int rows = command.ExecuteNonQuery();

            foreach (var item in objekat.WeakObjects)
            {
                if(item.Count > 0)
                {
                    DeleteObjects(item[0].Table, $"{item[0].DependentObjectID} = {objekat.ColumnId}");
                    foreach (var insertItem in item)
                    {
                        Insert(insertItem);
                    }
                }
            }

            foreach (var item in objekat.AssociativeObjects)
            {
                if (item.Count > 0)
                {
                    DeleteObjects(item[0].Table, $"{objekat.SearchId} = {objekat.ColumnId}");
                    foreach (var insertItem in item)
                    {
                        Insert(insertItem);
                    }
                }
            }

            return rows;
        }

        public void RefreshDatabase()
        {
        }

        public IDomenskiObjekat SearchSlozeniObjekat(string criteria, IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select distinct {objekat.SearchColumns} from {objekat.Table} {objekat.Join} {criteria}";
            SqlDataReader reader = command.ExecuteReader();

            List<IDomenskiObjekat> result = objekat.GetReaderResult(reader);

            reader.Close();

            if (result.Count != 1)
            {
                throw new Exception("Razlicito od jednog sloga!!!!");
            }

            foreach (var item in objekat.WeakObjects)
            {
                IDomenskiObjekat weakObject = item[0];

                List<IDomenskiObjekat> weakObjectList = SearchMod($"where {weakObject.DependentObjectID} = {objekat.ColumnId}", weakObject);

                result[0].FillWeakObjects(weakObjectList);
            }

            foreach (var item in objekat.AssociativeObjects)
            {
                IDomenskiObjekat associativeObject = item[0];

                List<IDomenskiObjekat> associativeObjectList = SearchJoin(criteria, associativeObject);

                result[0].FillAssociativeObjects(associativeObjectList);
            }

            

            

            

            return result[0];
        }

        private void DeleteObjects(string table, string whereCriteria)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"delete from {table} where {whereCriteria}";
            command.ExecuteNonQuery();
        }

        public Broker()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
        }

        public List<IDomenskiObjekat> VratiSve(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select * from {objekat.Table} {objekat.Join}";
            SqlDataReader reader = command.ExecuteReader();

            List<IDomenskiObjekat> result = objekat.GetReaderResult(reader);

            reader.Close();

            return result;
        }

        public int DeleteObject(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"delete from {objekat.Table} where {objekat.SearchId} = {objekat.ColumnId}";
            return command.ExecuteNonQuery();
        }

        public void OtvoriKonekciju()
        {
            connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            connection.Close();
        }

        public void PokreniTransakciju()
        {
            transaction = connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }


        public List<IDomenskiObjekat> Search(string criteria, IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select * from {objekat.Table} {objekat.SearchWhere(criteria)}";
            SqlDataReader reader = command.ExecuteReader();

            List < IDomenskiObjekat > result = objekat.GetReaderResult(reader);

            reader.Close();

            return result;
        }

        public IDomenskiObjekat SearchById(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select * from {objekat.Table} WHERE {objekat.SearchById()}";
            SqlDataReader reader = command.ExecuteReader();

            List<IDomenskiObjekat> result = objekat.GetReaderResult(reader);
            if(result.Count > 1)
            {
                throw new Exception("Object is not unique");
            }
            if(result.Count == 0)
            {
                return null;
            }

            reader.Close();

            return result[0];
        }

        public List<IDomenskiObjekat> SearchMod(string criteria, IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select * from {objekat.Table} {criteria}";
            SqlDataReader reader = command.ExecuteReader();

            List<IDomenskiObjekat> result = objekat.GetReaderResult(reader);

            reader.Close();

            return result;
        }

        public List<IDomenskiObjekat> SearchJoin(string criteria, IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select distinct {objekat.SearchColumns} from {objekat.Table} {objekat.Join} {criteria}";
            SqlDataReader reader = command.ExecuteReader();

            List<IDomenskiObjekat> result = objekat.GetReaderResult(reader);

            reader.Close();

            return result;
        }

        public int SearchMaxIdForObject(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"select MAX({objekat.SearchId}) from {objekat.Table}";
            object resultFromDatabase = command.ExecuteScalar();

            if(resultFromDatabase is DBNull)
            {
                throw new Exception("Database is empty");
            }

            int result = (int)resultFromDatabase;

            return result;
        }

        public object Insert(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"insert into {objekat.Table} output INSERTED.{objekat.SearchId} values({objekat.InsertValues})";
            return command.ExecuteScalar();
        }

        public int UpdateObject(IDomenskiObjekat objekat)
        {
            SqlCommand command = new SqlCommand();
            command.Transaction = transaction;
            command.Connection = connection;
            command.CommandText = $"update {objekat.Table} set {objekat.UpdateValues} where {objekat.SearchById()}";
            return command.ExecuteNonQuery();
        }

    }
}
