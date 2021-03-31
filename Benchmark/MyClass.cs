using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Benchmark
{
    public class MyClass : System.Windows.Controls.Image
    {
        public string type; //Animal type.
        public int speedX;  //The speed of X direction
        public int speedY;  //The speed of Y direction
        public System.Windows.Point pt; //The location of the object.
        public string context; //A string sentence for the object list.

        public MyClass(string type, string name, System.Windows.Point pt)
        {
            //construction function of creating new object without loading data.
            //This class is a subclass of Image Controls Class.

            //Decide a animal type and name by random
            Random lucky = new Random();
            int lucky_number = lucky.Next(4);
            this.type = type;
            this.Name = name;

            //Decide initial moving speed
            int speed = lucky.Next(3, 8);
            this.speedX = speed;
            this.speedY = speed;

            //Setting image for Image Control base on the type.
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);

            this.Width = 60;
            this.Margin = new Thickness(pt.X - 20, pt.Y - 20, 0, 0);

            //Setting alignment for match the location of the scene.
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;

            //Decide initial moving direction base on random.
            string[] direction_Array = new string[] { "RightUp", "RightDown", "LeftUp", "LeftDown" };
            this.Tag = direction_Array[lucky_number]; //This property is for moving strategy
            this.Initialized += timer_start; //Setting initial event to a timer method.
            this.context = this.Name + ", X Speed:" + this.speedX.ToString() + ", Y Speed:" + this.speedY.ToString() + ", Location:" + this.pt.ToString() + ", Direction:" + this.Tag.ToString();


        }

        public MyClass(string type, string name, System.Windows.Point pt, int speedX, int speedY, string tag)
        //construction function of creating new object with loading data.
        //All properties are used the same as the construction function above.
        {
            Random lucky = new Random();
            int lucky_number = lucky.Next(4);
            int speed = lucky.Next(3, 8);
            this.type = type;
            this.Name = name;
            this.speedX = speedX;
            this.speedY = speedY;
            var uriSource = new Uri("./Resources/" + type + "_img.gif", UriKind.Relative);
            this.Source = new BitmapImage(uriSource);
            this.Width = 60;
            this.Margin = new Thickness(pt.X, pt.Y, 0, 0);
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Top;
            this.Tag = tag;
            this.Initialized += timer_start;
            this.context = this.Name + ", X Speed:" + this.speedX.ToString() + ", Y Speed:" + this.speedY.ToString() + ", Location:" + this.pt.ToString() + ", Direction:" + this.Tag.ToString();
        }

        private void Timer_Start(object sender, EventArgs e)
        //The timer function is designed for the control's moving strategy.
        //The move action will be executed every 66 milliseconds
        {
            try
            {
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += new EventHandler(Animation_Move);
                timer.Interval = new TimeSpan(0, 0, 0, 0, 66);
                timer.Start();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Animation_Move(object sender, EventArgs e)
        //This method defines the moving action of an Image Control base on the state machine.
        //When an Image Controls location on a margin of the rectangle,it will be change its moving strategy base on its state.
        //When an Image Controls is going to make a turn,its image will be setted to do a mirror flip.
        {
            try
            {
                Thickness margin = this.Margin;
                //This part is for deciding Image Controls' state.
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

                //This part is for deciding Image Controls' move direction.
                if (this.Tag.ToString() == "LeftDown")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(1, 1);
                    this.speedX = 0 - Math.Abs(this.speedX);
                    this.speedY = Math.Abs(this.speedY);
                }
                else if (this.Tag.ToString() == "LeftUp")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(1, 1);
                    this.speedX = 0 - Math.Abs(this.speedX);
                    this.speedY = 0 - Math.Abs(this.speedY); ;
                }
                else if (this.Tag.ToString() == "RightUp")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(-1, 1);
                    this.speedX = Math.Abs(this.speedX);
                    this.speedY = 0 - Math.Abs(this.speedY); ;
                }
                else if (this.Tag.ToString() == "RightDown")
                {
                    this.LayoutTransform = new System.Windows.Media.ScaleTransform(-1, 1);
                    this.speedX = Math.Abs(this.speedX);
                    this.speedY = Math.Abs(this.speedY);
                }
                this.Margin = new Thickness(margin.Left + this.speedX, margin.Top + this.speedY, 0, 0);
                this.pt.X = margin.Left;
                this.pt.Y = margin.Top;

                //Updating a context of the object for object list.
                this.context = this.Name + ", X Speed:" + this.speedX.ToString() + ", Y Speed:" + this.speedY.ToString() + ", Location:" + this.pt.ToString() + ", Direction:" + this.Tag.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
