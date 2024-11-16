using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectHospital.Models
{
	public class DataModel
	{
		private string connectionString = "workstation id=ProjectHospital.mssql.somee.com;packet size=4096;user id=ProjectHospital_SQLLogin_1;pwd=5esvvfzqhi;data source=ProjectHospital.mssql.somee.com;persist security info=False;initial catalog=ProjectHospital;TrustServerCertificate=True";

		public ArrayList get(String sql)
		{
			ArrayList dataList = new ArrayList();
			SqlConnection connection = new SqlConnection(connectionString);
			SqlCommand commnad = new SqlCommand(sql, connection);

			connection.Open();


			using (SqlDataReader r = commnad.ExecuteReader())
			{
				while (r.Read())
				{
					ArrayList row = new ArrayList();
					for (int i = 0; i < r.FieldCount; i++) {
						row.Add(xulydulieu(r.GetValue(i).ToString()));
					}
					dataList.Add(row);
				}
			}

			connection.Close();
			return dataList;
		}

		public string xulydulieu(string text)
		{
			String s = text.Replace(",", "&44;");
			s = s.Replace("\"", "&34;");
			s = s.Replace("'", "&39;");
			s = s.Replace("\r", "");
			s = s.Replace("\n", "");
			return s;
		}

	}
}