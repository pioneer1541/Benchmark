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
            this._type = type;
            this.Name = name;
            this._speedX = 4;
            this._speedY = 6;
            this.pt = pt;
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);
            this.Width = 60;
            this.Margin = new Thickness(pt.X - 20, pt.Y - 20, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            string[] direction_Array = new string[] { "RightUp", "RightDown", "LeftUp", "LeftDown" };
            Random lucky = new Random();
            int lucky_number = lucky.Next(4);
            this.Tag = direction_Array[lucky_number];
            this.Initialized += img_timer;
            this._context = new string[5] { this.Name, this._speedX.ToString(), this._speedY.ToString(), this.pt.ToString() ,this.Tag.ToString()};

        }

        public MyClass(string type, string name, System.Windows.Point pt, int speedX, int speedY,string tag)
        {
            this._type = type;
            this.Name = name;
            this._speedX = speedX;
            this._speedY = speedY;
            this.pt = pt;
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);
            this.Width = 60;
            this.Margin = new Thickness(pt.X, pt.Y, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Tag = tag;
            this.Initialized += img_timer;
            this._context = new string[5] { this.Name, this._speedX.ToString(), this._speedY.ToString(), this.pt.ToString(), this.Tag.ToString() };
        }

        private void img_timer(object sender, EventArgs e)
        {
            Timer timer = new Timer(animation_Move, sender, 0, 66);
            GCHandle gch = GCHandle.Alloc(timer);
        }
        public void animation_Move(object sender)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                System.Windows.Controls.Image animal = new System.Windows.Controls.Image();
                animal = sender as System.Windows.Controls.Image;
                Thickness margin = animal.Margin;
                
                if (margin.Left >= 390)
                {
                    if (animal.Tag.ToString() == "RightUp")
                    {
                        animal.Tag = "LeftUp";
                    }
                    else if (animal.Tag.ToString() == "RightDown")
                    {
                        animal.Tag = "LeftDown";
                    }
                }
                else if (margin.Left <= 2)
                {
                    if (animal.Tag.ToString() == "LeftUp")
                    {
                        animal.Tag = "RightUp";
                    }
                    else if (animal.Tag.ToString() == "LeftDown")
                    {
                        animal.Tag = "RightDown";
                    }
                }
                else if (margin.Top >= 340)
                {
                    if (animal.Tag.ToString() == "LeftDown")
                    {
                        animal.Tag = "LeftUp";
                    }
                    else if (animal.Tag.ToString() == "RightDown")
                    {
                        animal.Tag = "RightUp";
                    }
                }
                else if (margin.Top <= 2)
                {
                    if (animal.Tag.ToString() == "LeftUp")
                    {
                        animal.Tag = "LeftDown";
                    }
                    else if (animal.Tag.ToString() == "RightUp")
                    {
                        animal.Tag = "RightDown";
                    }
                }

                if (animal.Tag.ToString() == "LeftDown")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(1, 1);
                    this._speedX = -6;
                    this._speedY = 4;
                }
                else if (animal.Tag.ToString() == "LeftUp")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(1, 1);
                    this._speedX = -6;
                    this._speedY = -4;
                }
                else if (animal.Tag.ToString() == "RightUp")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(-1, 1);
                    this._speedX = 4;
                    this._speedY = -6;
                }
                else if (animal.Tag.ToString() == "RightDown")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(-1, 1);
                    this._speedX = 6;
                    this._speedY = 4;
                }
                animal.Margin = new Thickness(margin.Left + this._speedX, margin.Top + this._speedY, 0, 0);
                this.pt.X = margin.Left;
                this.pt.Y = margin.Top;
                this._context = new string[5] { this.Name, this._speedX.ToString(), this._speedY.ToString(), this.pt.ToString(), this.Tag.ToString() };
            });
        }
    }
}
