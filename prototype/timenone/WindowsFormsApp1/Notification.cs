﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
namespace WindowsFormsApp1
{
    public partial class Notification : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        public static string h = "";
        public static string time = "";
        
        public Notification()
        {
            InitializeComponent();
            //timer1.Start();
        }
        void Notification_FormClosing(object sender, FormClosingEventArgs e)
        {
            //your code here
            outputDevice.Stop();
            this.Hide();
        }
        public void get_data(string time, string h)
        {
            event_time.Text = "";
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            //this.FormClosed += new FormClosedEventHandler(f_FormClosed);
            //this.FormClosing += new FormClosingEventHandler(Notification_FormClosing);
            event_time.Text = h;
            time_this.Text = time;
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                //outputDevice.PlaybackStopped += Notification.OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(@"C:\Users\wannaphong\Documents\timenone\timenone\funky-breakbeat_102bpm_F_major.wav");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           /* Notification n = new Notification();
            if (n.Visible == false)
            {
                outputDevice.Stop();
                timer1.Stop();
            }*/
        }

        private void close_Click(object sender, EventArgs e)
        {
            outputDevice.Stop();
            this.Hide();
        }
    }
}