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

        public SimulatorOption(string text)
        {
            this.text = text;
        }

        public SimulatorOption(string text, int value)
        {
            this.text = text;
            this.value = value;
        }

        public SimulatorOption(string text, int value, string[] registryPaths)
        {
            this.text = text;
            this.value = value;
            this.registryPaths = registryPaths;
        }

        /**
         * Returns the simulator text.
         */
        public string getText()
        {
            return this.text;
        }

        /**
         * Returns the simulator's value.
         */
        public int getValue()
        {
            return this.value;
        }

        /**
         * Returns the registry paths of the simulator.
         */
        public string[] getRegistryPaths()
        {
            return this.registryPaths;
        }

        /**
         * Returns the simulator path.
         */
        public string getSimPath()
        {
            return this.simPath;
        }

        /**
         * Returns the application data path of the simulator.
         */
        public string getAppDataPath()
        {
            return this.appDataPath;
        }

        /**
         * Returns the full application data path if the getFullPath parameter is set to true.
         */
        public string getAppDataPath(bool getFullPath)
        {
            return (getFullPath ? FilesHandler.getApplicationDataPath() + "\\" : "") + this.appDataPath;
        }

        /**
         * Returns the program data path of the simulator.
         */
        public string getProgramDataPath()
        {
            return this.programDataPath;
        }

        /**
         * Returns the full program data path if the getFullPath parameter is set to true.
         */
        public string getProgramDataPath(bool getFullPath)
        {
            return (getFullPath ? FilesHandler.getProgramDataPath() + "\\" : "") + this.programDataPath;
        }

        /**
         * Returns the sim config file name.
         */
        public string getSimConfigFile()
        {
            return this.simConfigFile;
        }

        /**
         * Sets the simulator's text.
         */
        public void setText(string text)
        {
            this.text = text;
        }

        /**
         * Sets the simulator's value.
         */
        public void setValue(int value)
        {
            this.value = value;
        }

        /**
         * Sets the simulator's registry paths.
         */
        public void setRegistryPaths(string[] registryPaths)
        {
            this.registryPaths = registryPaths;
        }

        /**
         * Sets the simulator's path.
         */
        public void setSimPath(string simPath)
        {
            this.simPath = simPath;
        }

        /**
         * Sets the simulator's app data path.
         */
        public void setAppDataPath(string appDataPath)
        {
            this.appDataPath = appDataPath;
        }

        /**
         * Sets the simulator's program data path.
         */
        public void setProgramDataPath(string programDataPath)
        {
            this.programDataPath = programDataPath;
        }

        /**
         * Sets the file name of the simulator's config file.
         */
        public void setSimConfigFile(string simConfigFile)
        {
            this.simConfigFile = simConfigFile;
        }

        /**
         * Returns the simulator's text.
         */
        public override string ToString()
        {
            return this.getText();
        }

        /**
         * Returns whether 2 simulator options are the same option.
         */
        public bool Equals(SimulatorOption parallelSimOption)
        {
            return parallelSimOption.getText().Equals(this.getText()) && parallelSimOption.getValue().Equals(this.getValue());
        }
    }
}