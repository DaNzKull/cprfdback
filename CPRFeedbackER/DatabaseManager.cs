using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace CPRFeedbackER
{
	public class DataBaseManager : IRepository
	{
		string sqlLiteConnectionString = ConfigurationManager.ConnectionStrings["LocalData"].ConnectionString;
		// string sqlpath = System.IO.Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Fajlcimkezo.sqlite");
		public DataBaseManager()
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory +"App_data\\");
			sqlLiteConnectionString = ConfigurationManager.ConnectionStrings["LocalData"].ConnectionString;
			//"Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFileName=|DataDirectory|Measurement.mdf; Trusted_Connection=yes";
			CreateDatabase();
		}


		public bool AddItem(Measurment mes)
		{
			try
			{
				using (var m_dbConnection = new SqlConnection(sqlLiteConnectionString))
				{
					m_dbConnection.Open();
					var sql = String.Format("INSERT INTO [dbo].[Measurments]([Values],[Name]) " +
									"VALUES('{0}'," +
									"'{1}')", mes.Values, mes.Name);

					SqlCommand command = new SqlCommand(sql, m_dbConnection);
					command.ExecuteNonQuery();
					//m_dbConnection.Close();
					return true;
				}
			}
			catch(Exception ex)
			{
				return false;
			}
		}
		public bool DeleteItem(Measurment mes)
		{
			try
			{
				using (var m_dbConnection = new SqlConnection(sqlLiteConnectionString))
				{
					m_dbConnection.Open();
					var sql = String.Format("DELET FROM [dbo].[Measurments]([Data],[Name]" +
									" WHERE Id={0}", mes.Values, mes.Name);

					SqlCommand command = new SqlCommand(sql, m_dbConnection);
					command.ExecuteNonQuery();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}


		//private  bool TableExists<T>(SQLiteConnection connection)
		//{

		//	SqlCommand cmd = new SqlCommand($"SELECT Measurements FROM sqlite_master WHERE type='table' AND name='{typeof(T).Name}'");
		//	return cmd.ExecuteScalar() != null;

		//}

		public ObservableCollection<Measurment> GetAllItems()
		{
			var measurments = new ObservableCollection<Measurment>();
			using (var m_dbConnection = new SqlConnection(sqlLiteConnectionString))
			{
				m_dbConnection.Open();
				var sql = "SELECT Id,Values, Name FROM [dbo].[Measurments]";

				SqlCommand command = new SqlCommand(sql, m_dbConnection);
				var reader = command.ExecuteReader();
				while (reader.Read())
				{
					measurments.Add(new Measurment
					{
						Id = (int)reader["Id"],
						Values = reader["Values"].ToString(),
						Name = reader["Name"].ToString(),
					});
				}
			}

			return measurments;
		}

		public bool UpdateItem(Measurment mes)
		{
			try
			{
				using (var m_dbConnection = new SqlConnection(sqlLiteConnectionString))
				{
					m_dbConnection.Open();
					var sql = String.Format("UPDATE [dbo].[Measurment]" +

									"[Values]= '{0}' " +
									"[Name]= '{1}' " +
									"WHERE Id ={2}", mes.Values, mes.Name, mes.Id);

					SqlCommand command = new SqlCommand(sql, m_dbConnection);
					command.ExecuteNonQuery();
				}
				return true;
			}
			catch
			{
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
		public void CreateDatabase()

		{
			//if (!File.Exists(@"Data\Meauserement.sqlite"))
			//{
			//	SQConnection.CreateFile(@"Data\Meauserement.sdf");
			//}

			//using (var m_dbConnection = new SqlConnection(sqlLiteConnectionString))
			//{
			//	m_dbConnection.Open();
			//	if (!TableExists<Measurment>(m_dbConnection))
			//	{
			//		var sql = "CREATE TABLE [dbo].[Measurment]" +
			//				  "(" +
			//					"[Id] INT NOT NULL PRIMARY KEY IDENTITY ," +
			//					"[Values] TEXT NULL," +
			//					"[Name] NCHAR(100) NULL" +
			//				  ")"; 

			//		SqlCommand command = new SqlCommand(sql, m_dbConnection);
			//		command.ExecuteNonQuery();
			//	}
			//}

		}
	}
}
