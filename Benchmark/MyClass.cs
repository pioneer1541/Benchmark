using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Threading;

namespace Benchmark
{
    class MyClass : System.Windows.Controls.Image
    {
        public string _type;
        public int _speedX;
        public int _speedY;
        public System.Windows.Point pt;
        public string[] _context;
        

        public string get_type()
        {
            return this._type;
        }

        public void set_type(string value)
        {
            this._type = value;
        }


        public int get_speedX()
        {
            return this._speedX;
        }

        public int get_speedY()
        {
            return this._speedY;
        }

        public string get_Context_ToString()
        {
            return this._context[0] + ", X Speed:" + this._context[1] + ", Y Speed:" + this._context[2] + ", Location:" + this._context[3] + ", Direction:" + this._context[4];
        }

        public MyClass (string type, string name, System.Windows.Point pt) {
            Random lucky = new Random();
            int lucky_number = lucky.Next(4);
            int speed = lucky.Next(3, 8);

            this._type = type;
            this.Name = name;
            this._speedX = speed;
            this._speedY = speed;
            this.pt = pt;
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);
            this.Width = 60;
            this.Margin = new Thickness(pt.X - 20, pt.Y - 20, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            string[] direction_Array = new string[] { "RightUp", "RightDown", "LeftUp", "LeftDown" };
            this.Tag = direction_Array[lucky_number];
            this.Initialized += timer_start;
            this._context = new string[5] { this.Name, this._speedX.ToString(), this._speedY.ToString(), this.pt.ToString() ,this.Tag.ToString()};

        }

        public MyClass(string type, string name, System.Windows.Point pt, int speedX, int speedY,string tag)
        {
            Random lucky = new Random();
            int lucky_number = lucky.Next(4);
            int speed = lucky.Next(3, 8);

            this._type = type;
            this.Name = name;
            this._speedX = speed;
            this._speedY = speed;
            this.pt = pt;
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);
            this.Width = 60;
            this.Margin = new Thickness(pt.X, pt.Y, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Tag = tag;
            this.Initialized += timer_start;
            this._context = new string[5] { this.Name, this._speedX.ToString(), this._speedY.ToString(), this.pt.ToString(), this.Tag.ToString() };
        }

        private void timer_start(object sender, EventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(animation_Move);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 66);
            timer.Start();
        }
        public void animation_Move(object sender, EventArgs e)
        {
                Thickness margin = this.Margin;
                
                if (margin.Left >= 390)
                {
                    if (this.Tag.ToString() == "RightUp")
                    {
                        this.Tag = "LeftUp";
                    }
                    else if (this.Tag.ToString() == "RightDown")
                    {
                        this.Tag = "LeftDown";
                    }
                }
                else if (margin.Left <= 0)
                {
                    if (this.Tag.ToString() == "LeftUp")
                    {
                        this.Tag = "RightUp";
                    }
                    else if (this.Tag.ToString() == "LeftDown")
                    {
                        this.Tag = "RightDown";
                    }
                }
                else if (margin.Top >= 340)
                {
                    if (this.Tag.ToString() == "LeftDown")
                    {
                        this.Tag = "LeftUp";
                    }
                    else if (this.Tag.ToString() == "RightDown")
                    {
                        this.Tag = "RightUp";
                    }
                }
                else if (margin.Top <= 2)
                {
                    if (this.Tag.ToString() == "LeftUp")
                    {
                        this.Tag = "LeftDown";
                    }
                    else if (this.Tag.ToString() == "RightUp")
                    {
                        this.Tag = "RightDown";
                    }
                }

                if (this.Tag.ToString() == "LeftDown")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(1, 1);
                this._speedX = 0 - Math.Abs(this._speedX);
                this._speedY = Math.Abs(this._speedY);
                }
                else if (this.Tag.ToString() == "LeftUp")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(1, 1);
                    this._speedX = 0 - Math.Abs(this._speedX);
                    this._speedY = 0 - Math.Abs(this._speedY); ;
                }
                else if (this.Tag.ToString() == "RightUp")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(-1, 1);
                this._speedX = Math.Abs(this._speedX);
                this._speedY = 0 - Math.Abs(this._speedY); ;
            }
                else if (this.Tag.ToString() == "RightDown")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(-1, 1);
                this._speedX = Math.Abs(this._speedX);
                this._speedY = Math.Abs(this._speedY);
            }
                this.Margin = new Thickness(margin.Left + this._speedX, margin.Top + this._speedY, 0, 0);
                this.pt.X = margin.Left;
                this.pt.Y = margin.Top;
                this._context = new string[5] { this.Name, this._speedX.ToString(), this._speedY.ToString(), this.pt.ToString(), this.Tag.ToString() };
        }

    }
}
