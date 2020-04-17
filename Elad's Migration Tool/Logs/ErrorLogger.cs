using Elad_s_Migration_Tool.General;

namespace Elad_s_Migration_Tool.Logs
{
    class ErrorLogger
    {
        protected static string errorLogFile = "error.log";

        /**
         * Writes data to the log file.
         */
        public static void LogError(string data)
        {
            Helper.WriteLineToText(errorLogFile, data);
        }
    }
}