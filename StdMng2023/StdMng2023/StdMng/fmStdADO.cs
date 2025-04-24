using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace StdMng2023.StdMng
{
    public partial class fmStdADO : Form
    {
        // Binary byte array for storing student registration photos
        Byte[] imgBytes;
        // Take the value of the link string in the configuration file
        String conStr = Properties.Settings.Default.StdMngConStr;

        public fmStdADO()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        void FillDept()
        {
            // Define the database connection object, pass in the value of the database connection string
            SqlConnection con = new SqlConnection(conStr);

            try
            {
                // Open the database connection object
                con.Open();
                // Define the database command object
                SqlCommand cmd = new SqlCommand();
                // Set the connection object of the database command object to con
                cmd.Connection = con;
                // Define SQL statements for database command objects
                cmd.CommandText = "select SdeptID,SdeptName from t_Sdept";
                // Define data adapter object, pass in cmd command
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                // Generate DataSet instance objects
                DataSet ds = new DataSet();
                // populate the dataset, read the t_Sdept table into the dataset
                sda.Fill(ds, "t_Sdept");
                // Specify the data source for the department drop-down box as the data table t_Sdept in the data set ds
                cbDept.DataSource = ds.Tables["t_Sdept"];
                // Set the Department drop-down box value object
                cbDept.ValueMember = "SdeptID";
                // Set the Department drop-down box display object
                cbDept.DisplayMember = "SdeptName";
            }
            catch (Exception ex)
            {
                // Use the message dialog to prompt after catching an exception
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // The database connection object con must be closed with code whether or not the program is completed
                if (!(con is null) && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void fmStdADO_Load(object sender, EventArgs e)
        {
            // Set the default value of the gender dropdown box to "F"
            cbGender.SelectedIndex = 0;
            // Set the default value of date of birth to January 1, 1990
            dpBirth.Value = new DateTime(1990, 1, 1);
            // Populate department drop-down box
            FillDept();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Define stream objects
            Stream myStream;
            // The user clicks the OK button in the open file modal box
            if (ofdStd.ShowDialog() == DialogResult.OK)
            {
                //Open file
                myStream = ofdStd.OpenFile();
                //Set Image Frame Image
                pbImage.Image = Bitmap.FromStream(myStream);
                // Read the image file into an imgBytes binary array for subsequent storage in the database
                imgBytes = new byte[myStream.Length];
                myStream.Seek(0, SeekOrigin.Begin);
                myStream.Read(imgBytes, 0, (int)myStream.Length);
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtIDCardNums_Leave(object sender, EventArgs e)
        {
            // Define regular expressions for ID numbers
            string idCardRegStr = @"^\d{17}[\d|X]$|^\d{15}$";
            Regex r = new Regex(idCardRegStr);

            // Verify that the ID number entered by the user matches the defined pattern
            if (!r.IsMatch(txtIDCardNums.Text))
            {
                // If validation is wrong, use ErrorProvider hint and save the input focus state of the text box
                // until user input is correct
                epStd.SetError(txtIDCardNums, "ID number error!");
                txtIDCardNums.Focus();
            }
            else
            {
                epStd.SetError(txtIDCardNums, ""); // Clear the error provider if input is correct
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            // Define regular expressions for emails
            string emailRegStr = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex r = new Regex(emailRegStr);

            // Verify that the email entered by the user matches the defined pattern
            if (!r.IsMatch(txtEmail.Text))
            {
                // If validation is wrong, use ErrorProvider hint and save the input focus state of the text box
                // until user input is correct
                epStd.SetError(txtEmail, "Mailbox input error!");
                txtEmail.Focus();
            }
            else
            {
                epStd.SetError(txtEmail, ""); // Clear the error provider if input is correct
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // SQL statement for inserting student information 
                cmd.CommandText = "INSERT INTO t_student (sno, sname, sgender, sbirth, sdept, simage, sIDNum, sEmail) " +
                    "VALUES (@sno, @sname, @sgender, @sbirth, @sdept, @simage, @sIDNum, @sEmail)";

                // Get the gender of the student
                string sGender = cbGender.SelectedIndex == 0 ? "M" : "F";

                // Add parameters to the command
                cmd.Parameters.AddRange(new SqlParameter[]
                {
            new SqlParameter("@sno", txtID.Text),
            new SqlParameter("@sname", txtName.Text),
            new SqlParameter("@sgender", sGender),
            new SqlParameter("@sbirth", dpBirth.Value),
            new SqlParameter("@sdept", cbDept.SelectedValue),
            new SqlParameter("@simage", imgBytes),
            new SqlParameter("@sIDNum", txtIDCardNums.Text),
            new SqlParameter("@sEmail", txtEmail.Text)
                });

                // Execute the insert statement
                cmd.ExecuteNonQuery();

                // If successful, show a message indicating successful insertion
                MessageBox.Show("Insert student information successfully!", "Prompt message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (!(con is null) && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE t_student SET sname=@sname, sgender=@sgender, sbirth=@sbirth, " +
                    "sdept=@sdept, simage=@simage, sIDNum=@sIDNum, sEmail=@sEmail WHERE sno=@sno";

                string sGender = cbGender.SelectedIndex == 0 ? "M" : "F";

                cmd.Parameters.AddRange(new SqlParameter[]
                {
            new SqlParameter("@sno", txtID.Text),
            new SqlParameter("@sname", txtName.Text),
            new SqlParameter("@sgender", sGender),
            new SqlParameter("@sbirth", dpBirth.Value),
            new SqlParameter("@sdept", cbDept.SelectedValue),
            new SqlParameter("@simage", imgBytes),
            new SqlParameter("@sIDNum", txtIDCardNums.Text),
            new SqlParameter("@sEmail", txtEmail.Text)
                });

                cmd.ExecuteNonQuery();

                MessageBox.Show("Update student information successfully!", "Prompt message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (!(con is null) && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            // Define the transaction object
            SqlTransaction trans = null;
            try
            {
                con.Open();
                // Open transaction
                trans = con.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                // Specify the transaction instance of the command object
                cmd.Transaction = trans;

                cmd.CommandText = "DELETE FROM t_sc WHERE sno=@sno;" +
                    "DELETE FROM t_student WHERE sno=@sno";
                cmd.Parameters.AddWithValue("@sno", txtID.Text);
                cmd.ExecuteNonQuery();

                // Commit the transaction
                trans.Commit();

                MessageBox.Show("Deleting student information successfully!", "Prompt message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // If there is an exception, the transaction is rolled back
                if (!(trans is null))
                    trans.Rollback();
            }
            finally
            {
                if (!(con is null) && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }


        }

        private void QueryStd(string sno)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select sno, sname, sgender, sbirth, sdept, simage, sIDNum, sEmail from t_student where sno=@sno";
                cmd.Parameters.AddWithValue("@sno", sno);

                // Read student information using SqlDataReader
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            txtName.Text = rd["sname"].ToString();
                            // Read student gender
                            cbGender.SelectedIndex = rd["sgender"].ToString() == "M" ? 0 : 1;
                            dpBirth.Value = Convert.ToDateTime(rd["sbirth"]);
                            cbDept.SelectedValue = rd["sdept"].ToString();

                            // Reading student registration photos
                            if (!(rd["simage"] is DBNull))
                                pbImage.Image = Bitmap.FromStream(new MemoryStream((byte[])rd["simage"]));

                            txtIDCardNums.Text = rd["sIDNum"].ToString();
                            txtEmail.Text = rd["sEmail"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is no such person!", "Prompt message",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            QueryStd(txtID.Text);
        }

        private void txtIDCardNums_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

