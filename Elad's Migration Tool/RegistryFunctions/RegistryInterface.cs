using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Security.AccessControl;
using System.Security.Permissions;
using Elad_s_Migration_Tool.Logs;
using System.Security.Principal;

namespace Elad_s_Migration_Tool.RegistryFunctions
{
    class RegistryInterface
    {
        /**
         * Returns a RegistryKey object.
         */
        protected static RegistryKey getRegistryObject(bool isLocalMachine)
        {
            if (isLocalMachine)
            {
                return RegistryKey.OpenBaseKey(
                    RegistryHive.LocalMachine,
                    Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32
                );
            }

            return Registry.CurrentUser;
        }

        /**
         * Returns a registry key value according to the keyPath and keyName.
         */
        public static string getRegistryValue(string fullKeyPath)
        {
            bool isLocalMachine = isLocalMachinePath(fullKeyPath);
            string keyName = getSubkeyFromPath(fullKeyPath);
            string keyPath = getPathFromFullPath(fullKeyPath);

            RegistryKey regKey = getRegistryObject(isLocalMachine);
            RegistryKey subKey = regKey.OpenSubKey(keyPath);

            if (regKey == null)
            {
                return "";
            }

            if (subKey == null)
            {
                regKey.Close();

                return "";
            }

            try
            {
                string value = (string)subKey.GetValue(keyName);

                subKey.Close();
                regKey.Close();

                return value == null ? "" : value;
            }
            catch (Exception)
            {
                regKey.Close();

                return "";
            }
        }

        /**
         * Returns whether a registry key exists or not.
         */
        public static bool registryKeyExists(string fullKeyPath)
        {
            return !getRegistryValue(fullKeyPath).Equals("");
        }

        /**
         * Sets a specific registry key's value.
         */
        public static bool setRegistryValue(string fullKeyPath, object value, bool forceWrite)
        {
            if (!forceWrite)
            {
                if (getRegistryValue(fullKeyPath).Equals(""))
                {
                    return false;
                }
            }

            if (!createRegistryKeyIfNotExists(fullKeyPath))
            {
                return false;
            }

            bool isLocalMachine = isLocalMachinePath(fullKeyPath);
            string keyName = getSubkeyFromPath(fullKeyPath);
            string keyPath = getPathFromFullPath(fullKeyPath);

            RegistryKey regKey = getRegistryObject(isLocalMachine);

            if (regKey == null)
            {
                return false;
            }

            try
            {
                RegistryKey subKey = regKey.OpenSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);

                if (subKey != null)
                {
                    subKey.SetValue(keyName, value);
                    subKey.Close();
                }

                regKey.Close();

                return true;
            }
            catch (Exception e)
            {
                regKey.Close();
                ErrorLogger.logError("Unable to write to registry, function setRegistryValue() - " + e);

                return false;
            }
        }

        /**
         * Deletes a specific registry key.
         */
        public static bool deleteRegistryKey(string fullKeyPath)
        {
            bool isLocalMachine = isLocalMachinePath(fullKeyPath);
            string keyName = getSubkeyFromPath(fullKeyPath);
            string keyPath = getPathFromFullPath(fullKeyPath);

            RegistryKey regKey = getRegistryObject(isLocalMachine);

            if (regKey == null)
            {
                return false;
            }

            try
            {
                RegistryKey subKey = regKey.OpenSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);

                if (subKey != null)
                {
                    subKey.DeleteValue(keyName, true);
                    subKey.Close();
                }

                regKey.Close();

                return true;
            }
            catch (Exception e)
            {
                regKey.Close();
                ErrorLogger.logError("Unable to delete registry key, function deleteRegistryKey() - " + e);

                return false;
            }
        }

        /**
         * Creates a registry key only if the key does not exist in the registry.
         */
        public static bool createRegistryKeyIfNotExists(string fullKeyPath)
        {
            if (fullKeyPath.Equals("") || !getRegistryValue(fullKeyPath).Equals(""))
            {
                return true;
            }

            bool isLocalMachine = isLocalMachinePath(fullKeyPath);
            string[] keyTrail = getKeyTrailFromPath(fullKeyPath);

            RegistryKey regKey = getRegistryObject(isLocalMachine);

            if (regKey == null)
            {
                return false;
            }

            RegistryKey subKey = null;

            for (int i = 0; i < keyTrail.Length; i++)
            {
                string key = keyTrail[i];

                try
                {
                    subKey = regKey.OpenSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);

                    if (subKey == null)
                    {
                        RegistryKey tempKey = regKey.CreateSubKey(key, RegistryKeyPermissionCheck.ReadWriteSubTree);
                        regKey.Close();
                        regKey = tempKey;
                    }
                    else
                    {
                        regKey.Close();

                        regKey = subKey;
                    }
                }
                catch (Exception e)
                {
                    if (subKey != null)
                    {
                        subKey.Close();
                    }

                    if (regKey != null)
                    {
                        regKey.Close();
                    }

                    ErrorLogger.logError("Unable to create registry key, function createRegistryKeyIfNotExists() - " + e);

                    return false;
                }
            }

            if (subKey != null)
            {
                subKey.Close();
            }

            if (regKey != null)
            {
                regKey.Close();
            }

            return true;
        }

        /**
         * Returns whether a path is a HKEY_LOCAL_MACHINE path or not.
         */
        public static bool isLocalMachinePath(string path)
        {
            return path.IndexOf("HKEY_LOCAL_MACHINE") >= 0;
        }

        /**
         * Returns the subkey from a registry path.
         */
        public static string getSubkeyFromPath(string path)
        {
            while (path.LastIndexOf("\\") == path.Length - 1)
            {
                path = path.Substring(0, path.Length - 1);
            }

            return path.Substring(path.LastIndexOf("\\") + 1);
        }

        /**
         * Returns the path without the subkey name.
         */
        public static string getPathFromFullPath(string path)
        {
            while (path.LastIndexOf("\\") == path.Length - 1)
            {
                path = path.Substring(0, path.Length - 1);
            }

            path = path.Replace("HKEY_LOCAL_MACHINE\\", "");
            path = path.Replace("HKEY_CURRENT_USER\\", "");

            return path.Substring(0, path.LastIndexOf("\\"));
        }

        /**
         * Returns all the subkeys of the path.
         */
        public static string[] getKeyTrailFromPath(string path)
        {
            path = getPathFromFullPath(path);

            while (path.LastIndexOf("\\") == path.Length - 1)
            {
                path = path.Substring(0, path.Length - 1);
            }

            return path.Split('\\');
        }
    }
}