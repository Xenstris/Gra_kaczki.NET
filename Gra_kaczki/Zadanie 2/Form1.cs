using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool alive = true;
        int shot = 0;
        int all = 0;
       

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;

            trackBar1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            button2.Visible = true;
            textBox2.Visible = true;

            this.BackgroundImage = Image.FromFile("Background22.jpg");


            shot = 0;
            all = 0;

            timer1.Start();
            timer1.Enabled = true;


            kaczka();
           
        }
        //STOP
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            button1.Visible = true;

            trackBar1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            textBox2.Visible = false;

            this.BackgroundImage = Image.FromFile("Background11.jpg");

            using (StreamWriter save = new StreamWriter("dane.txt", true))
            {
                DateTime date1 = DateTime.Now;
                save.WriteLine("Nazwa gracza: " + textBox1.Text + ". Data i godzina gry: " + date1 + ". Wynik to: " + textBox2.Text);
            }


            timer1.Stop();
            kill();
            textBox2.Text = " ";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        public void kaczka()
        {

            alive = true;
            score();

            int time = 2000 / trackBar1.Value;
            double time_min = time * 0.8;
            double time_max = time * 1.2;

            Random czas = new Random();
            timer1.Interval = czas.Next((int)time_min, (int)time_max);

            Button duck = new Button();
            duck.Name = "kaczka";
            duck.Image = Image.FromFile("Duck2.jpg");
            duck.Size = new System.Drawing.Size(125, 125);
            Random rdX = new Random();
            Random rdY = new Random();
            int Y = (50 * timer1.Interval) % 350;
            duck.Location = new System.Drawing.Point(rdX.Next(0,750), rdY.Next(0, Y));
            duck.Click += new System.EventHandler(this.kill);
            Controls.Add(duck);
        }




        private void kill(object sender, EventArgs e)
        {
            int time = 1000;
            timer1.Interval = time;
            var zabij = Controls.Find("kaczka", true);
            if (zabij.Count() != 0)
            {
                zabij[0].Dispose();
            }
            alive = false;
            shot++;
            all++;
            score();

        }
        private void kill()
        {
            int time = 1000;
            timer1.Interval = time;
            var zabij = Controls.Find("kaczka", true);
            if(zabij.Count() != 0)
            {
                zabij[0].Dispose();
            }
            
            all++;
            alive = false;
            score();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alive)
            {
                kill();
            }
            else
            {
                kaczka();
            }
        }

        private void score()
        {
            textBox2.Text = shot.ToString() + "/" + all.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
