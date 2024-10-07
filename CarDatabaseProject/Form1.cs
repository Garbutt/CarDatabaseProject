using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDatabaseProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        DataBaseConnection objConnect;
        string conString;

        DataSet ds;
        DataRow dRow;

        int MaxRows;
        int inc = 0;

        // Load event handler
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new DataBaseConnection();
                conString = Properties.Settings.Default.CarConnectionString;

                objConnect.connection_string = conString;
                objConnect.Sql = Properties.Settings.Default.SQL;

                ds = objConnect.GetConnection;
                MaxRows = ds.Tables[0].Rows.Count;

                //Calling the method
                NavigateRecords();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        //Method for navigating records
        private void NavigateRecords()
        {
            dRow = ds.Tables[0].Rows[inc];
            txtOrderNum.Text = dRow.ItemArray.GetValue(0).ToString();
            txtManufacturer.Text = dRow.ItemArray.GetValue(1).ToString();
            txtModel.Text = dRow.ItemArray.GetValue(2).ToString();
            txtColour.Text = dRow.ItemArray.GetValue(3).ToString();
            txtEngineType.Text = dRow.ItemArray.GetValue(4).ToString();
            txtEngineSize.Text = dRow.ItemArray.GetValue(5).ToString();
        }

        //Next Button
        private void btnnext_Click(object sender, EventArgs e)
        {

            //Goes to the next row
            if (inc != MaxRows - 1)
            {
                inc++;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("No more rows");
            }
        }

        //Previous button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            //Goes down a row 
            if(inc > 0)
            {
                inc--;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("First record");
            }
        }

        //Last record button
        private void btnLastRecord_Click(object sender, EventArgs e)
        {

            //Goes to the last record
            if(inc != MaxRows - 1)
            {
                inc = MaxRows - 1;
                NavigateRecords();
            }
        }

        //First record button
        private void btnFirstRecord_Click(object sender, EventArgs e)
        {
            //Goes to the first record
            if(inc != 0)
            {
                inc = 0;
                NavigateRecords();
            }
        }

        //Add record button
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            //Clears all text in textboxes and enables/ disables buttons
            txtOrderNum.Clear();
            txtManufacturer.Clear();
            txtModel.Clear();
            txtColour.Clear();
            txtEngineType.Clear();
            txtEngineSize.Clear();

            btnAddRecord.Enabled = false;
            btnSaveRecord.Enabled = true;
            btnCancelRecord.Enabled = true;

        }

        private void btnCancelRecord_Click(object sender, EventArgs e)
        {
            NavigateRecords();

            btnCancelRecord.Enabled=false;
            btnSaveRecord.Enabled = false;
            btnAddRecord.Enabled=true;
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); 
            row[0] = txtOrderNum.Text;
            row[1] = txtManufacturer.Text;
            row[2] = txtModel.Text;
            row[3] = txtColour.Text;
            row[4] = txtEngineType.Text;
            row[5] = txtEngineSize.Text;

            ds.Tables[0].Rows.Add(row);

            try
            {
                objConnect.UpdateDatabase(ds);
                MaxRows = MaxRows + 1;
                inc = MaxRows - 1;

                MessageBox.Show("Database Updated!");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }

            btnCancelRecord.Enabled = false;
            btnSaveRecord.Enabled = false;
            btnAddRecord.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].Rows[inc];

            row[0] = txtOrderNum.Text;
            row[1] = txtManufacturer.Text;
            row[2] = txtModel.Text;
            row[3] = txtColour.Text;
            row[4] = txtEngineType.Text;
            row[5] = txtEngineSize.Text;

            try
            {
                objConnect.UpdateDatabase(ds);
                MessageBox.Show("Record Updated");
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            

            try
            {
                ds.Tables[0].Rows[inc].Delete();

                if (inc > 0)
                {
                    inc--;
                    MaxRows--;
                }
                objConnect.UpdateDatabase(ds);
                NavigateRecords();

                MessageBox.Show("Record Deleted");
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpText = "This application allows you to manage car records.\n\n"
                           + "To navigate through the cars click 'previous', 'next', 'first record', or 'last record'.\n\n"
                           + "To add a new car, click 'add new record', type in all the information and select 'save'.\n\n"
                           + "To update or delete an existing car, navigate to the car from the list, make the necessary changes, and click 'Update Car' or 'Delete Car'.\n\n"
                           + "Ensure that all fields are filled correctly before performing any action.\n\n"
                           + "For further assistance, contact support.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtColour_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtManufacturer_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEngineType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOrderNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEngineSize_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
  
