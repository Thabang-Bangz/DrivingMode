using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace DrivingMode
{
    public partial class frmDrivingMode : Form
    {
        public frmDrivingMode()
        {
            InitializeComponent();
        }
        SoundPlayer splayer = new SoundPlayer(@"C:\Users\admin\Desktop\DrivingMode\warning.wav");
        int speed = 0;
        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAccelerate_MouseHover(object sender, EventArgs e)
        {


            timer1.Start();
            warning();
            lstNotificationV2.Items.Add("Vehicle in front of you is accelerating, keep a safe following distance");
           

            
           
        }

        private void btnAccelerate_Click(object sender, EventArgs e)
        {
          
        }

        private void frmDrivingMode_Load(object sender, EventArgs e)
        {
            pnlIssues.Visible = false;
            pnlV2.Visible = false;
            DateTime now = DateTime.Now;
            lblCurrentTime.Text = now.ToString("F");
            lblTimeV2.Text = now.ToString("F");
            

        }
  

        private void btnReportIssue_Click(object sender, EventArgs e)
        {
            pnlIssues.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            speed++;
            lblSpeed.Text = speed.ToString();
        }

        private void btnAccelerate_MouseLeave(object sender, EventArgs e)
        {
            timer1.Stop();
            warning();
            
            lstNotificationV2.Items.Clear();
            lstNotifications.Items.Clear();
            
            
        }

        private void btnBrake_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            speed--;
            lblSpeed.Text = speed.ToString();

        }

        private void btnBrake_MouseHover(object sender, EventArgs e)
        {
            timer2.Start();
            lowspeed();
            lstNotificationV2.Items.Add("Vehicle in front of you is braking be cautious, and maintain a safe following distance");
            
            
        }

        private void btnBrake_MouseLeave(object sender, EventArgs e)
        {
            timer2.Stop();
            lowspeed();
        }
       
        public void warning()
        {
            
            if(speed > 125)
            {

                splayer.PlayLooping();
            lstNotifications.Items.Add("YOU ARE SPEEDING, REDUCE SPEED!!");
            }
           
          
        }
        public void lowspeed()
        {
            if (speed<125)
            {
                splayer.Stop();
            }
        }

        private void btnV2Report_Click(object sender, EventArgs e)
        {
            pnlV2.Visible = true;
        }
        int speed2 = 0;
        private void btnV2Accelerate_MouseHover(object sender, EventArgs e)
        {
            if (speed<speed2)
            {
                lstNotificationV2.Items.Add("Reduce speed so you don't bump into Vehicle 1");
            }
            lstNotifications.Items.Add("Exercise caution when accelerating");
            lstNotifications.Items.Add("Vehicle behind you is accelerating");

            
            timerV2.Start();
            warning();
          
          
        }

        private void btnSOS_Click(object sender, EventArgs e)
        {
            //Should send a alert to the server that vehicle 1 requires emergency help
            //Also alert vehicle 2 that vehicle might have a problem, that could require their assistance.
        }

        private void timerV2_Tick(object sender, EventArgs e)
        {
            speed2++;
            lblSpeedV2.Text = speed2.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            speed2--;
            lblSpeedV2.Text = speed2.ToString();

        }

        private void btnV2Brake_MouseHover(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void btnV2Accelerate_MouseLeave(object sender, EventArgs e)
        {
            timerV2.Stop();
            lstNotifications.Items.Clear();
            if (speed < speed2)
            {
                lstNotificationV2.Items.Add("Reduce speed so you don't bump into Vehicle 1");
            }
        }

        private void btnV2Brake_MouseLeave(object sender, EventArgs e)
        {
            timer3.Stop();
        }

        private void btnV2Accelerate_Click(object sender, EventArgs e)
        {

        }

        private void btnV2SOS_Click(object sender, EventArgs e)
        {
            //Should send a alert to the server that vehicle 2 requires emergency help
            //Also alert vehicle 1 that vehicle might have a problem, that could require their assistance.
        }

        private void btnRoadBlock_Click(object sender, EventArgs e)
        {
            lstNotificationV2.Items.Add("Possible Roadblock Ahead.");
            lstNotificationV2.Items.Add("Reduce speed and be cautious!");
           
        }

        private void btnAccident_Click(object sender, EventArgs e)
        {
            lstNotificationV2.Items.Add("Possible Accident Ahead.");
            lstNotificationV2.Items.Add("Reduce speed and be cautious!");
        }

        private void btnHeavyTraffic_Click(object sender, EventArgs e)
        {
            lstNotificationV2.Items.Add("Possible Heavy Traffic Ahead.");
            lstNotificationV2.Items.Add("Look for alternative routes!");
        }
       
    }
}
