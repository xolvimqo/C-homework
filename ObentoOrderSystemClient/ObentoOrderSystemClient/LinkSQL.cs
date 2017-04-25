using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ObentoOrderSystemClient
{
    class LinkSQL
    {
        public int getObentoPrice(string storeName, string obentoName) {
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            string strPrice = "";

            sqlCnct.Open();
            strSQL = "select obentoPrice from obentoTable as o inner join storeTable as s on o.storeID = s.storeID where s.storeName = '" 
                + storeName + "' and o.obentoName = '" 
                + obentoName + "'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                strPrice = sqlReader["obentoPrice"].ToString();
            }

            sqlReader.Close();
            sqlCnct.Close();

            return int.Parse(strPrice);
        }
    }
}
