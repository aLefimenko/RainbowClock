using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace Clock
{ 
    public partial class Tray : Window
    {
        public MainWindow mn;
        string str_info;
        public Tray() { }
        public Tray(MainWindow fm)
        {
            //str_info = Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.IndexOf("Rainbow Clock")) + "info.txt";
            ShowInTaskbar = false;
            mn = fm;
            InitializeComponent();
            if (mn.inf.bl_lock == true)
            {
                ellipseLockPosition.Visibility = Visibility.Visible;
            }
            else
            {
                ellipseLockPosition.Visibility = Visibility.Hidden;
            }
            if (mn.Topmost == true)
            {
                ellipsePlaceOnTop.Visibility = Visibility.Visible;
            }
            else
            {
                ellipsePlaceOnTop.Visibility = Visibility.Hidden;
            }
            if (mn.inf.bl == true)
            {
                ellipseAnim.Visibility = Visibility.Visible;
            }
            else
            {
                ellipseAnim.Visibility = Visibility.Hidden;
            }
        }
        private void Close(object sender, EventArgs e)
        {
           // mn.windowClose.Begin();
            // MessageBox.Show(str_info);
            Info.ParseInLoad(mn.inf, "D://info.txt");
            mn.ico.Icon = null;         
            //mn.tray1.Close();
            this.Close();
            mn.Close();
        }

        private void Lock(object sender, EventArgs e)
        {
            if (mn.inf.bl_lock == false)
            {
                ellipseLockPosition.Visibility = Visibility.Visible;
                mn.inf.bl_lock = true;
            }
            else
            {
                ellipseLockPosition.Visibility = Visibility.Hidden;
                mn.inf.bl_lock = false;
            }
        }

        private void Center(object sender, EventArgs e)
        {
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            mn.Top = (screenHeight - mn.Height) / 0x00000002 + mn.Height/4 ;
            mn.Left = (screenWidth - mn.Width) / 0x00000002;
            mn.inf.locX = mn.Left;
            mn.inf.locY = mn.Top;
        }

        private void Up(object sender, EventArgs e)
        {
            if (mn.Topmost == true)
            {
                ellipsePlaceOnTop.Visibility = Visibility.Hidden;
                mn.Topmost = false;
            }
            else
            {
                ellipsePlaceOnTop.Visibility = Visibility.Visible;
                mn.Topmost = true;
            }
        }

        private void Anim(object sender, EventArgs e)
        {
            if (mn.inf.bl == true)
            {
                ellipseAnim.Visibility = Visibility.Hidden;
                mn.inf.bl = false;
            }
            else
            {
                ellipseAnim.Visibility = Visibility.Visible;
                mn.transition= DateTime.Now.Hour;
                mn.inf.bl = true;
            }

        }
    }
}
