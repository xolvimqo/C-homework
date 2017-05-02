using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace ObentoOrderSystemClient
{
    class LinkSQL
    {
        string strSQL = "";
        string strPrice = "";

        public string getObentoPrice(string storeName, string obentoName) {
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
			scsb.DataSource = @".";
			//scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
			scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

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

            return strPrice;
        }

        public int getOrderLength()
        {
            int length = 0;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
			scsb.DataSource = @".";
			//scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
			scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select count(*) as orderLength from orderTable";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows) {
                while (sqlReader.Read())
                {
                    length = int.Parse(sqlReader["orderLength"].ToString());
                }
            }

            sqlReader.Close();
            sqlCnct.Close();
            
            return length;
        }

        public int getStudentID(string studentName)
        {
            int stuID = 0;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
			scsb.DataSource = @".";
			//scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
			scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select * from studentTable where stuName = '"
                + studentName + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                stuID = int.Parse(sqlReader["stuID"].ToString());
            }

            sqlReader.Close();
            sqlCnct.Close();

            return stuID;
        }

        public int getStoreID(string store_Name)
        {
            int store_ID = 0; ;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select * from storeTable where storeName = '"
                + store_Name + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                store_ID = int.Parse(sqlReader["storeID"].ToString());
            }

            sqlReader.Close();
            sqlCnct.Close();

            return store_ID;
        }

        public int getObentoID(string obentoName)
        {
            int obentoID = 0;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
			scsb.DataSource = @".";
			//scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
			scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select * from obentoTable where obentoName = '"
                + obentoName + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                obentoID = int.Parse(sqlReader["obentoID"].ToString());
            }

            sqlReader.Close();
            sqlCnct.Close();

            return obentoID;
        }

        public string getStoreName(int store_ID)
        {
            string store_Name = "";

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select * from storeTable where storeID = "
                + store_ID + ";";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                store_Name = sqlReader["storeName"].ToString();
            }

            sqlReader.Close();
            sqlCnct.Close();

            return store_Name;
        }

        public int writeOrder(int student_ID, int obento_ID, int quantity)
        {
            int order_ID = this.getOrderLength() + 1;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
			scsb.DataSource = @".";
			//scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
			scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "insert into orderTable values (@orderID, @orderDate, @studentID, @obentoID, @quantity, @paymentState)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@orderID", order_ID);
            sqlCmd.Parameters.AddWithValue("@orderDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@studentID", student_ID);
            sqlCmd.Parameters.AddWithValue("@obentoID", obento_ID);
            sqlCmd.Parameters.AddWithValue("@quantity", quantity);
            sqlCmd.Parameters.AddWithValue("@paymentState", 0); // only value = 1 is paid
            int row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int changePaymentState(string student_Name, int paymentState)
        {
            int row = 0;
            int student_ID = this.getStudentID(student_Name);
            string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            //strSQL = "insert into orderTable values (@orderID, @orderDate, @studentID, @obentoID, @quantity, @paymentState)";
            strSQL = "update orderTable set paid=@paymentState where cast(orderDate as date) = '" + sqlFormattedDate + "' and stuID = " + student_ID.ToString() + ";";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@paymentState", paymentState); // only value = 1 is paid
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int setEnv(string classRoom, string store_Name)
        {
            int row = 0;
            int env_ID = this.getEnvLength() + 1;
            int store_ID = this.getStoreID(store_Name);
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "insert into environmentTable values (@envID, @envDate, @classRoom, @storeID)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@envID", env_ID);
            sqlCmd.Parameters.AddWithValue("@envDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@classRoom", classRoom);
            sqlCmd.Parameters.AddWithValue("@storeID", store_ID);

            Console.WriteLine();
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int getEnvLength()
        {
            int length = 0;

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select count(*) as envLength from environmentTable";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows) {
                while (sqlReader.Read())
                {
                    length = int.Parse(sqlReader["envLength"].ToString());
                }
            }

            sqlReader.Close();
            sqlCnct.Close();

            return length;
        }

        public string getEnvStoreID(string classRoom)
        {
            string returnString = "";
            string sqlFormattedDateNow = DateTime.Now.ToString("yyyy-MM-dd");

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            sqlCnct.Open();
            strSQL = "select storeID from environmentTable where cast(envDate as date) = '" 
                + sqlFormattedDateNow + "' and classRoom = '" + classRoom + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    returnString = sqlReader["storeID"].ToString();
                }
            }

            sqlReader.Close();
            sqlCnct.Close();

            return returnString;
        }

        public ArrayList getMenuArrayList(string storeName)
        {
            // To collect strings of obento informations from database
            ArrayList obentoArrayList = new ArrayList();

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            sqlCnct.Open();
            strSQL = "select o.obentoName, o.obentoPrice from storeTable as s inner join obentoTable as o on s.storeID = o.storeID where storeName = '"
                + storeName + "'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                //Console.WriteLine(sqlReader["obentoName"] + " " + sqlReader["obentoPrice"]);
                obentoArrayList.Add(sqlReader["obentoName"] + " " + sqlReader["obentoPrice"]);
                //cbObendoName.Items.Add(sqlReader["obentoName"].ToString());
            }

            sqlReader.Close();
            sqlCnct.Close();

            return obentoArrayList;
        }

        public ArrayList loadUnpaidOrder(string class_Room)
        {
            ArrayList orderArrayList = new ArrayList();

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            sqlCnct.Open();
            strSQL = "select * from orderTable as o inner join studentTable as s on o.stuID = s.stuId "
                + "inner join obentoTable as ob on o.obentoID = ob.obentoID where cast(o.orderDate as date) = '"
                + DateTime.Now.ToString("yyyy-MM-dd") + "' and s.classRoom = '" + class_Room + "' and o.paid <> 1;";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows) {
                while (sqlReader.Read())
                {
                    
                    orderArrayList.Add(sqlReader["stuName"] + " " + sqlReader["obentoName"] + " " + sqlReader["obentoPrice"]
                        + " * " + sqlReader["quantity"]);
                }
            }

            sqlReader.Close();
            sqlCnct.Close();

            return orderArrayList;
        }

        public ArrayList loadPaidOrder(string class_Room)
        {
            ArrayList orderArrayList = new ArrayList();

            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            string strSQL = "";
            sqlCnct.Open();
            strSQL = "select * from orderTable as o inner join studentTable as s on o.stuID = s.stuId "
                + "inner join obentoTable as ob on o.obentoID = ob.obentoID where cast(o.orderDate as date) = '"
                + DateTime.Now.ToString("yyyy-MM-dd") + "' and s.classRoom = '" + class_Room + "' and o.paid <> 0;";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {

                    orderArrayList.Add(sqlReader["stuName"] + " " + sqlReader["obentoName"] + " " + sqlReader["obentoPrice"]
                        + " * " + sqlReader["quantity"]);
                }
            }

            sqlReader.Close();
            sqlCnct.Close();

            return orderArrayList;
        }
    }
}
