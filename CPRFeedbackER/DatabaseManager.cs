using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;

namespace CPRFeedbackER {

    public class DataBaseManager {

        //// kell egy coonection string, ami az app.configban van
        //// <connectionStrings>
        ////  <add name = "LocalData" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Measurement.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
        //// </connectionStrings>
        private string sqlConnectionString;

        public DataBaseManager() {
            //a app-config connectionstringjében van egy LocalData változó, amit paraméterezünk fel
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory + "App_data\\");
            sqlConnectionString = ConfigurationManager.ConnectionStrings["LocalData"].ConnectionString;
            // "Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFileName=|DataDirectory|Measurement.mdf; Trusted_Connection=yes";
            // CreateDatabase();
        }

        /// <summary>
        /// Egy rekordot adunk a Measurement táblához. Az Id mező autoincrement, nem kell itt megadni
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public bool AddItem(Measurement mes) {
            try {
                using (var m_dbConnection = new SqlConnection(sqlConnectionString)) {
                    m_dbConnection.Open();
                    var sql = String.Format("INSERT INTO [dbo].[Measurements]([Values],[Name],[Date], [Comment]) " +
                                    "VALUES('{0}'," +
                                    "'{1}'," +
                                    "'{2}'," +
                                    "'{3}')", mes.Values, mes.Name, mes.Date, mes.Comment);

                    SqlCommand command = new SqlCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    //m_dbConnection.Close();
                    return true;
                }
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Egy rekord törlése. A rekordot az Id megadásával jelöljük ki
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public bool DeleteItem(Measurement mes) {
            try {
                using (var m_dbConnection = new SqlConnection(sqlConnectionString)) {
                    m_dbConnection.Open();
                    var sql = String.Format("DELETE FROM [dbo].[Measurements] " +
                                    " WHERE Id={0}", mes.Values, mes.Name);

                    SqlCommand command = new SqlCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
                return true;
            } catch {
                return false;
            }
        }

        //private  bool TableExists<T>(SQLiteConnection connection)
        //{
        //	SqlCommand cmd = new SqlCommand($"SELECT Measurement FROM sqlite_master WHERE type='table' AND name='{typeof(T).Name}'");
        //	return cmd.ExecuteScalar() != null;

        //}

        /// <summary>
        /// Az összes rekordot kihozza az adatbázisból
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Measurement> GetAllItems() {
            //Az ObservableCollection előnye, hogy automatikusan frissíti a pl. gridet
            var Measurements = new ObservableCollection<Measurement>();
            try {
                using (var m_dbConnection = new SqlConnection(sqlConnectionString)) {
                    m_dbConnection.Open();
                    var sql = "SELECT [Id],[Values],[Name],[Date],[Comment] FROM [dbo].[Measurements]";

                    SqlCommand command = new SqlCommand(sql, m_dbConnection);
                    var reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Measurements.Add(new Measurement {
                            Id = (int)reader["Id"],
                            Values = reader["Values"].ToString(),
                            Name = reader["Name"].ToString(),
                            Date = reader["Date"].ToString(),
                            Comment = reader["Comment"].ToString(),
                        });
                    }
                }
                return Measurements;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            return Measurements;
        }

        /// <summary>
        /// Egy rekord azonosítva az Id által
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Measurement> GetItemById(int id) {
            var Measurements = new List<Measurement>();
            using (var m_dbConnection = new SqlConnection(sqlConnectionString)) {
                m_dbConnection.Open();
                var sql = String.Format("SELECT [Id], [Values], [Name], [Date], [Comment] FROM [dbo].[Measurements] WHERE  Id={0}", id);

                SqlCommand command = new SqlCommand(sql, m_dbConnection);
                var reader = command.ExecuteReader();
                while (reader.Read()) {
                    Measurements.Add(new Measurement {
                        Id = (int)reader["Id"],
                        Values = reader["Values"].ToString(),
                        Name = reader["Name"].ToString(),
                        Date = reader["Date"].ToString(),
                        Comment = reader["Comment"].ToString(),
                    });
                }
            }

            return Measurements;
        }

        public Measurement GetLastItem() {
            var Measurement = new Measurement();
            using (var m_dbConnection = new SqlConnection(sqlConnectionString)) {
                m_dbConnection.Open();
                var sql = String.Format("SELECT MAX (Id) FROM [dbo].[Measurements]");
                SqlCommand command = new SqlCommand(sql, m_dbConnection);
                var reader = command.ExecuteScalar();

                Measurement = new Measurement {
                    Id = (int)reader
                };
            }
            List<Measurement> m = GetItemById(Measurement.Id);
            if (m.Count > 0) {
                return m[0];
            }
            return null;
        }

        /// <summary>
        /// Egy rekord frissítése. Azonosító az Id
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public bool UpdateItem(Measurement mes) {
            try {
                using (var m_dbConnection = new SqlConnection(sqlConnectionString)) {
                    m_dbConnection.Open();
                    var sql = String.Format("UPDATE [dbo].[Measurements]" +

                                    "[Values]= '{0}' " +
                                    "[Name]= '{1}' " +
                                    "WHERE Id ={2}", mes.Values, mes.Name, mes.Id);
                    SqlCommand command = new SqlCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                }
                return true;
            } catch {
                return false;
            }
        }

        //public  void Import(ObservableCollection<Cimke> cimkek)
        //{
        //	using (var connection = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), sqlpath))
        //	{
        //		connection.BeginTransaction();
        //		try
        //		{
        //			connection.DeleteAll<Cimke>();
        //			foreach (var cimke in cimkek)
        //			{
        //				connection.Insert(cimke);
        //			}
        //		}
        //		catch
        //		{
        //			connection.Rollback();
        //			throw;
        //		}

        //	}
        //}
        //public void CreateDatabase()

        //{
        //if (!File.Exists(@"Data\Meauserement.sqlite"))
        //{
        //	SQConnection.CreateFile(@"Data\Meauserement.sdf");
        //}

        //using (var m_dbConnection = new SqlConnection(sqlLiteConnectionString))
        //{
        //	m_dbConnection.Open();
        //	if (!TableExists<Measurement>(m_dbConnection))
        //	{
        //		var sql = "CREATE TABLE [dbo].[Measurement]" +
        //				  "(" +
        //					"[Id] INT NOT NULL PRIMARY KEY IDENTITY ," +
        //					"[Values] TEXT NULL," +
        //					"[Name] NCHAR(100) NULL" +
        //				  ")";

        //		SqlCommand command = new SqlCommand(sql, m_dbConnection);
        //		command.ExecuteNonQuery();
        //	}
        //}

        //}
    }
}