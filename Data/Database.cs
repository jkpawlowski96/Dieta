using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data
{
    public class Database
    {
        MySqlConnection connect; // zmienna referencja pozwalająca na nawiązanie połączenia z BD

        MySqlDataReader read; // zmienna referencyjna wykonująca zapytanie oraz pobierająca odpowiedź z bazy

        public Database()
        {
            connect = new MySqlConnection();

            connect.ConnectionString = "server=sql.jkpawlowski.nazwa.pl;user=jkpawlowski_jakub;password=mGjRD9hDT5X6GMR;database=jkpawlowski_dieta";
        }
        public List<string> Query(string procedure, List<string>parameters)
        {
            string query = "CALL `"+ procedure + "`(";
            for (int i=0;i<parameters.Count;i++)
            {
                if (i!=0) query += ", ";
                query += "'"+parameters[i]+"'";
            }
            query += ");";
            connect.Open();
            MySqlCommand comand = new MySqlCommand(query, connect);

            try
            {
                // wykonaj zapytanie
                read = comand.ExecuteReader();

                var result = new List<string>();

                // czytaj odpowiedz
                while (read.Read())
                {
                    // rzutowanie wyniku na krotke
                    IDataRecord record = ((IDataRecord)read);

                    
                    
                    // FieldCount zwraca liczbę kolumn
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        result.Add(record[i].ToString());
                    }
                   
                }
                read.Close();
                connect.Close();
                return result;
            }
            catch (Exception ex)
            {
                var ret = new List<string>();
                ret.Add(ex.ToString());
                connect.Close();
                return ret ;
            }
        }
    }
}
