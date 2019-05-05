using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FuzzyTimeSeries
{
    public partial class Form1 : Form
    {
        private MembershipSegi3 dingin, sedang, panas;
        private double[] suhu;
        private String[] id, tahun, bulan;
        private String connString = "server=localhost;uid=root;pwd=;database=suhu;";
        private object[,] hasilRule;

        public Form1()
        {
            InitializeComponent();

            this.dingin = new MembershipSegi3(20, 21, 22, 1, 1, 0);
            this.sedang = new MembershipSegi3(21, 23, 25);
            this.panas = new MembershipSegi3(24, 25, 26, 0, 1, 1);

            suhu = new double[2];
            id = new String[2];
            tahun = new String[2];
            bulan = new String[2];
            hasilRule = new object[13, 3];

            refreshDGV();
            setDataSeries();
            pemberianRule(this.suhu[0], this.suhu[1]);
            setLabel();
            weightedAverage();

            double[] test = dingin.berpotonganPada(dingin, sedang);
            foreach (double bil in test)
            {
                Console.WriteLine(bil.ToString());
            }
        }

        public void pemberianRule(double t2, double t1)
        {
            if (sedang.isAnggota(t1) && sedang.isAnggota(t2))
            {
                double y1 = sedang.getYfromX(t1);
                double y2 = sedang.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = sedang.alphaCut(yz);
                hasilRule[0, 0] = yz;
                hasilRule[0, 1] = xz;
                hasilRule[0, 2] = "sedang";
            }
            else
            {
                double yz = 0;
                double[] xz = { sedang.getCorA, sedang.getCorC };
                hasilRule[0, 0] = yz;
                hasilRule[0, 1] = xz;
                hasilRule[0, 2] = "sedang";
            }

            if (sedang.isAnggota(t1) && sedang.isAnggota(t2))
            {
                double y1 = dingin.getYfromX(t1);
                double y2 = dingin.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = dingin.alphaCut(yz);
                hasilRule[1, 0] = yz;
                hasilRule[1, 1] = xz;
                hasilRule[1, 2] = "dingin";
            }
            else
            {
                double yz = 0;
                double[] xz = { dingin.getCorA, dingin.getCorC };
                hasilRule[1, 0] = yz;
                hasilRule[1, 1] = xz;
                hasilRule[1, 2] = "dingin";
            }

            if (dingin.isAnggota(t1) && sedang.isAnggota(t2))
            {
                double y1 = dingin.getYfromX(t1);
                double y2 = dingin.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = dingin.alphaCut(yz);
                hasilRule[2, 0] = yz;
                hasilRule[2, 1] = xz;
                hasilRule[2, 2] = "dingin";
            }
            else
            {
                double yz = 0;
                double[] xz = { dingin.getCorA, dingin.getCorC };
                hasilRule[2, 0] = yz;
                hasilRule[2, 1] = xz;
                hasilRule[2, 2] = "dingin";
            }

            if (dingin.isAnggota(t1) && dingin.isAnggota(t2))
            {
                double y1 = dingin.getYfromX(t1);
                double y2 = dingin.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = dingin.alphaCut(yz);
                hasilRule[3, 0] = yz;
                hasilRule[3, 1] = xz;
                hasilRule[3, 2] = "dingin";
            }
            else
            {
                double yz = 0;
                double[] xz = { dingin.getCorA, dingin.getCorC };
                hasilRule[3, 0] = yz;
                hasilRule[3, 1] = xz;
                hasilRule[3, 2] = "dingin";
            }

            if (dingin.isAnggota(t1) && dingin.isAnggota(t2))
            {
                double y1 = sedang.getYfromX(t1);
                double y2 = sedang.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = sedang.alphaCut(yz);
                hasilRule[4, 0] = yz;
                hasilRule[4, 1] = xz;
                hasilRule[4, 2] = "sedang";
            }
            else
            {
                double yz = 0;
                double[] xz = { dingin.getCorA, dingin.getCorC };
                hasilRule[4, 0] = yz;
                hasilRule[4, 1] = xz;
                hasilRule[4, 2] = "sedang";
            }

            if (sedang.isAnggota(t1) && dingin.isAnggota(t2))
            {
                double y1 = sedang.getYfromX(t1);
                double y2 = sedang.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = sedang.alphaCut(yz);
                hasilRule[5, 0] = yz;
                hasilRule[5, 1] = xz;
                hasilRule[5, 2] = "sedang";
            }
            else
            {
                double yz = 0;
                double[] xz = { sedang.getCorA, sedang.getCorC };
                hasilRule[5, 0] = yz;
                hasilRule[5, 1] = xz;
                hasilRule[5, 2] = "sedang";
            }

            if (sedang.isAnggota(t1) && sedang.isAnggota(t2))
            {
                double y1 = panas.getYfromX(t1);
                double y2 = panas.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = panas.alphaCut(yz);
                hasilRule[6, 0] = yz;
                hasilRule[6, 1] = xz;
                hasilRule[6, 2] = "panas";
            }
            else
            {
                double yz = 0;
                double[] xz = { panas.getCorA, panas.getCorC };
                hasilRule[6, 0] = yz;
                hasilRule[6, 1] = xz;
                hasilRule[6, 2] = "panas";
            }

            if (panas.isAnggota(t1) && sedang.isAnggota(t2))
            {
                double y1 = panas.getYfromX(t1);
                double y2 = panas.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = panas.alphaCut(yz);
                hasilRule[7, 0] = yz;
                hasilRule[7, 1] = xz;
                hasilRule[7, 2] = "panas";
            }
            else
            {
                double yz = 0;
                double[] xz = { panas.getCorA, panas.getCorC };
                hasilRule[7, 0] = yz;
                hasilRule[7, 1] = xz;
                hasilRule[7, 2] = "panas";
            }

            if (panas.isAnggota(t1) && panas.isAnggota(t2))
            {
                double y1 = sedang.getYfromX(t1);
                double y2 = sedang.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = sedang.alphaCut(yz);
                hasilRule[8, 0] = yz;
                hasilRule[8, 1] = xz;
                hasilRule[8, 2] = "sedang";
            }
            else
            {
                double yz = 0;
                double[] xz = { sedang.getCorA, sedang.getCorC };
                hasilRule[8, 0] = yz;
                hasilRule[8, 1] = xz;
                hasilRule[8, 2] = "sedang";
            }

            if (sedang.isAnggota(t1) && panas.isAnggota(t2))
            {
                double y1 = sedang.getYfromX(t1);
                double y2 = sedang.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = sedang.alphaCut(yz);
                hasilRule[9, 0] = yz;
                hasilRule[9, 1] = xz;
                hasilRule[9, 2] = "sedang";
            }
            else
            {
                double yz = 0;
                double[] xz = { sedang.getCorA, sedang.getCorC };
                hasilRule[9, 0] = yz;
                hasilRule[9, 1] = xz;
                hasilRule[9, 2] = "sedang";
            }

            if (panas.isAnggota(t1) && sedang.isAnggota(t2))
            {
                double y1 = sedang.getYfromX(t1);
                double y2 = sedang.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = sedang.alphaCut(yz);
                hasilRule[10, 0] = yz;
                hasilRule[10, 1] = xz;
                hasilRule[10, 2] = "sedang";
            }
            else
            {
                double yz = 0;
                double[] xz = { sedang.getCorA, sedang.getCorC };
                hasilRule[10, 0] = yz;
                hasilRule[10, 1] = xz;
                hasilRule[10, 2] = "sedang";
            }

            if (sedang.isAnggota(t1) && panas.isAnggota(t2))
            {
                double y1 = panas.getYfromX(t1);
                double y2 = panas.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = panas.alphaCut(yz);
                hasilRule[11, 0] = yz;
                hasilRule[11, 1] = xz;
                hasilRule[11, 2] = "panas";
            }
            else
            {
                double yz = 0;
                double[] xz = { panas.getCorA, panas.getCorC };
                hasilRule[11, 0] = yz;
                hasilRule[11, 1] = xz;
                hasilRule[11, 2] = "panas";
            }

            if (panas.isAnggota(t1) && panas.isAnggota(t2))
            {
                double y1 = panas.getYfromX(t1);
                double y2 = panas.getYfromX(t2);
                double yz = Math.Min(y1, y2);
                double[] xz = panas.alphaCut(yz);
                hasilRule[12, 0] = yz;
                hasilRule[12, 1] = xz;
                hasilRule[12, 2] = "panas";
            }
            else
            {
                double yz = 0;
                double[] xz = { panas.getCorA, panas.getCorC };
                hasilRule[12, 0] = yz;
                hasilRule[12, 1] = xz;
                hasilRule[12, 2] = "panas";
            }
        }
        
        public void setLabel()
        {
            label3.Text = suhu[0].ToString();
            label4.Text = suhu[1].ToString();
        }

        public void setDataSeries()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                String sqlStr = "SELECT * FROM ( SELECT * FROM suhu2 ORDER BY id DESC LIMIT 2) as r ORDER BY id";

                MySqlCommand cmd1 = new MySqlCommand(sqlStr, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                
                int i = 0;
                while (reader.Read())
                {
                    String id = reader[0].ToString();
                    String tahun = reader[1].ToString();
                    String bulan = reader[2].ToString();
                    double suhu = (double) reader[3];

                    this.id[i] = id;
                    this.tahun[i] = tahun;
                    this.bulan[i] = bulan;
                    this.suhu[i] = suhu;
                    i++;
                }
                conn.Close();
            } catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshDGV()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                String sqlStr = "SELECT * FROM suhu2";
                MySqlCommand cmd1 = new MySqlCommand(sqlStr, conn);
                MySqlDataReader reader = cmd1.ExecuteReader();
                
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void weightedAverage()
            {
                double a = 0, b = 0, center;
                double[] tempBil;
                double hasil;
                for (int i = 0; i < 13; i++)
                {
                    b += (double)hasilRule[i, 0];
                    tempBil = (double[])hasilRule[i, 1];
                    center = (tempBil[0] + tempBil[1]) / 2;
                    a += (double)hasilRule[i, 0] * center;
                }
                hasil = a / b;
                label6.Text = hasil.ToString();
            }
        }
}
