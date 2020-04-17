using System.Collections.Generic;
using Elad_s_Migration_Tool.RegistryFunctions;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool.General
{
    class SimulatorOptions
    {
        protected static SimulatorOptions instance = null;

        protected List<SimulatorOption> simOptions = new List<SimulatorOption>();
        protected List<SimulatorOption> simOptionsInPC = null;

        public SimulatorOptions()
        {
            instance = this;

            initializeOptions();
        }

        /**
         * Returns all available SimuatorOptions.
         */
        public static List<SimulatorOption> getAllSimulatorOptions()
        {
            if (instance == null)
            {
                instance = new SimulatorOptions();
            }

            return instance.simOptions;
        }

        /**
         * Returns the available simulator options in the current PC.
         */
        public static List<SimulatorOption> getSimOptionsInPC()
        {
            if (instance == null)
            {
                instance = new SimulatorOptions();
            }

            if (instance.simOptionsInPC != null)
            {
                return instance.simOptionsInPC;
            }

            instance.simOptionsInPC = new List<SimulatorOption>();

            foreach (SimulatorOption simOption in getAllSimulatorOptions())
            {
                if (simOption.getSimPath() != null && !simOption.getSimPath().Equals(""))
                {
                    instance.simOptionsInPC.Add(simOption);
                }
            }

            return instance.simOptionsInPC;
        }

        /**
         * Returns an option by searching for its value.
         */
        public static SimulatorOption getOptionByVal(int val)
        {
            if (instance == null)
            {
                instance = new SimulatorOptions();
            }

            foreach (SimulatorOption option in instance.simOptions)
            {
                if (option.getValue() == val)
                {
                    return option;
                }
            }

            return null;
        }

        /**
         * Sets the selected option in the combo box according to the value.
         */
        public static bool setSelectedOptionByVal(ComboBox combo, int val)
        {
            int counter = 0;

            foreach (SimulatorOption simOption in combo.Items)
            {
                if (simOption.getValue() == val)
                {
                    combo.SelectedIndex = counter;

                    return true;
                }

                counter++;
            }

            return false;
        }

        /**
         * Returns the selected SimulatorOption in a specific combo.
         * If possible, use MainFormHandler's getSelectedSourceSimulator() and getSelectedTargetSimulator() instead.
         */
        public static SimulatorOption getOptionBySelectedItem(ComboBox combo)
        {
            int selectedIndex = combo.SelectedIndex;
            int counter = 0;

            if (selectedIndex >= 0)
            {
                foreach (SimulatorOption option in combo.Items)
                {
                    if (counter == selectedIndex)
                    {
                        return option;
                    }

                    counter++;
                }
            }

            return null;
        }

        /**
         * Initializes the options.
         */
        protected void initializeOptions()
        {
            initializeFSX();
            initializeFSXSE();
            initializePrepar3Dv1();
            initializePrepar3Dv2();
            initializePrepar3Dv3();
            initializePrepar3Dv4();
        }

        /**
         * Initializes the sim path in a specific SimuatorOption. 
         */
        protected bool initializeComboSimPath(SimulatorOption simulatorOption)
        {
            if (simulatorOption == null)
            {
                return false;
            }

            string[] registryPaths = simulatorOption.getRegistryPaths();

            foreach (string registryPath in registryPaths)
            {
                string simPath = RegistryInterface.getRegistryValue(registryPath);

                if (!simPath.Equals("") && !simPath.Equals("1") && !simPath.Equals("0"))
                {
                    simulatorOption.setSimPath(simPath);

                    return true;
                }
            }

            return false;
        }

        /**
         * Initializes the FSX combo item with the corresponding registry keys.
         */
        protected void initializeFSX()
        {
            string[] registryPaths = {
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\AppPath"
            };

            string appDataPath = "Microsoft\\FSX";
            string programDataPath = "Microsoft\\FSX";

            SimulatorOption option = new SimulatorOption("FSX", 1, registryPaths);
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile("fsx.cfg");

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the FSX Steam Edition combo item with the corresponding registry keys.
         */
        protected void initializeFSXSE()
        {
            string[] registryPaths = {
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Dovetail Games\\FSX\\10.0\\Install_Path",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Dovetail Games\\FSX\\10.0\\Install_Path",
                "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator - Steam Edition\\10.0\\AppPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\AppPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath"
            };

            string appDataPath = "Microsoft\\FSX";
            string programDataPath = "Microsoft\\FSX";

            SimulatorOption option = new SimulatorOption("FSX Steam Edition", 2, registryPaths);
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile("fsx.cfg");

            instance.simOptions.Add(option);
        }

        protected void initializePrepar3D(string name, int value)
        {
            string[] registryPaths =
            {
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\LockheedMartin\\" + name + "\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Lockheed Martin\\" + name + "\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\LockheedMartin\\" + name + "\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Lockheed Martin\\" + name + "\\SetupPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\LockheedMartin\\" + name + "\\AppPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\Lockheed Martin\\" + name + "\\AppPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\Wow6432Node\\LockheedMartin\\" + name + "\\AppPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\Wow6432Node\\Lockheed Martin\\" + name + "\\AppPath"
            };

            string appDataPath = "Lockheed Martin\\" + name;
            string programDataPath = "Lockheed Martin\\" + name;

            SimulatorOption option = new SimulatorOption(name, value, registryPaths);
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile("prepar3d.cfg");

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the Prepar3D v1 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv1()
        {
            initializePrepar3D("Prepar3D", 3);
        }

        /**
         * Initializes the Prepar3D v2 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv2()
        {
            initializePrepar3D("Prepar3D v2", 4);
        }

        /**
         * Initializes the Prepar3D v3 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv3()
        {
            initializePrepar3D("Prepar3D v3", 5);
        }

        /**
         * Initializes the Prepar3D v3 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv4()
        {
            initializePrepar3D("Prepar3D v4", 6);
        }
    }
}
