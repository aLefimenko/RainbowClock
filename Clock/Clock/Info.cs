using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;

namespace Clock
{
    public class Info
    {
        public int colorInd { get; set; }
        public string coloBack { get; set; }
        public double locX { get; set; }
        public double locY { get; set; }
        public bool bl { get; set; }
        public bool bl_lock { get; set; }
        public Info()
        {
            this.locX = 0;
            this.locY = 0;
            this.coloBack = null;
            this.colorInd = 0;
            this.bl = false;
            this.bl_lock = false;
        }
        public Info(int _color,string backcol, double x, double y, bool bll, bool bl_lockk)
        {
            this.coloBack = backcol;
            this.locX = x;
            this.locY = y;
            this.colorInd = _color;
            this.bl = bll;
            this.bl_lock = bl_lockk;
        }

        public static string[] Parse(string str)
        {
            return str.Split(',');
        }

        public static void ParseInLoad(Info info,string str)
        {
            File.WriteAllText(str,info.colorInd.ToString() + "," + info.coloBack.ToString() + "," + info.locX.ToString() + "," + info.locY.ToString() + "," + info.bl.ToString() + "," + info.bl_lock.ToString());       
        }
        //public static Info LoadInfo(string FileName)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(Info));
        //    StreamWriter str_wr = new StreamWriter("info.txt");
        //    str_wr.Write(FileName);
        //    str_wr.Close();
        //    using (TextReader textReader = new StreamReader("info.txt"))
        //    {
        //        return (Info)serializer.Deserialize(textReader);    
        //    }
            
        //}
        const string name = "Clock";
        public static bool SetAutorunValue(bool autorun)
        {
            string ExePath = System.Windows.Forms.Application.ExecutablePath;
            RegistryKey reg;
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                    reg.SetValue(name, ExePath);
                else
                    reg.DeleteValue(name);

                reg.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
