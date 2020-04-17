using Elad_s_Migration_Tool.FilesFunctions;
using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.Logs;
using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Elad_s_Migration_Tool.MigrationFormsFunctions
{
    class FixSceneryHandler
    {
        protected static bool imageToolRunning()
        {
            Process[] pname = Process.GetProcessesByName("imagetool");

            return pname.Length > 0;
        }

        protected static bool removeBMPFiles(string sceneryFolder)
        {
            DirectoryInfo dir = new DirectoryInfo(sceneryFolder);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                return false;
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.FullName.ToLower().IndexOf(".bmp") > 0)
                {
                    File.Delete(file.FullName);
                }
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                removeBMPFiles(subdir.FullName);
            }

            return true;
        }

        protected static bool validateSceneryFolder(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                return false;
            }

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.FullName.ToLower().IndexOf(".bmp") > 0)
                {
                    return true;
                }
            }

            foreach (DirectoryInfo subdir in dirs)
            {
                if (validateSceneryFolder(subdir.FullName))
                {
                    return true;
                }
            }

            return false;
        }

        protected static string requestSceneryFolderPath()
        {
            string sceneryFolderPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Please select the scenery folder.";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                sceneryFolderPath = fbd.SelectedPath;
            }

            return sceneryFolderPath;
        }

        protected static bool loadImageTool()
        {
            try
            {
                string currentFolderPath = Directory.GetCurrentDirectory();
                File.WriteAllBytes(currentFolderPath + "\\imagetool.exe", Elad_s_Migration_Tool.Properties.Resources.imagetool);

                return true;
            }
            catch (Exception e)
            {
                ErrorLogger.logError("Could not load image tool - function loadImageTool - " + e.ToString());

                return false;
            }
        }

        protected static bool unloadImageTool()
        {
            try
            {
                string currentFolderPath = Directory.GetCurrentDirectory();
                File.Delete(currentFolderPath + "\\imagetool.exe");

                return true;
            }
            catch (Exception e)
            {
                ErrorLogger.logError("Could not unload image tool - function unloadImageTool - " + e.ToString());

                return false;
            }
        }

        protected static bool backupSceneryFolder(string sceneryFolder)
        {
            if (sceneryFolder == "")
            {
                return false;
            }

            if (!Directory.Exists(sceneryFolder))
            {
                return false;
            }

            DateTime currentTime = DateTime.Now;
            string backupTime = currentTime.ToString("yyyy_MM_dd_HH_mm_ss");
            string backupPath = sceneryFolder + "_" + backupTime;

            return FilesHandler.copyDirectory(sceneryFolder, backupPath);
        }

        protected static void convertToDDS(string sceneryFolder)
        {
            string currentFolderPath = Directory.GetCurrentDirectory();
            string imageToolCommand = "imagetool -batch -nowarning -nogui -dxt5 -dds -nodither -r \"" + sceneryFolder + "\\*.bmp\""; //Converts to DDS with mipmaps

            Helper.executeCommand(currentFolderPath, imageToolCommand);
        }

        public static void runFixScenery()
        {
            string sceneryFolder = requestSceneryFolderPath();

            if (sceneryFolder == "")
            {
                return;
            }

            if (!validateSceneryFolder(sceneryFolder))
            {
                MessageBox.Show("This is not a valid scenery folder, a valid scenery folder must contain .bmp files.");

                return;
            }

            if (!loadImageTool())
            {
                MessageBox.Show("The program was unable to load imagetool.\n" +
                                "If the error persists, please send the error.log file to the author.");
                return;
            }

            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Show();

            if (!backupSceneryFolder(sceneryFolder))
            {
                loadingForm.closeForm();
                unloadImageTool();

                MessageBox.Show("The program was unable to backup the scenery folder.");

                return;
            }

            convertToDDS(sceneryFolder);

            Thread.Sleep(10000); //Waiting a few seconds for the program to load

            while (imageToolRunning())
            {
                Thread.Sleep(1000); //Checking if imagetool is running every second
            }

            unloadImageTool();
            removeBMPFiles(sceneryFolder);

            loadingForm.closeForm();
        }
    }
}