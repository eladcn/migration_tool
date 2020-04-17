using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.RegistryFunctions;
using Elad_s_Migration_Tool.FilesFunctions;
using Elad_s_Migration_Tool.MigrationFormsFunctions;

namespace Elad_s_Migration_Tool.Logs
{
    class HistoryHandler
    {
        protected static string historyFileName = "history.log";
        protected static int[] HISTORY_TYPES = {1, 2, 3};

        /**
         * Gives the hidden attribute to the file.
         */
        protected static void hideHistoryFile()
        {
            if (!File.Exists(historyFileName))
            {
                return;
            }

            FileAttributes attributes = File.GetAttributes(historyFileName);

            if ((attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
            {
                File.SetAttributes(historyFileName, FileAttributes.Hidden);
            }
        }

        /**
         * Appends a line to the history file.
         */
        public static void appendHistory(string data)
        {
            Helper.writeLineToText(historyFileName, data);
            hideHistoryFile();
        }

        /**
         * Deletes the history log file (if exists).
         */
        public static bool deleteHistoryFile()
        {
            if (File.Exists(historyFileName))
            {
                try
                {
                    File.Delete(historyFileName);

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        /**
         * Sets the content of the history file using a given List that includes all the rows.
         */
        public static void setHistory(List<string> data)
        {
            deleteHistoryFile();

            Helper.setTextFileContent(historyFileName, data);

            hideHistoryFile();
        }

        /**
         * Returns a list that includes all the content of the history file.
         */
        public static List<string> getHistory()
        {
            return Helper.getTextFileContent(historyFileName);
        }

        /**
         * Returns whether the history file is empty.
         */
        public static bool isEmptyHistoryFile()
        {
            List<string> history = getHistory();

            return history.Count <= 0;
        }

        /**
         * Returns whether a row in the history file is valid and was not tampered with.
         */
        protected static bool isValidHistoryRow(string row){
            if(row.IndexOf(',') < 0){
                return false;
            }

            var rowItems = row.Split(',');

            if (rowItems.Length < 2)
            {
                return false;
            }

            int itemType = Int32.Parse(rowItems[0]);

            if (!HISTORY_TYPES.Contains(itemType))
            {
                return false;
            }

            return true;
        }

        /**
         * Reverts all changes according to the history file.
         */
        public static bool revertChanges()
        {
            FileListeners.removeListeners();

            List<string> history = getHistory();
            history.Reverse();
            List<string> newHistory = new List<string>(history);

            foreach (string item in history)
            {
                if (!isValidHistoryRow(item))
                {
                    newHistory.Remove(item);

                    continue;
                }

                string[] itemData = item.Split(',');
                int itemType = Int32.Parse(itemData[0]);
                int simOptionVal;
                SimulatorOption simOption;

                switch (itemType)
                {
                    case 1:
                        //Revert registry changes.
                        simOptionVal = Int32.Parse(itemData[1]);
                        simOption = SimulatorOptions.getOptionByVal(simOptionVal);

                        if (simOption != null)
                        {
                            bool deleteKey = itemData.Length < 4 || itemData[3].Equals("") || itemData[3].Equals("0");
                            int registryIndex = Int32.Parse(itemData[2]);
                            int counter = 0;

                            foreach (string registryPath in simOption.getRegistryPaths())
                            {
                                if (registryIndex != counter)
                                {
                                    counter++;
                                    continue;
                                }

                                if (deleteKey)
                                {
                                    RegistryInterface.deleteRegistryKey(registryPath);
                                }
                                else
                                {
                                    string sourcePath = itemData[3];

                                    RegistryInterface.setRegistryValue(registryPath, sourcePath, true);
                                }

                                counter++;
                            }
                        }

                        newHistory.Remove(item);

                        break;
                    case 2:
                        //Delete the fake FSX executable file.
                        simOption = MainFormHandler.getSelectedTargetSimulator();
                        FilesHandler.deleteFakeFsxExecutable(simOption.getSimPath());
                        newHistory.Remove(item);

                        break;
                    case 3:
                        //Restore the config files from the migrationBackup folder and delete the file from the backup folder.
                        simOptionVal = Int32.Parse(itemData[1]);
                        simOption = SimulatorOptions.getOptionByVal(simOptionVal);

                        FilesHandler.restoreSourceConfigFiles(simOption);

                        newHistory.Remove(item);

                        break;
                }
            }

            //Sets the history file content.
            setHistory(newHistory);

            return true;
        }
    }
}