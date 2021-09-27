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
using System.Threading;
using System.Threading.Tasks;



namespace CleanUpProject
{
    //File.Copy(Application.ExecutablePath, @"D:\Temp\myFile.EXE");


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label3.Visible = true;
            label3.Text = DisplayInfo().ToString() + " MB";
        }

        enum browser : int          //Browser Enum
        {

            Chrome,
            Edge,
            Opera,
            FireFox,
        }



        private void cleanbtn_Click(object sender, EventArgs e)
        {

            this.listBox1.Items.Clear();
            if (ChromeChkbox.Checked)
            {

               Task chrome = new Task (() => Clearbrowsercache((int)browser.Chrome));
                chrome.RunSynchronously();

            }

            if (EdgeChkbox.Checked)
            {

                Task edge = new Task (() => Clearbrowsercache((int)browser.Edge));
                edge.RunSynchronously();
            }

            if (WinChkbox.Checked)
            {

                Task windows = new Task(() => WindowsCache());
                windows.RunSynchronously();
            }

            label4.Visible = true;
            label4.Text = DisplayInfo().ToString() + " MB";

            //Confirmation Dialogue
            string message = "Junk and Cache Cleared Succesfully";
            string title = "Confirmation";
            MessageBox.Show(message, title);
        }

        public void WindowsCache ()
        {
            /*
               @echo off
               del / s / f / q % windir %\temp\*.*
               rd / s / q % windir %\temp
               md % windir %\temp
               del / s / f / q % windir %\Prefetch\*.*
               rd / s / q % windir %\Prefetch
               md % windir %\Prefetch
               del / s / f / q % windir %\system32\dllcache\*.*
               rd / s / q % windir %\system32\dllcache
               md % windir %\system32\dllcache
               del / s / f / q "%SysteDrive%\Temp"\*.*
               rd / s / q "%SysteDrive%\Temp"
               md "%SysteDrive%\Temp"
               del / s / f / q % temp %\*.*
               rd / s / q % temp %
               */
            //Delete temporary folder
            DirectoryInfo di = new DirectoryInfo(Path.GetTempPath());
            ClearTempData(di);

            string s = Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\temp\\";
            DirectoryInfo to = new DirectoryInfo(s);
            ClearTempData(to);

            //Delete RecycleBin Calling Shell32 Dll for clearing Recycle Bin
            uint result = SHEmptyRecycleBin(IntPtr.Zero, null, 0);


        }

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)] //Dll Import

        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000001,
            SHERB_NOSOUND = 0x00000004
        }

        public void Clearbrowsercache(int browser)
        {

            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = Environment.UserName; // for getting user name

            switch (browser)
            {

                case 0 :

                    //For internet explorer
                    Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");

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


                        DirectoryInfo downloadedMessageInfo = new DirectoryInfo(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default");


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


                case 1 :

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


                            DirectoryInfo dMinfo = new DirectoryInfo(rootDrive + "Users\\" + userName + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default");

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

        public void ClearTempData(DirectoryInfo di)
        {
            try
            {
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        
                        file.Delete();
                        this.listBox1.Items.Add(file.FullName);
                        Console.WriteLine(file.FullName);
                    }
                    catch (Exception ex)
                    {

                        if (ex is UnauthorizedAccessException)
                            continue;
                        else
                            continue;

                    }
                }

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                        this.listBox1.Items.Add(dir.FullName);
                        Console.WriteLine(dir.FullName);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            } catch (Exception)
            {
                this.listBox1.Items.Add(di);
            }
        }

       
        public float DisplayInfo() //Displaying Information on the Panel
        {

            string rootDrive = Path.GetPathRoot(Environment.SystemDirectory); // for getting primary drive 
            string userName = Environment.UserName; // for getting user name

            float s = 0;

            string[] folderpath = { "C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\"
                               ,Path.GetTempPath()
                               ,Path.GetPathRoot(Environment.SystemDirectory) + "Windows\\temp\\"
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome", "https://github.com/studio-suman/CleanUpProject/tree/master#readme");
        }
    }
}
