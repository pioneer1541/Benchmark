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

namespace Benchmark
{
    class MyClass : System.Windows.Controls.Image
    {
        private string _type;
        private string _name;
        private int _speedX;
        private int _speedY;
        private string[] _context;

        public string get_type()
        {
            return this._type;
        }

        public void set_type(string value)
        {
            this._type = value;
        }

        public string get_name()
        {
            return this._name;
        }

        public void set_name(string value)
        {
            this._name = value;
        }

        public int get_speedX()
        {
            return this._speedX;
        }

        public int get_speedY()
        {
            return this._speedY;
        }

        public string get_context()
        {
           return this._context[0] + "," + this._context[1] + "," + this._context[2];
        }


        public void set_context(int index,string value)
        {
            this._context[index] = value;
        }

        public MyClass (string type, string name, Point pt, int speedX = 4,int speedY = 6) {
            this._type = type;
            this._name = name;
            this._speedX = speedX;
            this._speedY = speedY;
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);
            this.Width = 60;
            this.Margin = new Thickness(pt.X - 20, pt.Y - 20, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Tag = "RightUp";
            this._context = new string[3]{ this._name , "speedX: " + this._speedX,"speedY: " + speedY };
            this.Initialized += img_timer;
        }

        private void img_timer(object sender, EventArgs e)
        {
            Timer timer = new Timer(animation_Move, sender, 0, 66);
            GCHandle gch = GCHandle.Alloc(timer);
        }
        public void animation_Move(object sender)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate {
                Image animal = new Image();
                animal = sender as Image;
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
                    animal.Margin = new Thickness(margin.Left - 5, margin.Top + 4, 0, 0);
                }
                else if (animal.Tag.ToString() == "LeftUp")
                {
                    animal.Margin = new Thickness(margin.Left - 5, margin.Top - 4, 0, 0);
                }
                else if (animal.Tag.ToString() == "RightUp")
                {
                    animal.Margin = new Thickness(margin.Left + 4, margin.Top - 6, 0, 0);
                }
                else if (animal.Tag.ToString() == "RightDown")
                {
                    animal.Margin = new Thickness(margin.Left + 4, margin.Top + 6, 0, 0);
                }
            });
        }
    }
}
