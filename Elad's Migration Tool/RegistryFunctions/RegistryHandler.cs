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
        public static bool setSourceAsTarget()
        {
            SimulatorOption sourceOption = MainFormHandler.getSelectedSourceSimulator();
            SimulatorOption targetOption = MainFormHandler.getSelectedTargetSimulator();

            if (sourceOption == null || targetOption == null)
            {
                return false;
            }

            string targetPath = targetOption.getSimPath();
            int registryIndex = 0;

            foreach (string registryPath in sourceOption.getRegistryPaths())
            {
                string sourcePath = RegistryInterface.getRegistryValue(registryPath);
                RegistryInterface.setRegistryValue(registryPath, targetPath, true);

                string log = "";

                if (!sourcePath.Equals("") && sourcePath != null)
                {
                    log = "1," + sourceOption.getValue() + "," + registryIndex + "," + sourcePath;
                }
                else
                {
                    log = "1," + sourceOption.getValue() + "," + registryIndex + ",0";
                }

                HistoryHandler.appendHistory(log);

                registryIndex++;
            }

            return true;
        }
    }
}