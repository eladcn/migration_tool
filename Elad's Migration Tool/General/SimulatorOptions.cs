using System.Collections.Generic;
using Elad_s_Migration_Tool.RegistryFunctions;
using System.Windows.Forms;

namespace Elad_s_Migration_Tool.General
{
    class SimulatorOptions
    {
        public const int FSX_VALUE = 1;
        public const int FSX_SE_VALUE = 2;
        public const int P3D_V1_VALUE = 3;
        public const int P3D_V2_VALUE = 4;
        public const int P3D_V3_VALUE = 5;
        public const int P3D_V4_VALUE = 6;

        protected static SimulatorOptions instance = null;

        protected List<SimulatorOption> simOptions = new List<SimulatorOption>();
        protected List<SimulatorOption> simOptionsInPC = null;

        public SimulatorOptions()
        {
            instance = this;

            InitializeOptions();
        }

        /**
         * Returns all available SimuatorOptions.
         */
        public static List<SimulatorOption> GetAllSimulatorOptions()
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
        public static List<SimulatorOption> GetSimOptionsInPC()
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

            foreach (SimulatorOption simOption in GetAllSimulatorOptions())
            {
                if (simOption.GetSimPath() != null && !simOption.GetSimPath().Equals(""))
                {
                    instance.simOptionsInPC.Add(simOption);
                }
            }

            return instance.simOptionsInPC;
        }

        /**
         * Returns an option by searching for its value.
         */
        public static SimulatorOption GetOptionByVal(int val)
        {
            if (instance == null)
            {
                instance = new SimulatorOptions();
            }

            foreach (SimulatorOption option in instance.simOptions)
            {
                if (option.GetValue() == val)
                {
                    return option;
                }
            }

            return null;
        }

        /**
         * Sets the selected option in the combo box according to the value.
         */
        public static bool SetSelectedOptionByVal(ComboBox combo, int val)
        {
            int counter = 0;

            foreach (SimulatorOption simOption in combo.Items)
            {
                if (simOption.GetValue() == val)
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
        public static SimulatorOption GetOptionBySelectedItem(ComboBox combo)
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
        protected void InitializeOptions()
        {
            InitializeFSX();
            InitializeFSXSE();
            InitializePrepar3Dv1();
            InitializePrepar3Dv2();
            InitializePrepar3Dv3();
            InitializePrepar3Dv4();
        }

        /**
         * Initializes the sim path in a specific SimuatorOption. 
         */
        protected bool InitializeComboSimPath(SimulatorOption simulatorOption)
        {
            if (simulatorOption == null)
            {
                return false;
            }

            string[] registryPaths = simulatorOption.GetRegistryPaths();

            foreach (string registryPath in registryPaths)
            {
                string simPath = RegistryInterface.GetRegistryValue(registryPath);

                if (!simPath.Equals("") && !simPath.Equals("1") && !simPath.Equals("0"))
                {
                    simulatorOption.SetSimPath(simPath);

                    return true;
                }
            }

            return false;
        }

        protected void InitializeSim(string[] registryPaths, string appDataPath, string programDataPath, string text, int value, string configFile)
        {
            SimulatorOption option = new SimulatorOption(text, value, registryPaths);

            option.SetAppDataPath(appDataPath);
            option.SetProgramDataPath(programDataPath);
            InitializeComboSimPath(option);
            option.SetSimConfigFile(configFile);

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the FSX combo item with the corresponding registry keys.
         */
        protected void InitializeFSX()
        {
            string[] registryPaths = {
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\SetupPath",
                "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Microsoft Games\\Flight Simulator\\10.0\\AppPath"
            };

            InitializeSim(registryPaths, "Microsoft\\FSX", "Microsoft\\FSX", "FSX", FSX_VALUE, "fsx.cfg");
        }

        /**
         * Initializes the FSX Steam Edition combo item with the corresponding registry keys.
         */
        protected void InitializeFSXSE()
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

            InitializeSim(registryPaths, "Microsoft\\FSX", "Microsoft\\FSX", "FSX Steam Edition", FSX_SE_VALUE, "fsx.cfg");
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

            InitializeSim(registryPaths, appDataPath, programDataPath, name, value, "prepar3d.cfg");
        }

        /**
         * Initializes the Prepar3D v1 combo item with the corresponding registry keys.
         */
        protected void InitializePrepar3Dv1()
        {
            initializePrepar3D("Prepar3D", P3D_V1_VALUE);
        }

        /**
         * Initializes the Prepar3D v2 combo item with the corresponding registry keys.
         */
        protected void InitializePrepar3Dv2()
        {
            initializePrepar3D("Prepar3D v2", P3D_V2_VALUE);
        }

        /**
         * Initializes the Prepar3D v3 combo item with the corresponding registry keys.
         */
        protected void InitializePrepar3Dv3()
        {
            initializePrepar3D("Prepar3D v3", P3D_V3_VALUE);
        }

        /**
         * Initializes the Prepar3D v3 combo item with the corresponding registry keys.
         */
        protected void InitializePrepar3Dv4()
        {
            initializePrepar3D("Prepar3D v4", P3D_V4_VALUE);
        }
    }
}
