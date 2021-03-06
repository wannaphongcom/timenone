﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class add_alert : Form
    {
        
        public add_alert()
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.add_alert_FormClosing);
        }

        private void clean_Click(object sender, EventArgs e)
        {
            h.Refresh();
            m.Refresh();
            note.Text = "";
        }
        private void add_alert_FormClosing(object sender, FormClosingEventArgs e)
        {
            //home.ActiveForm.Opacity = 1.0;
        }

        private void add_alert_Load(object sender, EventArgs e)
        {
            h.DropDownStyle = ComboBoxStyle.DropDownList; // ล็อค ไม่ให้กรอกข้อความได้
            m.DropDownStyle = ComboBoxStyle.DropDownList; // ล็อค ไม่ให้กรอกข้อความได้
            //S.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void save_Click(object sender, EventArgs e)
        {
            var db = new db();
            string[] d = {"วันอาทิตย์","วันจันทร์","วันอังคาร","วันพุธ","วันพฤหัสบดี","วันศุกร์","วันเสาร์"};
            bool d1=false, d2 = false, d3 = false, d4 = false, d5 = false, d6 = false, d7 = false;
            foreach (string item in days.CheckedItems)
            {
                int i = 0;
                while (i < d.Length)
                {
                    if (d[i] == item)
                    {
                        if (i == 0) d1 = true;
                        else if (i == 1) d2 = true;
                        else if (i == 2) d3 = true;
                        else if (i == 3) d4 = true;
                        else if (i == 4) d5 = true;
                        else if (i == 6) d6 = true;
                        else if (i == 7) d7 = true;
                    }
                    i++;
                }

            }
           db.add_data(note.Text,h.Text,m.Text,d1,d2,d3,d4,d5,d6,d7, Enable.Checked);
           MessageBox.Show("Ok");
        }

        private void open_f1_Click(object sender, EventArgs e)
        {
            home h = new home();
            h.Show();
        }
    }
}
