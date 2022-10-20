using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExportSqlToCSV
{
    public partial class Form1 : Form
    {
        string conString = $"Data Source=TQTR;Initial Catalog=CC_ES_22_08_22_13_29_33R;Integrated Security=SSPI;";
        List<string> listTableName = new List<string>();
        int countTable = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon;
            sqlCon = new SqlConnection(conString);
            sqlCon.Open();

            GetAllTableName();

            if(listTableName.Count > 0)
            {
                for(; countTable < listTableName.Count; countTable ++)
                {
                    string table = listTableName[countTable];
                    txtTableIndex.Text = countTable.ToString();

                    txtTableName.Text = table;

                    string sqlQuery = $"select * from {table}";
                    SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                    DataTable dtData = new DataTable();
                    dscmd.Fill(dtData);
                    grv.DataSource = dtData;

                    string pathFile = @"C:\Users\TQTr\Desktop\CC_ES_22_08_22_13_29_33R\" + table + ".csv";
                    bool fileError = false;
                    if (File.Exists(pathFile))
                    {
                        try
                        {
                            File.Delete(pathFile);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = grv.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[grv.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += grv.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < grv.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    if (grv.Rows[i - 1].Cells[j] != null)
                                    {
                                        if (grv.Rows[i - 1].Cells[j].Value != null)
                                        {
                                            outputCsv[i] += grv.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                        }
                                        else
                                        {
                                            outputCsv[i] += " ,";
                                        }
                                    }
                                    else
                                    {
                                        outputCsv[i] += " ,";
                                    }

                                }
                            }

                            File.WriteAllLines(pathFile, outputCsv, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }

                }
            }
            
            sqlCon.Close();
            MessageBox.Show("Exported File Done!!");
        }

        public void GetAllTableName()
        {
            string sqlQuery = $"SELECT TABLE_NAME\r\nFROM INFORMATION_SCHEMA.TABLES\r\nWHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='CC_ES_22_08_22_13_29_33R'";

            SqlConnection sqlCon = new SqlConnection(conString);

            sqlCon.Open();

            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string table = "";

                    try
                    {
                        table = reader["TABLE_NAME"].ToString();
                    }
                    catch(Exception ex)
                    {
                        table = "";
                    }

                    listTableName.Add(table);
                }
            }
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (grv.Rows.Count > 0)
            {
                string table = listTableName[countTable];

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = $"{table}.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = grv.Columns.Count;
                            string columnNames = "";
                            string[] outputCsv = new string[grv.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += grv.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCsv[0] += columnNames;

                            for (int i = 1; (i - 1) < grv.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    if(grv.Rows[i - 1].Cells[j] != null)
                                    {
                                        if (grv.Rows[i - 1].Cells[j].Value != null)
                                        {
                                            outputCsv[i] += grv.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                        }
                                        else
                                        {
                                            outputCsv[i] += " ,";
                                        }
                                    }
                                    else
                                    {
                                        outputCsv[i] += " ,";
                                    }
                                    
                                }
                            }

                            File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }

        }

        private void btnNextTable_Click(object sender, EventArgs e)
        {
            countTable++;

            SqlConnection sqlCon;
            sqlCon = new SqlConnection(conString);
            sqlCon.Open();

            if (listTableName.Count > 0)
            {
                string table = listTableName[countTable];
                txtTableIndex.Text = countTable.ToString();

                txtTableName.Text = table;

                string sqlQuery = $"select * from {table}";
                SqlDataAdapter dscmd = new SqlDataAdapter(sqlQuery, sqlCon);
                DataTable dtData = new DataTable();
                dscmd.Fill(dtData);
                grv.DataSource = dtData;
            }

            sqlCon.Close();
        }
    }
}
