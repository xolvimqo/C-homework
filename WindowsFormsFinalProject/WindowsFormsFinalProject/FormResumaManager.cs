using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsFinalProject
{
    public partial class FormResumaManager : Form
    {
        private string email, password;

        public FormResumaManager(string email, string password)
        {
            InitializeComponent();

            // Resize tabControl with this form
            tabControl1.Dock = DockStyle.Fill;

            // Set up the form
            this.email = email;
            this.password = password;
        }

        private void btnAddEducation_Click(object sender, EventArgs e)
        {
            if (txtboxSchool.Text.Length > 0 && txtboxProgram.Text.Length > 0 && txtboxDegree.Text.Length > 0)
            {
                LinkSQL linkSQL = new LinkSQL();
                int account_id = linkSQL.GetAccountID(this.email);

                if (linkSQL.InsertEducationInfo(txtboxSchool.Text, txtboxProgram.Text, txtboxDegree.Text, account_id) > 0)
                {
                    MessageBox.Show("Data saved successfully!");
                    this.FormResumaManager_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Unexpected errors while update info!");
                }
            }
            else
            {
                MessageBox.Show("All informations can not be empty!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtboxFirstName.Text.Length > 0 && txtboxLastName.Text.Length > 0 && txtboxPhoneNumber.Text.Length > 0)
            {
                LinkSQL linkSQL = new LinkSQL();
                int account_id = linkSQL.GetAccountID(this.email);

                if (!linkSQL.UserExists(this.email))
                {
                    if (linkSQL.InsertUserInfo(txtboxFirstName.Text, txtboxLastName.Text, txtboxPhoneNumber.Text, account_id) > 0)
                    {
                        MessageBox.Show("Data saved successfully!");
                        this.FormResumaManager_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Unexpected errors while update info!");
                    }
                }
                else
                {
                    if (linkSQL.UpdateUserInfo(txtboxFirstName.Text, txtboxLastName.Text, txtboxPhoneNumber.Text, account_id) > 0)
                    {
                        MessageBox.Show("Data updated successfully!");
                        this.FormResumaManager_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Unexpected errors while update info!");
                    }
                }
            }
            else
            {
                MessageBox.Show("All informations can not be empty!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.FormResumaManager_Load(sender, e);
        }

        private void txtboxFirstName_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtboxFirstName.Text = "";
            this.txtboxFirstName.ForeColor = Color.Black;
        }

        private void txtboxLastName_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtboxLastName.Text = "";
            this.txtboxLastName.ForeColor = Color.Black;
        }

        private void txtboxPhoneNumber_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtboxPhoneNumber.Text = "";
            this.txtboxPhoneNumber.ForeColor = Color.Black;
        }

        private void btnDeleteEducation_Click(object sender, EventArgs e)
        {
            string[] selectedItem = this.listboxEducation.SelectedItem.ToString().Split(',');
            int account_id = new LinkSQL().GetAccountID(this.email);
            if (new LinkSQL().DeleteEducationInfo(selectedItem[0].TrimStart(), selectedItem[1].TrimStart(), selectedItem[2].TrimStart(), account_id) > 0)
            {
                MessageBox.Show("Deleted Successfully!");
                this.FormResumaManager_Load(sender, e);
            }
        }

        private void btnAddWorkHistory_Click(object sender, EventArgs e)
        {
            if (txtboxCompany.Text.Length > 0 && txtboxPosition.Text.Length > 0 && numericUpDownYears.Value > 0)
            {
                LinkSQL linkSQL = new LinkSQL();
                int account_id = linkSQL.GetAccountID(this.email);

                if (linkSQL.InsertWorkHistory(txtboxCompany.Text, txtboxPosition.Text, int.Parse(numericUpDownYears.Value.ToString()), account_id) > 0)
                {
                    MessageBox.Show("Data saved successfully!");
                    this.FormResumaManager_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Unexpected errors while update info!");
                }
            }
            else
            {
                MessageBox.Show("All informations can not be empty!");
            }
        }

        private void btnDeleteWorkHistory_Click(object sender, EventArgs e)
        {
            string[] selectedItem = this.listboxWorkHistory.SelectedItem.ToString().Split(',');
            int account_id = new LinkSQL().GetAccountID(this.email);
            if (new LinkSQL().DeleteWorkHistory(selectedItem[0].TrimStart(), 
                selectedItem[1].TrimStart(), 
                int.Parse(Regex.Replace(selectedItem[2].Trim(), "[^0-9]", "")), account_id) > 0)
            {
                MessageBox.Show("Deleted Successfully!");
                this.FormResumaManager_Load(sender, e);
            }
        }

        private void btnFolderBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBowserDialog = new FolderBrowserDialog();
            
            // Show the FolderBrowserDialog
            DialogResult result = folderBowserDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                txtboxFileDirectory.Text = folderBowserDialog.SelectedPath;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.CollectionName = "Users";
            LinkSQL link = new LinkSQL();
            User user = new User(link.GetFirstName(this.email), link.GetLastName(this.email), this.email, link.GetPhoneNumber(this.email));
            // Add all Education backgrounds
            for (int i = 0; i < link.GetEducationID(this.email).Count; i++)
            {
                user.AddEducation(link.GetSchool(this.email)[i], link.GetProgram(this.email)[i], link.GetDegree(this.email)[i]);
            }
            // Add all Work Histories
            for (int i = 0; i < link.GetWorkHistoryID(this.email).Count; i++)
            {
                user.AddWorkHistory(link.GetCompany(this.email)[i], link.GetPosition(this.email)[i], link.GetYears(this.email)[i]);
            }

            users.Add(user);

            // XML Serialization
            XmlSerializer xmlSer = new XmlSerializer(typeof(Users));

            // use StreamWriter to save xml file
            string path = this.txtboxFileDirectory.Text + "\\resume.xml";
            TextWriter writer = new StreamWriter(path);
            xmlSer.Serialize(writer, users);
            writer.Close();
        }

        private void btnFileBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdlg = new OpenFileDialog();
            ofdlg.Title = "Open a File";
            ofdlg.InitialDirectory = @"C:\";
            ofdlg.Filter = "XML Files (*.xml)|*.xml";
            ofdlg.DefaultExt = "xml";
            if (ofdlg.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(ofdlg.FileName),
                    ".xml",
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Invalid file type selected; display an error
                    MessageBox.Show("The type of the selected file is not supported!",
                        "Invalid File Type",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtboxImport.Text = ofdlg.FileName;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (txtboxImport.Text.Length > 0) {
                XmlTextReader reader = new XmlTextReader(txtboxImport.Text);
                XDocument xdoc = XDocument.Load(txtboxImport.Text);
                List<string> schools = new List<string>();
                List<string> programs = new List<string>();
                List<string> degrees = new List<string>();
                List<string> companies = new List<string>();
                List<string> positions = new List<string>();
                List<int> years = new List<int>();

                var items = from item in xdoc.Descendants("User")
                            select new
                            {
                                firstName = item.Element("firstName").Value,
                                lastName = item.Element("lastName").Value,
                                phoneNumber = item.Element("phoneNumber").Value,
                                schools = item.Descendants("schools").Descendants().Select(x => x.Value).ToList(),
                                programs = item.Descendants("programs").Descendants().Select(x => x.Value).ToList(),
                                degrees = item.Descendants("degrees").Descendants().Select(x => x.Value).ToList(),
                                companies = item.Descendants("companies").Descendants().Select(x => x.Value).ToList(),
                                positions = item.Descendants("positions").Descendants().Select(x => x.Value).ToList(),
                                years = item.Descendants("years").Descendants().Select(x => x.Value).ToList()
                            };
                foreach (var item in items)
                {
                    txtboxFirstName.Text = item.firstName;
                    txtboxLastName.Text = item.lastName;
                    txtboxPhoneNumber.Text = item.phoneNumber;
                    btnSave_Click(sender, e);
                    for (int i = 0; i < item.schools.Count; i++)
                    {
                        txtboxSchool.Text = item.schools[i];
                        txtboxProgram.Text = item.programs[i];
                        txtboxDegree.Text = item.degrees[i];
                        btnAddEducation_Click(sender, e);
                    }
                    for (int i = 0; i < item.companies.Count; i++)
                    {
                        txtboxCompany.Text = item.companies[i];
                        txtboxPosition.Text = item.positions[i];
                        numericUpDownYears.Value = int.Parse(item.years[i]);
                        btnAddWorkHistory_Click(sender, e);
                    }
                }
            }
            else
            {
                MessageBox.Show("No file selected!");
            }
        }

        private void FormResumaManager_Load(object sender, EventArgs e)
        {
            LinkSQL link = new LinkSQL();
            this.listboxEducation.Items.Clear();
            this.listboxWorkHistory.Items.Clear();
            this.txtboxEmail.Text = this.email;
            this.txtboxFirstName.Text = new LinkSQL().GetFirstName(this.email);
            this.txtboxFirstName.ForeColor = Color.Gray;
            this.txtboxLastName.Text = new LinkSQL().GetLastName(this.email);
            this.txtboxLastName.ForeColor = Color.Gray;
            this.txtboxPhoneNumber.Text = new LinkSQL().GetPhoneNumber(this.email);
            this.txtboxPhoneNumber.ForeColor = Color.Gray;
            this.txtboxFileDirectory.Text = "C:\\";

            for (int i = 0; i < link.GetEducationID(this.email).Count; i++)
            {
                this.listboxEducation.Items.Add(link.GetSchool(this.email)[i] + ", " 
                    + link.GetProgram(this.email)[i] + ", " 
                    + link.GetDegree(this.email)[i]);
            }

            for (int i = 0; i < link.GetWorkHistoryID(this.email).Count; i++)
            {
                this.listboxWorkHistory.Items.Add(link.GetCompany(this.email)[i] + ", "
                    + link.GetPosition(this.email)[i] + ", "
                    + link.GetYears(this.email)[i] + " years");
            }
        }
    }
}
