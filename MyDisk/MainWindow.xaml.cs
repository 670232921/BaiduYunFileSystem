using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;

namespace MyDisk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, BaiduDisk> logedins = new Dictionary<string, BaiduDisk>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StratThread()
        {
            string[] ss = new string[2];
            ss[0] = user.Text;
            ss[1] = pass.Password;
            var ht = new Thread(Start1);
            ht.IsBackground = true;
            ht.Start(ss);
        }

        private void LoginSuccess(string user, bool succ, BaiduDisk disk)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (succ)
                {
                    Notification.Content = "登录成功";
                    logedins.Add(user, disk);
                    listBox.Items.Add(user);
                }
                else
                {
                    Notification.Content = "登录失败";
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
            LoginSuccess(par[0], volume.IsAviliable(), volume);
            if (!volume.IsAviliable())
            {
                return;
            }

            IntPtr invalidFd = new IntPtr(-1);

            msp.dispatch = volume;
            msp.formatterName = "hellofs";

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
            StratThread();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                var disk = logedins[listBox.SelectedItem.ToString()];
                if (disk != null)
                {
                    disk.marshaller.ServeCancel();
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
        }
    }
}
