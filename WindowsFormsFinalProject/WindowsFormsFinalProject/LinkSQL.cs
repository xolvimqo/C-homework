using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsFinalProject
{   
    class LinkSQL
    {
        List<string> sqlStrings = new List<string>();
        List<int> sqlIntegers = new List<int>();

        public LinkSQL() { }

        public List<int> GetWorkHistoryID(string email)
        {
            sqlIntegers = new List<int>();

            string sqlQuery = "SELECT wh.work_history_id " +
                    "FROM [dbo].[tbl_work_history] AS wh " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON wh.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlIntegers = new LinkSQL().GetSQLIntegers(sqlQuery, 1);

            return sqlIntegers;
        }

        public List<string> GetCompany(string email)
        {
            sqlStrings = new List<string>();

            string sqlQuery = "SELECT wh.company " +
                    "FROM [dbo].[tbl_work_history] AS wh " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON wh.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);

            return sqlStrings;
        }

        public List<string> GetPosition(string email)
        {
            sqlStrings = new List<string>();

            string sqlQuery = "SELECT wh.position " +
                    "FROM [dbo].[tbl_work_history] AS wh " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON wh.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);

            return sqlStrings;
        }

        public List<int> GetYears(string email)
        {
            sqlIntegers = new List<int>();

            string sqlQuery = "SELECT wh.years " +
                    "FROM [dbo].[tbl_work_history] AS wh " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON wh.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlIntegers = new LinkSQL().GetSQLIntegers(sqlQuery, 1);

            return sqlIntegers;
        }

        public List<int> GetEducationID(string email)
        {
            sqlIntegers = new List<int>();

            string sqlQuery = "SELECT e.education_id " +
                    "FROM [dbo].[tbl_education] AS e " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON e.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlIntegers = new LinkSQL().GetSQLIntegers(sqlQuery, 1);

            return sqlIntegers;
        }

        public List<string> GetSchool(string email)
        {
            sqlStrings = new List<string>();

            string sqlQuery = "SELECT e.school " +
                    "FROM [dbo].[tbl_education] AS e " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON e.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);

            return sqlStrings;
        }

        public List<string> GetProgram(string email)
        {
            sqlStrings = new List<string>();

            string sqlQuery = "SELECT e.program " +
                    "FROM [dbo].[tbl_education] AS e " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON e.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);

            return sqlStrings;
        }

        public List<string> GetDegree(string email)
        {
            sqlStrings = new List<string>();

            string sqlQuery = "SELECT e.degree " +
                    "FROM [dbo].[tbl_education] AS e " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON e.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);

            return sqlStrings;
        }

        public string GetFirstName(string email)
        {
            sqlStrings = new List<string>();
            string firstName = "";
            string sqlQuery = "SELECT ui.first_name " +
                    "FROM [dbo].[tbl_account] AS a " +
                    "JOIN [dbo].[tbl_user_info] AS ui " +
                    "ON ui.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);
            if (sqlStrings.Count > 0)
            {
                firstName = sqlStrings[0];
            }
            return firstName;
        }

        public string GetLastName(string email)
        {
            sqlStrings = new List<string>();
            string lastName = "";
            string sqlQuery = "SELECT ui.last_name " +
                    "FROM [dbo].[tbl_account] AS a " +
                    "JOIN [dbo].[tbl_user_info] AS ui " +
                    "ON ui.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);
            if (sqlStrings.Count > 0)
            {
                lastName = sqlStrings[0];
            }
            return lastName;
        }

        public string GetPhoneNumber(string email)
        {
            sqlStrings = new List<string>();
            string phoneNumber = "";
            string sqlQuery = "SELECT ui.phone_number " +
                    "FROM [dbo].[tbl_account] AS a " +
                    "JOIN [dbo].[tbl_user_info] AS ui " +
                    "ON ui.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlStrings = GetSQLStrings(sqlQuery, 1);
            if (sqlStrings.Count > 0)
            {
                phoneNumber = sqlStrings[0];
            }
            return phoneNumber;
        }

        public int GetAccountID (string email)
        {
            int id = 0;
            string sqlQuery = "SELECT account_id FROM [dbo].[tbl_account] " +
                "WHERE email = '" + email + "'";
            id = new LinkSQL().GetSQLIntegers(sqlQuery, 1)[0];
            return id;
        }

        public int GetUserNumber()
        {
            int num = 0;
            string sqlQuery = "SELECT COUNT(account_id) FROM [dbo].[tbl_account]";
            num = new LinkSQL().GetSQLIntegers(sqlQuery, 1)[0];
            return num;
        }

        public int DeleteWorkHistory(string company, string position, int years, int account_id)
        {
            int row = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM [dbo].[tbl_work_history] " +
                        "WHERE [company] = @company " +
                        "AND [position] = @position " +
                        "AND [years] = @years " +
                        "AND [fk_account_id] = @fk_account_id";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    command.Parameters.AddWithValue("@company", company);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@years", years);
                    command.Parameters.AddWithValue("@fk_account_id", account_id);
                    row = command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return row;
        }

        public int DeleteEducationInfo(string school, string program, string degree, int account_id)
        {
            int row = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = "DELETE FROM [dbo].[tbl_education] " +
                        "WHERE [school] = @school " +
                        "AND [program] = @program " +
                        "AND [degree] = @degree " +
                        "AND [fk_account_id] = @fk_account_id";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    command.Parameters.AddWithValue("@school", school);
                    command.Parameters.AddWithValue("@program", program);
                    command.Parameters.AddWithValue("@degree", degree);
                    command.Parameters.AddWithValue("@fk_account_id", account_id);
                    row = command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return row;
        }

        public int UpdateUserInfo(string first_name, string last_name, string phone_number, int account_id)
        {
            int row = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = "UPDATE [dbo].[tbl_user_info] " +
                        "SET [first_name] = @first_name, [last_name] = @last_name, [phone_number] = @phone_number " +
                        "WHERE [fk_account_id] = @fk_account_id";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    
                    command.Parameters.AddWithValue("@first_name", first_name);
                    command.Parameters.AddWithValue("@last_name", last_name);
                    command.Parameters.AddWithValue("@phone_number", phone_number);
                    command.Parameters.AddWithValue("@fk_account_id", account_id);
                    row = command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return row;
        }

        public int InsertWorkHistory(string company, string position, int years, int account_id)
        {
            int row = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO [dbo].[tbl_work_history] " +
                        "VALUES (@work_history_id, @company, @position, @years, @fk_account_id)";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    command.Parameters.AddWithValue("@work_history_id", this.GetAvailableWorkHistoryID());
                    command.Parameters.AddWithValue("@company", company);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@years", years);
                    command.Parameters.AddWithValue("@fk_account_id", account_id);
                    row = command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return row;
        }

        public int InsertEducationInfo(string school, string program, string degree, int account_id)
        {
            int row = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO [dbo].[tbl_education] " +
                        "VALUES (@education_id, @school, @program, @degree, @fk_account_id)";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    command.Parameters.AddWithValue("@education_id", this.GetAvailableEducationID());
                    command.Parameters.AddWithValue("@school", school);
                    command.Parameters.AddWithValue("@program", program);
                    command.Parameters.AddWithValue("@degree", degree);
                    command.Parameters.AddWithValue("@fk_account_id", account_id);
                    row = command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return row;
        }

        public int InsertUserInfo(string first_name, string last_name, string phone_number, int account_id)
        {
            int row = 0;
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO [dbo].[tbl_user_info] " +
                        "VALUES (@user_id, @first_name, @last_name, @phone_number, @fk_account_id)";
                    SqlCommand command = new SqlCommand(sqlQuery, connection);

                    command.Parameters.AddWithValue("@user_id", this.GetAvailableUserID());
                    command.Parameters.AddWithValue("@first_name", first_name);
                    command.Parameters.AddWithValue("@last_name", last_name);
                    command.Parameters.AddWithValue("@phone_number", phone_number);
                    command.Parameters.AddWithValue("@fk_account_id", account_id);
                    row = command.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return row;
        }

        public int Registrate(string email, string password)
        {
            int row = 0;
            if (!this.EmailPasswordMatches(email, password))
            {
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "";
                    builder.UserID = "";
                    builder.Password = "";
                    builder.InitialCatalog = "";
                    builder.IntegratedSecurity = true;

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();
                        string sqlQuery = "INSERT INTO [dbo].[tbl_account] " +
                            "VALUES (@account_id, @email, @password)";
                        SqlCommand command = new SqlCommand(sqlQuery, connection);

                        command.Parameters.AddWithValue("@account_id", this.GetAvailableAccountID());
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        row = command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return row;
        }

        public int GetAvailableWorkHistoryID()
        {
            int available_id = 0;

            sqlIntegers = new List<int>();
            string sqlQuery = "SELECT work_history_id " +
                    "FROM [dbo].[tbl_work_history];";
            sqlIntegers = GetSQLIntegers(sqlQuery, 1);

            for (int i = 0; i < sqlIntegers.Count; i++)
            {
                if (!sqlIntegers.Contains((i + 1)))
                {
                    available_id = i + 1;
                }
                else
                {
                    available_id = sqlIntegers.Count + 1;
                }
            }
            return available_id;
        }

        public int GetAvailableEducationID()
        {
            int available_id = 0;

            sqlIntegers = new List<int>();
            string sqlQuery = "SELECT education_id " +
                    "FROM [dbo].[tbl_education];";
            sqlIntegers = GetSQLIntegers(sqlQuery, 1);

            for (int i = 0; i < sqlIntegers.Count; i++)
            {
                if (!sqlIntegers.Contains((i + 1)))
                {
                    available_id = i + 1;
                }
                else
                {
                    available_id = sqlIntegers.Count + 1;
                }
            }
            return available_id;
        }

        public int GetAvailableUserID()
        {
            int available_id = 0;

            sqlIntegers = new List<int>();
            string sqlQuery = "SELECT user_id " +
                    "FROM [dbo].[tbl_user_info];";
            sqlIntegers = GetSQLIntegers(sqlQuery, 1);

            for (int i = 0; i < sqlIntegers.Count; i++)
            {
                if (!sqlIntegers.Contains((i + 1)))
                {
                    available_id = i + 1;
                }
                else
                {
                    available_id = sqlIntegers.Count + 1;
                }
            }
            return available_id;
        }

        public int GetAvailableAccountID()
        {
            int available_id = 0;

            sqlIntegers = new List<int>();
            string sqlQuery = "SELECT account_id " +
                    "FROM [dbo].[tbl_account];";
            sqlIntegers = GetSQLIntegers(sqlQuery, 1);

            for (int i = 0; i < sqlIntegers.Count; i++)
            {
                if (!sqlIntegers.Contains((i + 1)))
                {
                    available_id = i + 1;
                }
                else
                {
                    available_id = sqlIntegers.Count + 1;
                }
            }
            return available_id;
        }

        public Boolean EmailPasswordMatches(string email, string password)
        {
            sqlStrings = new List<string>(); // unset sqlResults to avoid it mixes new and old strings
            Boolean matches = false;

            try
            {
                string sqlQuery = "SELECT [email], [password] " +
                    "FROM [dbo].[tbl_account] " +
                    "WHERE [email] = '" + email + "' " +
                    "AND [password] = '" + password + "';";
                sqlStrings = GetSQLStrings(sqlQuery, 2);
                if (sqlStrings.Count > 0)
                {
                    matches = true;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return matches;
        }

        public Boolean UserExists(string email)
        {
            Boolean exists = false;
            sqlIntegers = new List<int>();
            string sqlQuery = "SELECT ui.user_id " +
                    "FROM [dbo].[tbl_user_info] AS ui " +
                    "JOIN [dbo].[tbl_account] AS a " +
                    "ON ui.fk_account_id = a.account_id " +
                    "WHERE a.email = '" + email + "'";
            sqlIntegers = GetSQLIntegers(sqlQuery, 1);
            
            if (sqlIntegers.Count > 0)
            {
                exists = true;
            }

            return exists;
        }

        public List<string> GetSQLStrings(string sqlQuery, int numberOfColumns)
        {
            List<string> listString = new List<string>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(sqlQuery);
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            for (int i = 0; i < numberOfColumns; i++)
                                listString.Add(reader.GetString(i));
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.ToString());
            }
            return listString;
        }

        public List<int> GetSQLIntegers(string sqlQuery, int numberOfColumns)
        {
            List<int> listInt = new List<int>();

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "";
                builder.UserID = "";
                builder.Password = "";
                builder.InitialCatalog = "";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(sqlQuery);
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            for (int i = 0; i < numberOfColumns; i++)
                                listInt.Add(reader.GetInt32(i));
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                //MessageBox.Show(e.ToString());
            }
            return listInt;
        }
    }
}
