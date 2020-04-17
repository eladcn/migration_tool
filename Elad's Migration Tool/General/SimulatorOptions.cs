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
            string[] registryPaths = new string[5];

            registryPaths[0] = MigrationEncryption.Decrypt("Uh4zVmr/SI9yqnck6k2kEA0gQGYCpSvzIA92iWJP2F8HrM07of6yqLAqLPYEH4P6gH5j6ZSGAp03bSPHsM3KGq8Wb7PJKSNepjRXvn/mu9W3hzndjlYxOxQjcKdSFeUskriXx9x6IcnTyNKCfpRxfzY9WSkk6xW5j3inb/vlE/Dsy/8XYh5iMJy6sauh6VpzQvX3xwIMsMcwv+1n5QaGGg==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[1] = MigrationEncryption.Decrypt("0L7M8/xNTBelNrFd/IN8aQxRrQzuybMz5JbGkuwpwthXTDIjo5pVn9F9VdazmvgN+23HuC38PErQyQgUnrtcAVCfhnSXHwOSs8FScjbQ86dnaOAiXot2cxjYBCzD3PydFuve89KJJsj/Caq2sLQrMaXilM4Wr/OlfoyB0lcar8qf5PFErl6X6bSiuJxIf6St9oVB2AF0IiyThkxPBUl6cw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[2] = MigrationEncryption.Decrypt("vGhKeS6lD/2z1VwBWQirwcgc8CVdWYGpfCNMCvVmAfN7ulndWvY+davDR/1dyVtviDfDnT4r8yEslEDdhCOZLmzRBCcLj12uHkYusqyilePRPUo/c6Nf5VdK4iVGnQ7Tp+JyR4Zx19FYF4GjuKtljVIWEDtg/V2uNYJxhScAW6dHZrOAkytjQx3eEwdcGkIdiFE2zYr+CzFR89i6G1Beag==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[3] = MigrationEncryption.Decrypt("fUj/6DHwa0ClNIaFuHBuNgyMXS1Am1bJj3qV2XzN+GXsujrYVMefSTLACkSI3rHLkJ1g9hB0OeNLPQS5dB54+K+C/TmA0XMDUH47SRfvapOO2WW+q2Uh0oj1bzV2YzgiThFA4x5LazhlfrbOYVxr2elJ/uD+ejAMRmiKGnQpeQf4GX/1ZYrCXxTGldqkj73YinVb76mybXJbw1wmlufyeKk4S1+dmVOOaLedxb7Zzfuiyp2ZdDBstl2F6SPu+WAK", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[4] = MigrationEncryption.Decrypt("9+wIFVevU/SdpurN/In9XV658+u5T8qVlihCWdysNQhAsB5YCl4axnZfGubOnMwQtsHSRb/rsTBhQGFN95kXifTtHHDo5UsCAIxzhKWkEKRxliXmere08K0WTi8prRvBqZFNEz8j/dEqiKWOEvflFM1hjZXzR/OwpaT/5/37WhPrjw+XIJqcTFWGaAnE9CZ/4x4ydXUY5f6UEzZcuqXALw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Microsoft Games\Flight Simulator\10.0\AppPath

            string appDataPath = MigrationEncryption.Decrypt("Y9M1VgzX+T+rEb8GrzPBnaZyjLvQMp/YOtsne2sc++ghm+DuyFpCnoZ7E1COXMFMNJhpVNQC3WxN3hA2B5imuOEKPWTzklratc6lF/ZTAE7SGB5QdHBNnufLX4YDrcLf", MigrationEncryption.ENCRYPTION_PASSWORD); //Microsoft\FSX
            string programDataPath = MigrationEncryption.Decrypt("nMX/fT3HTbBWjJ1mkUDNOLMCAZZ40q9Tnpf+QZoY0Yq9ye7mRpIFT9fdt8cemL9rBH458lc45SIJtfcZd4YOENcp/IMwC80Eb6Eletoexiz763kE/Rr8CiRegIShCDOi", MigrationEncryption.ENCRYPTION_PASSWORD); //Microsoft\FSX

            SimulatorOption option = new SimulatorOption(MigrationEncryption.Decrypt("cLU+9VOjtGg2N7LVGr3LrPBDkn/3ol1htyfKo88U6cDceE81u6g5f0IB/pomrJbhiR7Z3k9b+HdNOkj49b7L7B+cjutvGoxPZBBFIxyZAbp0eQroEUQoAsdAVsx9NNTr", MigrationEncryption.ENCRYPTION_PASSWORD), 1, registryPaths); //FSX
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile(MigrationEncryption.Decrypt("i4ZCwrATp18gc9+VApAKwvbcZxjVunrJKYUxtErU7vyRxoaARgwoIgUVssFhBNmLfrhfD1P1hj2rNrryeVL9ge5enijKyKe9cjvlT4jKIg58X0lP7HpAUM8WMv7ki814", MigrationEncryption.ENCRYPTION_PASSWORD)); //fsx.cfg

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the FSX Steam Edition combo item with the corresponding registry keys.
         */
        protected void initializeFSXSE()
        {
            string[] registryPaths = new string[8];

            registryPaths[0] = MigrationEncryption.Decrypt("SuPF6oJZwYJIY+K+zg/c9bE3qMQ8abAShAIM6ALnFXEnMl9z/f2HUcagjeDrkrnOgayriZZKU1QahzuCrJs+719Jfqr4t0Gm0025vpnxdN4TiPsfz/UzdPK0hm8DQ/pV8xjWDDx6HmYxp1s4zcukY5r/E7P6TPYgq+ciucHhH35gOMD9ZZFCDpApzPMSM6V/NT+eegBqK4lUpUakqqiVmA==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Dovetail Games\FSX\10.0\Install_Path
            registryPaths[1] = MigrationEncryption.Decrypt("J/+ADVDz1KfJwGdHNkHCVsO9NI+iasH21GLh/CqdHuCUcdpGuH0KoOnPtMZDBW5rdFaE5XFRzPLkxdgr9kgDJSsG1gw/nJQkLS1ApGrbCtl+DjNDRj9ixn9WiY7n+fBmaGl5Mx5Pr0pgobGIjuKsm5OAbOzrIJ6ISInTsfTz+fQ5CBs2f5TX3PMSWOgGwF6wXMnEmZUubn6pEdJUSA+Hvg==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Dovetail Games\FSX\10.0\Install_Path
            registryPaths[2] = MigrationEncryption.Decrypt("9gHFh57cXPYqgH5m+epcKEWNEEt7NttjyUiz0mGZebzEOWoU6R1FYwlKvw7VV/UUQjbElJIchdPC4qi81YmloZteyi/4NSP7IuFmf/Ml43P6C9FyUqg8YvkP/dR7nNoUXXjFFMTFhxKIOlz9TWzOIGbSrX2jlHRfKPPJKjQqPBz/8f2VWYkD5Z0WgHc54mXCC0apZoWxTKonHP5vMczm/I70oVVECBzGTYfgFCHcuH0BlCcMv2uWb8dMfwpMaz3D", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Microsoft Games\Flight Simulator - Steam Edition\10.0\AppPath
            registryPaths[3] = MigrationEncryption.Decrypt("Uh4zVmr/SI9yqnck6k2kEA0gQGYCpSvzIA92iWJP2F8HrM07of6yqLAqLPYEH4P6gH5j6ZSGAp03bSPHsM3KGq8Wb7PJKSNepjRXvn/mu9W3hzndjlYxOxQjcKdSFeUskriXx9x6IcnTyNKCfpRxfzY9WSkk6xW5j3inb/vlE/Dsy/8XYh5iMJy6sauh6VpzQvX3xwIMsMcwv+1n5QaGGg==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[4] = MigrationEncryption.Decrypt("0L7M8/xNTBelNrFd/IN8aQxRrQzuybMz5JbGkuwpwthXTDIjo5pVn9F9VdazmvgN+23HuC38PErQyQgUnrtcAVCfhnSXHwOSs8FScjbQ86dnaOAiXot2cxjYBCzD3PydFuve89KJJsj/Caq2sLQrMaXilM4Wr/OlfoyB0lcar8qf5PFErl6X6bSiuJxIf6St9oVB2AF0IiyThkxPBUl6cw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[5] = MigrationEncryption.Decrypt("vGhKeS6lD/2z1VwBWQirwcgc8CVdWYGpfCNMCvVmAfN7ulndWvY+davDR/1dyVtviDfDnT4r8yEslEDdhCOZLmzRBCcLj12uHkYusqyilePRPUo/c6Nf5VdK4iVGnQ7Tp+JyR4Zx19FYF4GjuKtljVIWEDtg/V2uNYJxhScAW6dHZrOAkytjQx3eEwdcGkIdiFE2zYr+CzFR89i6G1Beag==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft Games\Flight Simulator\10.0\SetupPath
            registryPaths[6] = MigrationEncryption.Decrypt("9+wIFVevU/SdpurN/In9XV658+u5T8qVlihCWdysNQhAsB5YCl4axnZfGubOnMwQtsHSRb/rsTBhQGFN95kXifTtHHDo5UsCAIxzhKWkEKRxliXmere08K0WTi8prRvBqZFNEz8j/dEqiKWOEvflFM1hjZXzR/OwpaT/5/37WhPrjw+XIJqcTFWGaAnE9CZ/4x4ydXUY5f6UEzZcuqXALw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Microsoft\Microsoft Games\Flight Simulator\10.0\AppPath
            registryPaths[7] = MigrationEncryption.Decrypt("fUj/6DHwa0ClNIaFuHBuNgyMXS1Am1bJj3qV2XzN+GXsujrYVMefSTLACkSI3rHLkJ1g9hB0OeNLPQS5dB54+K+C/TmA0XMDUH47SRfvapOO2WW+q2Uh0oj1bzV2YzgiThFA4x5LazhlfrbOYVxr2elJ/uD+ejAMRmiKGnQpeQf4GX/1ZYrCXxTGldqkj73YinVb76mybXJbw1wmlufyeKk4S1+dmVOOaLedxb7Zzfuiyp2ZdDBstl2F6SPu+WAK", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Microsoft Games\Flight Simulator\10.0\SetupPath

            string appDataPath = MigrationEncryption.Decrypt("KWqdHTF+xfSskRvEeOpyoAqJ3IXHTf7L60DoZrr3ma4sF1viucRPlBEFMGLGls5yUNUkHqJj53mm0ubLYdHxQRe2pLgovhSxXeFyciBJy6G6T+aKZVRauz6E/iwZA+YH", MigrationEncryption.ENCRYPTION_PASSWORD);  //Microsoft\FSX
            string programDataPath = MigrationEncryption.Decrypt("PrYg60Y64bHsoFyjFAFiIZg2Xn7vUsAFumhYm8mn9cV9B8HvSEJL31BUYxbHQk+HQwFwhMl5XAETzuxR5Ovu7eXdEaccekXOGAZlgF0nI1W+U4e8AvpIBl9HNhYe6TAB", MigrationEncryption.ENCRYPTION_PASSWORD); //Microsoft\FSX

            SimulatorOption option = new SimulatorOption(MigrationEncryption.Decrypt("doufxGZ45i2BxeLz+EvhfwBnlDcYJboyliy85xg91Z4lLh/fhPUDr4pgz/ljYIBrUqXXxmYeaFyLUY/DLOckpW7CR0Gp0KD72POfQwp8kwEGDaLMnuDU+4hRVNpgYaBN", MigrationEncryption.ENCRYPTION_PASSWORD), 2, registryPaths); //FSX Steam Edition
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile(MigrationEncryption.Decrypt("300DnegFwJ58dBaNc65eyYExoaeCOrJmm47jPsmCFc3S4pD4JkdPerlO9RsSNazma85XJA5OhpWytsuO/e8Wh1wRWkKUItBMasLITeSWu2oMoXxOK6t41cPYMEU0Qkze", MigrationEncryption.ENCRYPTION_PASSWORD)); //fsx.cfg

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the Prepar3D v1 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv1()
        {
            string[] registryPaths = new string[5];
            registryPaths[0] = MigrationEncryption.Decrypt("pMi+8goX2Wotr6axUdKBk+H6n/BOERWOjozCV2FvE/uM1zt/L1QzFd7g2hWUHOiBd84OgfzUrdhtFipWZBMriurm1WYpqOeoBVfv1SaZKcJgDGzQqMSgNeteW6SjJbcYhqiMvRKWU2m85wpKcrZia993ow2qSQqUbG8ig1VBTW4=", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\LockheedMartin\Prepar3D\SetupPath
            registryPaths[1] = MigrationEncryption.Decrypt("copEQRlRRd3RqZfPATU2SljaLavn9YQMfplFQqEJmdSTpt1McVT/SFO4c68dUjNu1CizMrP+V34bTKXinDaITp190taQL0Y4G5rT4CQxxk+fSQvFOgD27UPi5uOECZfRIfU65txFmiFAaHFpbzbF85mi/U2CCp0knO9LGW3/fIkkHPO09PkoZmumKsk4lbXf6zqtk9Z0h57uM8M9VzeHRw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\LockheedMartin\Prepar3D\SetupPath
            registryPaths[2] = MigrationEncryption.Decrypt("QX/zrgsCr2GiFjppi9Fd4fzxbToUQEIW4F7vXbMUj/AIwuSH6dr3keWtmzWf6IbvsfGncRBB9L31rLYvS+d4G8ri1pLkiDhb3j0fF/BJ74jjEyF904wrAOxgCRTd0VhPK2TYfTOzjD2MKO6eulCYuvj6GZDDYgn9Ar8nkD2NYiw=", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\LockheedMartin\Prepar3D\AppPath
            registryPaths[3] = MigrationEncryption.Decrypt("qJ62Q9DpB4PSV8F2EMVAzApNSsYY4DCwBdcLfufFs5uW1QMqLSbOntgJ35eLYb4OBHxsyD4XtLQGR0zf4OTHMU+UaUsuUbJjnyVcLT8xLLelYyRPejAKLJtIuE8j2FgNOmMnxjGYFfOIrJwhwtJm/tZCyTeqKrhCg4GtjXhAKRQ=", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Lockheed Martin\Prepar3D\AppPath
            registryPaths[4] = MigrationEncryption.Decrypt("7F+shLfVMsC1uxrTFOA0fRsCI8Vzqh5BXkQvFT4ji+OzgVpOkhIT91bLqni1mTWQBdI3p/DyBGKCZqbJcGCNOLzvL6rUhvXPvwz1KuHS1W1ntV8PB6123quQzfQGRFHNjy0Ziu74dY4kaV7ESe/b+SjynP+C0Zz2YX45tEsidkAKSH3ce+hqaLcz9XYWm3Pjfaok+cxHUQlhpZHQaPdf0A==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D\AppPath

            string appDataPath = MigrationEncryption.Decrypt("PYzDymK426p51O3Z4VEbllYVDqIQch6N7altTIdoHe7dc9WXBOk6utb6v3TTzAakmMZQT+mrB2oBw9nBWeYl9PDdR+jI6wJZB9cUvfg4BS2Rlc71dOJTifBIm+jv0tsq", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D
            string programDataPath = MigrationEncryption.Decrypt("sI7I8I34KslVOan9c/jl3M1vXNNlCf/MXPISb1NIV+2iVR9Hd/6MRktuZrXHjrI8KWushbdbXVkJ7w1t2FNOWPCBWEhPn7+NF5T0Xi4EwgToXzaJqZv9Pj3hmUXxMtJF", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D

            SimulatorOption option = new SimulatorOption(MigrationEncryption.Decrypt("ddfiaZFPHk3DMKsmasPFlKwJDIu8VXeHTS8kYZVpZKZaQXvmPOHA+zrS7FnT6qeRheL0pqaKr8DB5UG90syqorpO4uGawPq+1ozcQ+/gA5DodYgNgB3BbF4Rbej8y0rP", MigrationEncryption.ENCRYPTION_PASSWORD), 3, registryPaths); //Prepar3D
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile(MigrationEncryption.Decrypt("T29rpCPYZuoarUKyqDzot7yLIhRFQk/9chYstLWtMNpZFGVZ6fbfzKFqKfdW9NmeZfMJPHwEQ29RztB8N+wClgeFH3R0oG0WbrjI+59DO+ZgsKcHncP3UKT7JJAYzAXX", MigrationEncryption.ENCRYPTION_PASSWORD)); //prepar3d.cfg

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the Prepar3D v2 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv2()
        {
            string[] registryPaths = new string[4];
            registryPaths[0] = MigrationEncryption.Decrypt("ick4HT0LkbvfdnGQXl7tAS4W3w8KQJF2fHQY5qv8Nk2iySqmMjHPbPJWR4UgOKdLuoyZfuQufnwlRhb25fr2pu14/WvsoNN9+cM0mS7fa3UN+DU7g2ClPM1J0fQOvPrUYN2xlT3lpyNs8qCEwIguMpfBUze/h61WErER8cQVAl8uoi8yJxsS5FUO8KUvHwygU7OT8EqUoQcYwSGy9H2ppw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Lockheed Martin\Prepar3D v2\SetupPath
            registryPaths[1] = MigrationEncryption.Decrypt("o1aI4KpGq4u/tJZY5xbcqyLAffR/02Ai9aczazD5xJbvr5diUQM8zwxYr/qJsuq88LMhkV98FkqLQ4K0B5sFaSWa3KWKtV0KwaZZx/3xnbYrOJKY67lMfqUoC6dg1eFhnFxVWMgr4lA1vnfiYKe+nQC8H+dV2loJYcxx3POQKfQMHfPUl8A7ZdV6Q7nQgYMYNtVG2coTLSEIsX0BVjoQBQ==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D v2\SetupPath
            registryPaths[2] = MigrationEncryption.Decrypt("HiNT75Nmi07AeyAVETywYJgQDlvhJMrVg8BHN1Jy/h8HBvVVeteIGOzUzlEXKUH4FQfjHaurYKuk/viNEaDf1TFgCcmo0bdcJbKLhawaXM8rnvmWF0EHwDhL6x7Zg+c96T/VltjuVbegI8teY+9Sy5PaKfiOi48BU1N/4MWSavQ=", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Lockheed Martin\Prepar3D v2\AppPath
            registryPaths[3] = MigrationEncryption.Decrypt("unbflTCM78p3xcTonAFFyOKG7dJw1qYyhMa02C3hdsmdhOeTFf+3nxEotygSC7sw7skVRyRUrF4TXaZ89xHf2Y6jbTlzwHpB7Q20wRodj80fVOdTw7O8H7qa58NoGR8zzM5/HeLJ1r9xC+5DA7y8qo3E0V41NDF9XydsriHbjEDSdaI0NgEZ/mlhhVKLxxjwQVc/MVcQQqomEPvQD1t/ew==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D v3\AppPath

            string appDataPath = MigrationEncryption.Decrypt("cM+7Q9MCd19DQTY11kLDftzoWVPF4RjJzVtyuqFpIVp0zN51sPSctIcSMDWhb/Vt1kME+xZiTWT/Zg4owebdCiy8o1JKp3KRSPcf3Qyre1TKSg6C2441+pgzMmxLtCM8", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D v2
            string programDataPath = MigrationEncryption.Decrypt("/BJpzpLEsf7TikRn4JVviX4DPRa1mZzNCL6qwFPrlsnakcNqKv3/K0jm6Q17W86DFZszQCKCDMIlOu7lTOuqaNXx436fW3MYedLNqzBPzAV8D4E/cNy0SeT7xCUATvl8", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D v2

            SimulatorOption option = new SimulatorOption(MigrationEncryption.Decrypt("VqMhwajTna8XlZnEwVlwOoBOtqx2cemhZXgY+GvIhpUgdFbUVY4WgMmpLSSHbUZN7nTfOoPQQ+KoFvkZCqHGFLFBBwJWoTZCulex8+fjxoSFIMpbnCl8uH/rw5wcVBBZ", MigrationEncryption.ENCRYPTION_PASSWORD), 4, registryPaths); //Prepar3D v2
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile(MigrationEncryption.Decrypt("fv8qRDkkO6qmSbcWilQkBYqv7MCSE4U9ozyN5ETddeFRQDESZRXUZ3DMXQh0NVLIeBavf6FO4McEiNX9X1yl1FPv2WYZhAePLO9vsdts7DhsJHSfLDSi2jfdThFGQIi6", MigrationEncryption.ENCRYPTION_PASSWORD)); //prepar3d.cfg

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the Prepar3D v3 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv3()
        {
            string[] registryPaths = new string[4];
            registryPaths[0] = MigrationEncryption.Decrypt("X1JNJpqU3Z13FzrSwFPhAzJPO5p/ziW7BgAJn9mVj+TE5mJKvfca6z/PNdsEsWx8Xbj8Rxa88KkO7KcT36LHSCrZj9WnE79idG2lJKTgsZbN8fBOiNSeWdJYikzk/DlYSVxYqOx4bnzX6W00eax4F5IKkfYh0saz5hnUvAEDA8nbTaplHIiBUPYNlucZTaxqgSIzuNoc4N2FkgCbnWq87w==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Lockheed Martin\Prepar3D v3\SetupPath
            registryPaths[1] = MigrationEncryption.Decrypt("LNojKyA0Es0rNTzujp7aaKN5htVyJlqD11BhYS6A2+o3g7X07jNwXEQi4jpmwFg5TAvy5X07lQuRMetI6gVJ9ia7ypDRiUYjwL/N6yj3yChAL+QwfqdxxfUY3m7o4812M4Iulrs61r2un9cfwtFTfFrWf/uiR5S8mT5lbL5+gByPhh+mal6ycnWQMM+66Jl1us3/ti2LFPQYX1ycw+/v5Q==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D v3\SetupPath
            registryPaths[2] = MigrationEncryption.Decrypt("V+YaQgfJSvg4NMuEBv7OO5UIpJAHr1IWxKyyiWEH88Y48o9LxTJOUdzymTEfueAhVG0NaVn80VAqQGrTbrVgxrcMf+LdWjO/EFLlqUNqGGjR2800WvC4s9y9Q+ymn9eGdeYbls1bnnKSjcQNTaRJOMupj37DFPlxW0F1RyQYiIM=", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Lockheed Martin\Prepar3D v3\AppPath
            registryPaths[3] = MigrationEncryption.Decrypt("hTAz0nfoT/r3eQ42iezJlCj3n6nkcs0Ai6CfWoF+Zux1BJ8V2yxML5sf9iYaxZmXK7dICxGqnEqEVW1yixsKgNKm7Q1bVWcHcrGiM5QfJkiZA8PMnCM/7iTSz1xBv7WmuH/P5KzSfp7TTHI9bxmOLK/xcRgEnHw0eqdIzLPS7ObZj9GWXUB7v1zqUI9KaI4ncpdO72Vh76aj5scS+J+N9Q==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D v3\AppPath

            string appDataPath = MigrationEncryption.Decrypt("K5p/rJIS53jilyz/ocGD5Mp1Vndu4rrCgd32NbZSQ9QPYAmlCWvEqU/fBCF+Kt+Itl+pH+UKzpDvqdcpz8pMjF1OHT0HeV/bTDzVc7I/zyqfGtnCKLxRh2bwvq1jWTGx", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D v3
            string programDataPath = MigrationEncryption.Decrypt("C4R5tFDPmhOiJMHzkLbozTJe5BOCF0JprTkySBxXRY1IewPKhQN4hLwDsCRkDuYJ/7JsBon2YcCbc+gyKKi4vr4vTgodjadUOBMOvVt2oyw9N7uIgVUxgnqCY65JpTuD", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D v3

            SimulatorOption option = new SimulatorOption(MigrationEncryption.Decrypt("n9RUuhGgbhl6fMSLweu5yHNZC0RVfKEZPUc1i2gVqpI3mBBbgfrp86NJT5Bn33DBBdsZeoAD5E5FX1C3ORZyuABaooSvVEYRNfe/AfY5a2Tfgwsq1muUzjgigXSzqcWF", MigrationEncryption.ENCRYPTION_PASSWORD), 5, registryPaths); //Prepar3D v3
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile(MigrationEncryption.Decrypt("I+CxSSblD+pd6nPAuReIZ8CVWhYprs+mBCJi0g5dpcaJz4Yy8YorvtWnSkPKmOCgm7Krr/J7eKLKvqiW6tiAKQ4xsvCzRuF3tonGw5nltJTmoWDtIT40VHFuCQm8qmNH", MigrationEncryption.ENCRYPTION_PASSWORD)); //prepar3d.cfg

            instance.simOptions.Add(option);
        }

        /**
         * Initializes the Prepar3D v3 combo item with the corresponding registry keys.
         */
        protected void initializePrepar3Dv4()
        {
            string[] registryPaths = new string[4];
            registryPaths[0] = MigrationEncryption.Decrypt("gkSPrnjQd/5R7eI9EokEp9dqMyZoMpLXs9pp5YKrsvItbMMtEJgqePliT6hzwFTcA51Z761iqKf/a9TisXuhrYYa17DfuUI9mXOkbXwNdYxCHG8/sit1mJwbXsyEvL4ISiCWxxpTe4B6Kin3ExoK+g3MxQTTcFlt8VJx4lY1hQ1gwDnd/xRfz2LujB+z0r3OCDzssl0B+8DJjAb3YkzATw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Lockheed Martin\Prepar3D v4\SetupPath
            registryPaths[1] = MigrationEncryption.Decrypt("8eHnD9J9EWLCBUxpltzd6wg2a6yIQa8KwU8CfjDqQgaC9YjGfs5Mf7ZGJaJTmNuPCQDmjDx+6qRbM+ugj8En6R+7Y3HdxqwKe6cHu+XoYJk/wOUR2S1eIQr6pybPTTCilWuH0ddkXt2COujI2p7Z24gD0Z1i5dC/TItJVYY1Ewx6jPgmd1mBJM9uumkK6n9MTMrdmVJpR9LuWs3cvJJTnQ==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D v4\SetupPath
            registryPaths[2] = MigrationEncryption.Decrypt("y7Gtg2gmeoaGhNMpLIorxXjDzjVMLlH+Ah/HobRv531XgtPYFvLiWnf7jjTIzTPdED3WdpTpmTO056c7M+CnYfo7MjdquWb7X8xjuC7ahTdbQVsvYzVejnYyrSqkY/hOF0IfeND9WyGtbmxL2qnAPFh+vPT3clbk8pknHcyloLg=", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Lockheed Martin\Prepar3D v4\AppPath
            registryPaths[3] = MigrationEncryption.Decrypt("Yvx4YL8TxNDLvl5dP8KElYk7KeQlZ1fqQ+DwJHNZ5ImHTSK7Asu9eh2GZguAq18DG5Yv0wkP7QhSnoedlhSM6lNlmkK4OS38BDwKcMmKPq0tHhoZZQLDNMPhh4TVgYvzDUf3t7f2mYvtQZS7HUrjo2fxH1KbGV+wBGv3UdkDpTc4do3o08yl132IrrSG0rBsSDtKH/Kmx7OlhU9ordOXTw==", MigrationEncryption.ENCRYPTION_PASSWORD); //HKEY_CURRENT_USER\SOFTWARE\Wow6432Node\Lockheed Martin\Prepar3D v4\AppPath

            string appDataPath = MigrationEncryption.Decrypt("Qoz6CquBFkvveXBU9Q/fO5wh86kWKDiJbOsYos5zut4BQSLnL34hpoy3Mcwr7PYs/QPO1eJF1CZj/V6lTxMLXG86aDPREPU6CwCisTyxg3l/VkbiLmJpHcQ7Y7u4BlLz", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D v4
            string programDataPath = MigrationEncryption.Decrypt("tK9abc8y2QJf0DYs/fqiwmt+PyawNZWPlWlpUbyqWT6lXBacbpnIgKCLih7pHiv4Zib8pYKmdJIeeU5ChQu12CE1VYovrFiMufR4sJ62Dv7AJ2M9r9AYwPUrHpgrC4DV", MigrationEncryption.ENCRYPTION_PASSWORD); //Lockheed Martin\Prepar3D v4

            SimulatorOption option = new SimulatorOption(MigrationEncryption.Decrypt("OiQi4anmdmG3WL2aRRi0J8WLRc6nR1nn8+n8XPaqo0p3HZM6+33Mq65mte61F9SwAj7p/CUKsEH520r+r6YxUku3uvZzF79X51KQMEeP0sCdH9g3OIXwnNSMIUQkyOiT", MigrationEncryption.ENCRYPTION_PASSWORD), 6, registryPaths); //Prepar3D v4
            option.setAppDataPath(appDataPath);
            option.setProgramDataPath(programDataPath);
            initializeComboSimPath(option);
            option.setSimConfigFile(MigrationEncryption.Decrypt("I+CxSSblD+pd6nPAuReIZ8CVWhYprs+mBCJi0g5dpcaJz4Yy8YorvtWnSkPKmOCgm7Krr/J7eKLKvqiW6tiAKQ4xsvCzRuF3tonGw5nltJTmoWDtIT40VHFuCQm8qmNH", MigrationEncryption.ENCRYPTION_PASSWORD)); //prepar3d.cfg

            instance.simOptions.Add(option);
        }
    }
}