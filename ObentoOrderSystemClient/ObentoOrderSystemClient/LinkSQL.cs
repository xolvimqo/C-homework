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

        public int isOnDuty(string student_Name)
        {
            int isOnDuty = 0;
            string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd");

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select * from studentTable where stuName = '"
                + student_Name + "' and cast(dutyDate as date) = '" + sqlFormattedDate + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows) {
                while (sqlReader.Read())
                {
                    isOnDuty = int.Parse(sqlReader["isOnDuty"].ToString());
                }
            }

            sqlReader.Close();
            sqlCnct.Close();

            return isOnDuty;
        }

        public void setDuty(string student_Name, int i)
        {
            int student_ID = this.getStudentID(student_Name);
            string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd");
            int row = 0;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());
            
            sqlCnct.Open();
            strSQL = "update studentTable set isOnDuty=@dutyState, dutyDate='" + sqlFormattedDate + "' where stuID = " + student_ID.ToString() + ";";
            if (student_Name == "all")
            {
                strSQL = "update studentTable set isOnDuty=@dutyState, dutyDate='" + sqlFormattedDate + "';";
            }
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@dutyState", i);

            row = sqlCmd.ExecuteNonQuery();
            Console.WriteLine(row);

            sqlCnct.Close();
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

        public int setSubmitState(string classroom, string inputState)
        {
            int row = 0;
            int env_ID = this.getEnvLength() + 1;
            string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd");

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "update environmentTable set submitted=@State where classRoom = '" + classroom + "' and cast(envDate as date) = '" + sqlFormattedDate + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@State", inputState); // only value = 1 is paid
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public string getSubmitState()
        {
            string state = "false";

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
            strSQL = "select * from environmentTable where cast(envDate as date) = '" + sqlFormattedDate + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows)
            {
                while (sqlReader.Read())
                {
                    state = sqlReader["submitted"].ToString();
                }
            }
            sqlReader.Close();
            sqlCnct.Close();

            return state;
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
            strSQL = "insert into environmentTable values (@envID, @envDate, @classRoom, @storeID, @submitted)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@envID", env_ID);
            sqlCmd.Parameters.AddWithValue("@envDate", DateTime.Now);
            sqlCmd.Parameters.AddWithValue("@classRoom", classRoom);
            sqlCmd.Parameters.AddWithValue("@storeID", store_ID);
            sqlCmd.Parameters.AddWithValue("@submitted", "false");

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

        public int getEnvLength(DateTime datetime)
        {
            int length = 0;
            string sqlFormattedDateNow = datetime.ToString("yyyy-MM-dd");
            
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select count(*) as envLength from environmentTable where cast(envDate as date) = '"
                + sqlFormattedDateNow + "'";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.HasRows)
            {
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

        public int deleteOrder(string classroom)
        {
            int row = 0;
            string sqlFormattedDateNow = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "delete from orderTable where cast(orderDate as date) = '" + sqlFormattedDateNow 
                + "' and stuID in (select stuID from studentTable where classRoom = '" + classroom + "');";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int addStudent(int ID, string name, string classroom)
        {
            int row = 0;
            
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "insert into studentTable values (@stuID, @cr, @stuName, @dutyStatus, @dutyDate)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@stuID", ID);
            sqlCmd.Parameters.AddWithValue("@cr", classroom);
            sqlCmd.Parameters.AddWithValue("@stuName", name);
            sqlCmd.Parameters.AddWithValue("@dutyStatus", 0);
            sqlCmd.Parameters.AddWithValue("@dutyDate", DateTime.Now);

            Console.WriteLine();
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int deleteStudent(int ID)
        {
            int row = 0;
            string sqlFormattedDateNow = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "delete from studentTable where stuID = @ID";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@ID", ID);
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public string getImgName(string obentoName, string storeName)
        {
            string imgName = "";

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "select * from obentoTable as o inner join storeTable as s on o.storeID = s.storeID where o.obentoName = '"
                + obentoName + "' and s.storeName = '" + storeName + "';";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                imgName = sqlReader["picName"].ToString();
            }

            sqlReader.Close();
            sqlCnct.Close();

            return imgName;
        }

        public int addStore(int ID, string name, string tel, string address, string ps)
        {
            int row = 0;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "insert into storeTable values (@storeID, @storeName, @tel, @address, @PS, NULL, NULL)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@storeID", ID);
            sqlCmd.Parameters.AddWithValue("@storeName", name);
            sqlCmd.Parameters.AddWithValue("@tel", tel);
            sqlCmd.Parameters.AddWithValue("@address", address);
            sqlCmd.Parameters.AddWithValue("@PS", ps);

            Console.WriteLine();
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int deleteStore(int ID)
        {
            int row = 0;
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "delete from storeTable where storeID = @ID";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@ID", ID);
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int addObento(int ID, string name, int price, int storeID, string picName)
        {
            int row = 0;

            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "insert into obentoTable values (@obentoID, @obentoName, @price, @storeID, @picName)";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@obentoID", ID);
            sqlCmd.Parameters.AddWithValue("@obentoName", name);
            sqlCmd.Parameters.AddWithValue("@price", price);
            sqlCmd.Parameters.AddWithValue("@storeID", storeID);
            sqlCmd.Parameters.AddWithValue("@picName", picName);

            Console.WriteLine();
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }

        public int deleteObento(int ID)
        {
            int row = 0;
            SqlConnectionStringBuilder scsb;
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            //scsb.DataSource = @"XOLVIMQO-PC\SQLEXPRESS";
            scsb.InitialCatalog = "Obento";
            scsb.IntegratedSecurity = true;
            SqlConnection sqlCnct = new SqlConnection(scsb.ToString());

            sqlCnct.Open();
            strSQL = "delete from obentoTable where obentoID = @ID";
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlCnct);
            sqlCmd.Parameters.AddWithValue("@ID", ID);
            row = sqlCmd.ExecuteNonQuery();
            sqlCnct.Close();

            return row;
        }
    }
}
