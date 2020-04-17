using Elad_s_Migration_Tool.MigrationFormsFunctions;
using Elad_s_Migration_Tool.General;
using Elad_s_Migration_Tool.Logs;

namespace Elad_s_Migration_Tool.RegistryFunctions
{
    class RegistryHandler
    {
        /**
         * Sets the path of the source simulator as the target.
         */
        public static bool SetSourceAsTarget()
        {
            SimulatorOption sourceOption = MainFormHandler.GetSelectedSourceSimulator();
            SimulatorOption targetOption = MainFormHandler.GetSelectedTargetSimulator();

            if (sourceOption == null || targetOption == null)
            {
                return false;
            }

            string targetPath = targetOption.GetSimPath();
            int registryIndex = 0;

            foreach (string registryPath in sourceOption.GetRegistryPaths())
            {
                string sourcePath = RegistryInterface.GetRegistryValue(registryPath);
                RegistryInterface.SetRegistryValue(registryPath, targetPath, true);

                string log = "";

                if (!sourcePath.Equals("") && sourcePath != null)
                {
                    log = "1," + sourceOption.GetValue() + "," + registryIndex + "," + sourcePath;
                }
                else
                {
                    log = "1," + sourceOption.GetValue() + "," + registryIndex + ",0";
                }

                HistoryHandler.AppendHistory(log);

                registryIndex++;
            }

            return true;
        }
    }
}