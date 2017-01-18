using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Reflection;

namespace Clock
{
    public partial class MainWindow : Window
    {
        //MailMessage ml = new MailMessage();

        public int transition = DateTime.Now.Hour;
        Storyboard sbOpen;
        Storyboard sbClose;
        public Storyboard windowClose;
       
        public Tray tray1;
        double dd, dd2;
        public Info inf;
        bool bl=false;
        int number = 1;
        int bw = 1;
        string[] str_mas;
        public NotifyIcon ico;
        
        public MainWindow()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            sbOpen = (Storyboard)this.FindResource("StoryboardColor_Copy2");
            sbClose = (Storyboard)this.FindResource("StoryboardColor_Copy3");
            windowClose = (Storyboard)this.FindResource("Storyboard1");     
            ico = new NotifyIcon();
            ico.Icon = Resource1.icon16x16;
            Info.SetAutorunValue(true);
            
            //string str_info = Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.IndexOf("Rainbow Clock"))+"info.txt";
            //System.Windows.MessageBox.Show(str_info);

            try
            {
                StreamReader strRead = new StreamReader("D://info.txt");
                string str = strRead.ReadToEnd();
                //System.Windows.MessageBox.Show(str);
                str_mas = Info.Parse(str);
                inf = new Info(Convert.ToInt32(str_mas[0]), str_mas[1], Convert.ToDouble(str_mas[2]), Convert.ToDouble(str_mas[3]), Convert.ToBoolean(str_mas[4]), Convert.ToBoolean(str_mas[5]));
            }
            catch (Exception)
            {
                inf = new Info(5, "black", 350, 250, true, true);
            }
            //inf.colorInd = Convert.ToInt32(str_mas[0]);
            //inf.coloBack = str_mas[1];
            //inf.locX = Convert.ToDouble(str_mas[2]);
            //inf.locY = Convert.ToDouble(str_mas[3]);
            //inf.bl = Convert.ToBoolean(str_mas[4]);
            //inf.bl_lock = Convert.ToBoolean(str_mas[5]);


            //try
            //{
            //    inf = Info.LoadInfo("D://info.txt");
            //}
            //catch(Exception)
            //{
            //    inf = new Info(1, "black", SystemParameters.PrimaryScreenWidth - this.Width, SystemParameters.PrimaryScreenHeight - this.Height, true, true);
            //}

            ico.Visible = true;
                ico.MouseClick += Ico_MouseClick;
                if (inf.colorInd == 1)
                {
                    buttonRed_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 2)
                {
                    buttonPink_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 3)
                {
                    buttonPurple_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 4)
                {
                    buttonIndigo_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 5)
                {
                    buttonBlue_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 6)
                {
                    buttonCyan_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 7)
                {
                    buttonTeal_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 8)
                {
                    buttonGreen_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 9)
                {
                    buttonLime_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 10)
                {
                    buttonYellow_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 11)
                {
                    buttonAmber_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                else if (inf.colorInd == 12)
                {
                    buttonOrange_Click(new object(), new RoutedEventArgs());
                    transition = DateTime.Now.Hour;
                }
                if (inf.coloBack == "black")
                    buttonBlack_Click(new object(), new RoutedEventArgs());
                else if (inf.coloBack == "white")
                    buttonWhite_Click(new object(), new RoutedEventArgs());
                else if (inf.coloBack == "no")
                    buttonNoColor_Click(new object(), new RoutedEventArgs());
                this.Top = inf.locY;
                this.Left = inf.locX;

            CompositionTarget.Rendering += CompositionTarget_Rendering;            
        }
         
        private void Ico_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (tray1 == null)
                    {
                        if (this.Visibility == Visibility.Visible)
                            this.Visibility = Visibility.Hidden;
                        else
                            this.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        tray1.Close();
                        tray1 = null;
                    }
                }
                else
                {
                    if (tray1 == null)
                    {
                        tray1 = new Tray(this);
                        tray1.Show();
                        if (tray1 != null)
                        {
                            if (System.Windows.Forms.Cursor.Position.Y < System.Windows.SystemParameters.PrimaryScreenHeight - 100 && System.Windows.Forms.Cursor.Position.X > System.Windows.SystemParameters.PrimaryScreenWidth - 100)
                            {
                                dd = -tray1.Height;
                                dd2 = -tray1.Width;
                            }
                            else if (System.Windows.Forms.Cursor.Position.Y < 100)
                            {
                                dd = 0;
                                dd2 = 0;
                            }
                            else
                            {
                                dd = -1 * tray1.Height;
                                dd2 = 0;
                            }
                            tray1.Top = System.Windows.Forms.Cursor.Position.Y + dd;
                            tray1.Left = System.Windows.Forms.Cursor.Position.X + dd2;
                            bl = true;

                        }
                    }
                }
                
           
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            if (tray1 != null&&bl==true)
            {
                if (System.Windows.Forms.Cursor.Position.X < tray1.Left - 15.0 || System.Windows.Forms.Cursor.Position.Y < tray1.Top - 15.0 || System.Windows.Forms.Cursor.Position.X > (tray1.Left + tray1.Width+15) || System.Windows.Forms.Cursor.Position.Y > (tray1.Top +tray1.Height+15))
                {
                    tray1.Close();
                    tray1 = null;
                    bl = false;
                }
            }

            if (dt.ToLongTimeString().IndexOf(':') == 2)
            {
                Time.Text = dt.ToLongTimeString().Substring(0, 5);
            }
            else
            {
                Time.Text = dt.ToLongTimeString().Substring(0, 4);
            }
            Date.Text = dt.ToShortDateString();

            if (dt.Second > 58)
            {
                Seconds.EndAngle = -6 * 50 * (dt.Second + dt.Millisecond / 1000.0);
            }
            else
            {
                Seconds.EndAngle = 6 * dt.Second;
            }

            if (dt.Minute > 58 && dt.Second > 58)
            {
                Minutes.EndAngle = -6 * 50 * (dt.Second + dt.Millisecond / 1000.0);
            }
            else
            {
                Minutes.EndAngle = 6 * dt.Minute;
            }

            if ((dt.Hour == 11 || dt.Hour == 23) && dt.Minute > 58 && dt.Second > 58)
            {
                Hours.EndAngle = -6 * 50 * (dt.Second + dt.Millisecond / 1000.0);
            }
            else if (dt.Hour <= 11)
            {
                Hours.EndAngle = 30 * dt.Hour;
            }
            else if (dt.Hour > 11)
                Hours.EndAngle = 30 * (dt.Hour % 12);
                if (transition != DateTime.Now.Hour && inf.bl == true)
                {
                    if (inf.colorInd == 12)
                    {
                        buttonRed_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 1)
                    {
                        buttonPink_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 2)
                    {
                        buttonPurple_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 3)
                    {
                        buttonIndigo_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 4)
                    {
                        buttonBlue_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 5)
                    {
                        buttonCyan_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 6)
                    {
                        buttonTeal_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 7)
                    {
                        buttonGreen_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 8)
                    {
                        buttonLime_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 9)
                    {
                        buttonYellow_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 10)
                    {
                        buttonAmber_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                    else if (inf.colorInd == 11)
                    {
                        buttonOrange_Click(new object(), new RoutedEventArgs());
                        transition = DateTime.Now.Hour;
                    }
                }
                
            
        }

        private void buttonRed_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 1;
            Brush s = new SolidColorBrush(Color.FromRgb(183, 28, 28));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(211, 47, 47));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(244, 67, 54));
            Hours.Stroke = h;

        }

        private void buttonPink_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 2;
            Brush s = new SolidColorBrush(Color.FromRgb(136, 14, 79));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(194, 24, 91));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(233, 30, 99));
            Hours.Stroke = h;
        }

        private void buttonPurple_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 3;
            Brush s = new SolidColorBrush(Color.FromRgb(74, 20, 140));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(123, 31, 162));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(156, 39, 176));
            Hours.Stroke = h;
        }

        private void buttonIndigo_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 4;
            Brush s = new SolidColorBrush(Color.FromRgb(26, 35, 126));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(48, 63, 159));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(63, 81, 181));
            Hours.Stroke = h;
        }

        private void buttonBlue_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 5;
            Brush s = new SolidColorBrush(Color.FromRgb(13, 71, 161));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(25, 118, 210));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            Hours.Stroke = h;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {  
            if (inf.bl_lock == false)
            {
                this.DragMove();
                base.OnMouseLeftButtonDown(e);
                inf.locX = this.Left;
                inf.locY = this.Top;     
            }
            if (tray1 != null)
            {
                tray1.Close();
                tray1 = null;
            }
        }

        protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
        {
            if (number == 1)
            {
                sbOpen.Begin();
                number++;
            }
            else
            {
                sbClose.Begin();
                number--;
            }
        }

        private void buttonCyan_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 6;
            Brush s = new SolidColorBrush(Color.FromRgb(0, 96, 100));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(0, 151, 167));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(0, 188, 212));
            Hours.Stroke = h;
        }

        private void buttonTeal_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 7;
            Brush s = new SolidColorBrush(Color.FromRgb(0, 77, 64));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(0, 121, 107));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(0, 150, 136));
            Hours.Stroke = h;
        }

        private void buttonGreen_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 8;
            Brush s = new SolidColorBrush(Color.FromRgb(27, 94, 32));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(56, 142, 60));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(76, 175, 80));
            Hours.Stroke = h;
        }

        private void buttonLime_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 9;
            Brush s = new SolidColorBrush(Color.FromRgb(130, 119, 23));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(175, 180, 43));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(205, 220, 57));
            Hours.Stroke = h;
        }

        private void buttonYellow_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 10;
            Brush s = new SolidColorBrush(Color.FromRgb(245, 127, 23));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(251, 192, 45));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(255, 235, 59));
            Hours.Stroke = h;
        }

        private void buttonAmber_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 11;
            Brush s = new SolidColorBrush(Color.FromRgb(255, 111, 0));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(255, 160, 0));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(255, 193, 7));
            Hours.Stroke = h;
        }

        private void buttonOrange_Click(object sender, RoutedEventArgs e)
        {
            inf.colorInd = 12;
            Brush s = new SolidColorBrush(Color.FromRgb(230, 81, 0));
            Seconds.Stroke = s;
            Brush m = new SolidColorBrush(Color.FromRgb(245, 124, 0));
            Minutes.Stroke = m;
            Brush h = new SolidColorBrush(Color.FromRgb(255, 152, 0));
            Hours.Stroke = h;
        }

        private void buttonBlack_Click(object sender, RoutedEventArgs e)
        {
            Brush b = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            background.Fill = b;
            background.Fill.Opacity = 0.9;
            //background.Opacity = 0.65;
            Brush t = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Time.Foreground = t;
            Date.Foreground = t;
            inf.coloBack = "black";
        }

        private void buttonWhite_Click(object sender, RoutedEventArgs e)
        {
            Brush b = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            background.Fill = b;
            background.Fill.Opacity = 0.8;
            //background.Opacity = 0.65;
            Brush t = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            Time.Foreground = t;
            Date.Foreground = t;
            inf.coloBack = "white";
        }

        private void buttonNoColor_Click(object sender, RoutedEventArgs e)
        {
            Brush b = new SolidColorBrush(Color.FromArgb(0,0, 0, 0));
            background.Fill = b;
            Brush t = null;
            if (bw == 1)
            {
                t = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bw++;
            }
            else
            {
                t = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                bw--;
            }
            Time.Foreground = t;
            Date.Foreground = t;
            inf.coloBack = "no";
        }
    }
}
