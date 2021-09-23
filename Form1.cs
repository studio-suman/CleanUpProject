using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;



namespace CleanUpProject
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label3.Visible = true;
            label3.Text = DisplayInfo().ToString() + " MB";
        }

        enum browser : int
        {

            Chrome,
            Edge,
            Opera,
            FireFox,
        }

        private void cleanbtn_Click(object sender, EventArgs e)
        {

            if (ChromeChkbox.Checked)
            {

                clearbrowsercache((int)browser.Chrome);

            }

            if (EdgeChkbox.Checked)
            {

                clearbrowsercache((int)browser.Edge);

            }

            if (WinChkbox.Checked)
            {

                //Delete temporary folder
                System.IO.DirectoryInfo di = new DirectoryInfo(System.IO.Path.GetTempPath());
                ClearTempData(di);

                //Delete RecycleBin Calling Shell32 Dll for clearing Recycle Bin
                uint result = SHEmptyRecycleBin(IntPtr.Zero, null, 0);

            }

            label4.Visible = true;
            label4.Text = DisplayInfo().ToString() + " MB";

            //Confirmation Dialogue
            string message = "Junk and Cache Cleared Succesfully";
            string title = "Confirmation";
            MessageBox.Show(message, title);
        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]

        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }

        public static void clearbrowsercache(int browser)
        {

            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = Environment.UserName; // for getting user name

            switch (browser)
            {

                case 1 :

                    //For internet explorer
                    System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");

                    // for Google Chrome.

                    // first close all the extension of chrome (close all the chrome browser which are opened)

                    try
                    {
                        Process[] Path1 = Process.GetProcessesByName("chrome");
                        foreach (Process p in Path1)
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch { }
                            p.WaitForExit();
                            p.Dispose();
                        }


                        System.IO.DirectoryInfo downloadedMessageInfo = new DirectoryInfo(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default");


                        try
                        {
                            ClearTempData(downloadedMessageInfo);
                        }
                        catch { }

                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;


                case 2 :

                    // for Edge.

                    // first close all the extension of Edge (close all the edge browser which are opened)

                    try
                    {
                        Process[] Path1 = Process.GetProcessesByName("msedge");
                        foreach (Process p in Path1)
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch { }
                            p.WaitForExit();
                            p.Dispose();
                        }


                        System.IO.DirectoryInfo dMinfo = new DirectoryInfo(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default");

                        try
                        {
                            ClearTempData(dMinfo);
                        }
                        catch { }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    break;
            }

        }

        private static void ClearTempData(DirectoryInfo di)
        {
            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                    Console.WriteLine(file.FullName);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    Console.WriteLine(dir.FullName);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }


        public float DisplayInfo()
        {

            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = Environment.UserName; // for getting user name

            float s = 0;

            string[] folderpath = { "C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\"
                               ,System.IO.Path.GetTempPath()
                               ,"C:\\Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default"
                               ,"C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History-journal"
                               ,"C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies"
                               ,"C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies-journal"
                               ,"C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies-journal"
        };

            try
            {

                foreach (var folder in folderpath)
                {

                    var files = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);

                    long totalSize = 0;

                    foreach (string name in files)
                    {
                        var info = new FileInfo(name);
                        totalSize += info.Length;

                    }

                    s = (float)totalSize / (1024 * 1024);
                }

            }

            catch
            { }

            return s;

        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (CloseCancel() == false)
            {
                e.Cancel = true;
            };
        }

        public static bool CloseCancel()
        {
            const string message = "Are you sure you want to exit off the application";
            const string caption = "Close Application";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

    }
}
