using System;
using System.Collections.Generic;
using System.Linq;
using Elad_s_Migration_Tool.RegistryFunctions;
using System.IO;
using Elad_s_Migration_Tool.Logs;

namespace Elad_s_Migration_Tool.General
{
    class Helper
    {
        /**
         * Reads each line of a text file into a List<string>.
         */
        public static List<string> GetTextFileContent(string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file)./*Where(line => line != "").*/ToList();
        }

        /**
         * Writes a specific line into a text file.
         */
        public static bool WriteLineToText(string file, string line)
        {
            try
            {
                StreamWriter fileStream = new StreamWriter(file, true);
                fileStream.WriteLine(line);
                fileStream.Close();
            }
            catch (Exception e)
            {
                ErrorLogger.LogError("Could not write to file " + file + " at function writeLineToText() - " + e.ToString());

                return false;
            }

            return true;
        }

        /**
         * Sets the content of a text file using a List of the content - each string in content is a line.
         */
        public static bool SetTextFileContent(string file, List<string> content)
        {
            try
            {
                File.WriteAllText(file, String.Empty); //Empties the file

                StreamWriter fileStream = new StreamWriter(file, true);

                foreach (string line in content)
                {
                    fileStream.WriteLine(line);
                }

                fileStream.Close();
            }
            catch (Exception e)
            {
                ErrorLogger.LogError("Could not write to file " + file + " at function setTextFileContent() - " + e.ToString());
                return false;
            }

            return true;
        }
    }
}
