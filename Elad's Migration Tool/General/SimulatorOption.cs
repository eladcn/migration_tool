using Elad_s_Migration_Tool.FilesFunctions;

namespace Elad_s_Migration_Tool.General
{
    class SimulatorOption
    {
        protected string text;
        protected int value;
        protected string[] registryPaths;
        protected string simPath;
        protected string appDataPath;
        protected string programDataPath;
        protected string simConfigFile;

        public SimulatorOption(string text, int value, string[] registryPaths)
        {
            this.text = text;
            this.value = value;
            this.registryPaths = registryPaths;
        }

        /**
         * Returns the simulator text.
         */
        public string GetText()
        {
            return this.text;
        }

        /**
         * Returns the simulator's value.
         */
        public int GetValue()
        {
            return this.value;
        }

        /**
         * Returns the registry paths of the simulator.
         */
        public string[] GetRegistryPaths()
        {
            return this.registryPaths;
        }

        /**
         * Returns the simulator path.
         */
        public string GetSimPath()
        {
            return this.simPath;
        }

        /**
         * Returns the application data path of the simulator.
         */
        public string GetAppDataPath()
        {
            return this.appDataPath;
        }

        /**
         * Returns the full application data path if the getFullPath parameter is set to true.
         */
        public string GetAppDataPath(bool getFullPath)
        {
            return (getFullPath ? FilesHandler.GetApplicationDataPath() + "\\" : "") + this.appDataPath;
        }

        /**
         * Returns the program data path of the simulator.
         */
        public string GetProgramDataPath()
        {
            return this.programDataPath;
        }

        /**
         * Returns the full program data path if the getFullPath parameter is set to true.
         */
        public string GetProgramDataPath(bool getFullPath)
        {
            return (getFullPath ? FilesHandler.GetProgramDataPath() + "\\" : "") + this.programDataPath;
        }

        /**
         * Returns the sim config file name.
         */
        public string GetSimConfigFile()
        {
            return this.simConfigFile;
        }

        /**
         * Sets the simulator's path.
         */
        public void SetSimPath(string simPath)
        {
            this.simPath = simPath;
        }

        /**
         * Sets the simulator's app data path.
         */
        public void SetAppDataPath(string appDataPath)
        {
            this.appDataPath = appDataPath;
        }

        /**
         * Sets the simulator's program data path.
         */
        public void SetProgramDataPath(string programDataPath)
        {
            this.programDataPath = programDataPath;
        }

        /**
         * Sets the file name of the simulator's config file.
         */
        public void SetSimConfigFile(string simConfigFile)
        {
            this.simConfigFile = simConfigFile;
        }

        /**
         * Returns the simulator's text.
         */
        public override string ToString()
        {
            return this.GetText();
        }

        /**
         * Returns whether 2 simulator options are the same option.
         */
        public bool Equals(SimulatorOption parallelSimOption)
        {
            return parallelSimOption.GetText().Equals(this.GetText()) && parallelSimOption.GetValue().Equals(this.GetValue());
        }
    }
}