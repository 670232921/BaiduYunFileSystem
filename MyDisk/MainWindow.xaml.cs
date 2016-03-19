using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Linq;

namespace MyDisk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string encryptKey = "Side";    //定义密钥  
        const string REGRoot = "SOFTWARE\\MyApp\\Baidudisk";
        Dictionary<string, BaiduDisk> logedins = new Dictionary<string, BaiduDisk>();
        System.Windows.Forms.NotifyIcon icon = new System.Windows.Forms.NotifyIcon();
        bool exit = false;

        public MainWindow()
        {
            InitializeComponent();
            icon.Icon = MyDisk.Properties.Resources.baidu;
            icon.Text = "百度云本地磁盘";
            icon.Click += Icon_Click;
            icon.Visible = true;
            LoadFromReg();
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            //this.WindowState = WindowState.Normal;
            this.ShowInTaskbar = true;
            this.Visibility = Visibility.Visible;
        }

        private void LoadFromReg()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGRoot);
            var names = key.GetValueNames();
            foreach (string name in names)
            {
                var pas = Decrypt(key.GetValue(name).ToString());
                StratThread(name, pas);
            }
        }

        private void StratThread(string user, string pass)
        {
            string[] ss = new string[2];
            ss[0] = user;
            ss[1] = pass;
            var ht = new Thread(Start1);
            ht.IsBackground = true;
            ht.Start(ss);
        }

        private void LoginSuccess(string user, string pass, bool succ, BaiduDisk disk)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (succ)
                {
                    Notification.Text += user + " 登录成功\r\n";
                    logedins.Add(user, disk);
                    listBox.Items.Add(user);
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(REGRoot);
                    key.SetValue(user, Encrypt(pass));
                    this.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Notification.Text += user + " 登录失败\r\n";
                }
            }));
        }

        private void Start1(object data)
        {
            string[] par = data as string[];
            int err = 0;
            Pfm.Api pfm = null;
            Pfm.Mount mount = null;
            Pfm.MountCreateParams mcp = new Pfm.MountCreateParams();
            Pfm.MarshallerServeParams msp = new Pfm.MarshallerServeParams();
            BaiduDisk volume = new BaiduDisk(par[0], par[1]);
            LoginSuccess(par[0], par[1], volume.IsAviliable(), volume);
            if (!volume.IsAviliable())
            {
                return;
            }

            IntPtr invalidFd = new IntPtr(-1);

            msp.dispatch = volume;
            msp.formatterName = "BaiduDisk";

            //if (args.Length != 1)
            //{
            //    Console.Write(
            //       "Sample file system application.\n" +
            //       "syntax: hellofs <mount name>\n");
            //    err = -1;
            //}
            if (err == 0)
            {
                mcp.mountSourceName = par[0];
                DriveInfo[] dinfos = DriveInfo.GetDrives();
                string tem = "CDEFGHIJKLMNOPQRSTUVWXYZ";
                char dltter = tem.ToCharArray().First(c => !dinfos.Any(i => i.Name.StartsWith(c.ToString())));
                mcp.driveLetter = dltter;
                err = Pfm.ApiFactory(out pfm);
                if (err != 0)
                {
                    Console.Write("ERROR: {0} Unable to open PFM API.\n", err);
                }
            }
            if (err == 0)
            {
                err = Pfm.MarshallerFactory(out volume.marshaller);
                if (err != 0)
                {
                    Console.Write("ERROR: {0} Unable to create marshaller.\n", err);
                }
            }
            if (err == 0)
            {
                // Communication between the driver and file system is done
                // over a pair of simple pipes. Application is responsible
                // for creating the pipes.
                err = Pfm.SystemCreatePipe(out msp.toFormatterRead, out mcp.toFormatterWrite);
                if (err == 0)
                {
                    err = Pfm.SystemCreatePipe(out mcp.fromFormatterRead, out msp.fromFormatterWrite);
                }
            }
            if (err == 0)
            {
                // Various mount options are available through mountFlags,
                // visibleProcessId, and ownerSid.
                err = pfm.MountCreate(mcp, out mount);
                if (err != 0)
                {
                    Console.Write("ERROR: {0} Unable to create mount.\n", err);
                }
            }

            // Close driver end pipe handles now. Driver has duplicated what
            // it needs. If these handles are not closed then pipes will not
            // break if driver disconnects, leaving us stuck in the
            // marshaller.
            Pfm.SystemCloseFd(mcp.toFormatterWrite);
            Pfm.SystemCloseFd(mcp.fromFormatterRead);

            if (err == 0)
            {
                // If tracemon is installed and running then diagnostic
                // messsages can be viewed in the "hellofs" channel.
                volume.marshaller.SetTrace(mount.GetMountEndName());
                // Also send diagnostic messages to stdout. This can slow
                // things down quite a bit.
                IntPtr stdoutFd = invalidFd;
                Pfm.SystemGetStdout(out stdoutFd);
                volume.marshaller.SetStatus(stdoutFd);

                // The marshaller uses alertable I/O, so process can be
                // exited via ctrl+c.
                Console.Write("Press CTRL+C to exit.\n");
                // The marshaller serve function will return at unmount or
                // if driver disconnects.
                volume.marshaller.ServeDispatch(msp);
            }

            Pfm.SystemCloseFd(msp.toFormatterRead);
            Pfm.SystemCloseFd(msp.fromFormatterWrite);
            if (pfm != null)
            {
                pfm.Dispose();
            }
            if (mount != null)
            {
                mount.Dispose();
            }
            if (volume.marshaller != null)
            {
                volume.marshaller.Dispose();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!listBox.Items.Contains(user.Text))
            {
                StratThread(user.Text, pass.Password);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                var disk = logedins[listBox.SelectedItem.ToString()];
                if (disk != null)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(REGRoot);
                    key.DeleteValue(listBox.SelectedItem.ToString());
                    disk.marshaller.ServeCancel();
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            exit = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            this.ShowInTaskbar = false;
            //this.WindowState = WindowState.Minimized;
            icon.Visible = !exit;
            e.Cancel = !exit;
        }




        #region 加密字符串  

        /// <summary> /// 加密字符串   

        /// </summary>  

        /// <param name="str">要加密的字符串</param>  

        /// <returns>加密后的字符串</returns>  

        static string Encrypt(string str)

        {

            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   



            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    



            byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  



            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      



            //使用内存流实例化加密流对象   

            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);



            CStream.Write(data, 0, data.Length);  //向加密流中写入数据      



            CStream.FlushFinalBlock();              //释放加密流      



            return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  

        }

        #endregion



        #region 解密字符串   

        /// <summary>  

        /// 解密字符串   

        /// </summary>  

        /// <param name="str">要解密的字符串</param>  

        /// <returns>解密后的字符串</returns>  

        static string Decrypt(string str)

        {

            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    



            byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    



            byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  



            MemoryStream MStream = new MemoryStream(); //实例化内存流对象      



            //使用内存流实例化解密流对象       

            CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);



            CStream.Write(data, 0, data.Length);      //向解密流中写入数据     



            CStream.FlushFinalBlock();               //释放解密流      



            return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  

        }

        #endregion
    }
}
