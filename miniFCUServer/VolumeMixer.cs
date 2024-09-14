using Salaros.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Packaging;
using System.Windows.Forms;

namespace MiniFCUServer
{
    public class VolumeMixer
    {
        static string appConfig = Application.StartupPath + @"\appConfig.ini";
        public static string currentShortcutGroup = "";

        /*
        public static string ProgramsList()
        {
            //string msg = "[{\"process\": \"leonardo\", \"PID\": 24}, {\"process\": \"daniele\", \"PID\": 25}]";
            string jsonList = "[";

            jsonList += "{";
            jsonList += $"\"process\": \"Main\", \"pid\": 0";
            jsonList += "},";

            foreach (var program in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(WinMixerAPI.GetApplicationVolume(program.Id).ToString()))
                {
                    jsonList += "{";
                    jsonList += $"\"process\": \"{program.ProcessName}\", \"pid\": {program.Id}";
                    jsonList += "},";

                }
            }

            jsonList = jsonList.Substring(0, jsonList.Length - 1);
            jsonList += "]";
            return jsonList;
        }
        */
        public static string VolumeMixerList()
        {
            var cfg = new ConfigParser(appConfig);
            //string msg = "[{\"process\": \"leonardo\", \"PID\": 24}, {\"process\": \"daniele\", \"PID\": 25}]";
            string jsonList = "[";

            jsonList += "{";
            jsonList += $"\"process\": \"main\", \"pid\": 0, \"name\": \"Principal\"";
            jsonList += "},";

            foreach (var process in Process.GetProcesses())
            {
                foreach (var key in cfg["FRIENDLY NAMES"].Keys)
                {
                    if (process.ProcessName == key.Name.ToString() && key.ValueRaw.ToString() != "")
                    {
                        if (!string.IsNullOrEmpty(WinMixerAPI.GetApplicationVolume(process.Id).ToString()))
                        {
                            jsonList += "{";
                            jsonList += $"\"process\": \"{process.ProcessName}\", \"pid\": {process.Id}, \"name\": \"{cfg["FRIENDLY NAMES"][key.Name]}\"";
                            jsonList += "},";
                            //Console.WriteLine("Process: " + cfg["FRIENDLY NAMES"][key.Name] + " Volume: " + WinMixerAPI.GetApplicationVolume(process.Id));
                        }
                    }
                }
            }


            jsonList = jsonList.Substring(0, jsonList.Length - 1);
            jsonList += "]";
            return jsonList;
        }

        public static string GetOpenApps()
        {
            string json = "[";


            foreach (var process in Process.GetProcesses())
            {
                if (!string.IsNullOrEmpty(WinMixerAPI.GetApplicationVolume(process.Id).ToString()) && process.ProcessName != "Idle")
                {
                    json += "{";
                    json += $"\"process\": \"{process.ProcessName}\", \"pid\": {process.Id}";
                    json += "},";
                }
            }

            json = json.Substring(0, json.Length - 1);
            json += "]";
            return json;

        }

        public static bool SaveNewApp(string key, string value)
        {
            var cfg = new ConfigParser(appConfig);
            cfg.SetValue("FRIENDLY NAMES", key, value);
            cfg.Save();

            return true;
        }


        // #### SHORTCUT GROUP ####
        public static bool CreateNewShortcutGroup(string groupName)
        {
            var cfg = new ConfigParser(appConfig);

            //Save name
            cfg.SetValue("Shortcut Group", groupName.Replace(" ", ""), groupName);

            //Butons Value
            cfg.SetValue(groupName, "ap", "");
            cfg.SetValue(groupName, "vs", "");
            cfg.SetValue(groupName, "nav", "");
            cfg.SetValue(groupName, "apr", "");
            cfg.SetValue(groupName, "hdr", "");

            //Butons Mode
            cfg.SetValue(groupName, "aptoogle", false);
            cfg.SetValue(groupName, "vstoggle", false);
            cfg.SetValue(groupName, "navtoggle", false);
            cfg.SetValue(groupName, "aprtoggle", false);
            cfg.SetValue(groupName, "hdrtoggle", false);

            cfg.Save();

            return true;
        }
        public static string GetShortcutGroup(string groupName)
        {
            string convertedToJson = "{";

            var cfg = new ConfigParser(appConfig);
            foreach (var keys in cfg[groupName].Keys)
            {
                convertedToJson +=  $"\"{keys.Name}\":\"{keys.ValueRaw}\",";
            }

            convertedToJson = convertedToJson.Remove(convertedToJson.Length - 1, 1);
            convertedToJson += "}";
            Debug.Write(convertedToJson);
            return convertedToJson;
        }
        public static string[] GetActiveShortcutGroup()
        {
            var cfg = new ConfigParser(appConfig);
            List<string>  activeList = new List<string>();

            foreach(var key in cfg["Shortcut Group"].Keys)
            {
                activeList.Add(key.Name);
            }

            string[] returnArray = activeList.ToArray();
            Debug.Write(returnArray[0]);

            return activeList.ToArray();
        }
        public static string SetShortcutButtons(string shortcutGroup, string buttonName, string keyToPress)
        {
            var cfg = new ConfigParser(appConfig);

            switch (buttonName)
            {
                case "ap":
                    cfg.SetValue(shortcutGroup, "ap", keyToPress);
                    break;
                case "vs":
                    cfg.SetValue(shortcutGroup, "vs", keyToPress);
                    break;
                case "nav":
                    cfg.SetValue(shortcutGroup, "nav", keyToPress);
                    break;
                case "apr":
                    cfg.SetValue(shortcutGroup, "apr", keyToPress);
                    break;
                case "hdr":
                    cfg.SetValue(shortcutGroup, "hdr", keyToPress);
                    break;
                default:
                    Debug.Write("Key not found!");
                    break;
            }

            cfg.Save();

            return $"{buttonName} set to {keyToPress}";
        }
        public static void DeleteShortcutGroup(string groupName)
        {
            var cfg = new ConfigParser(appConfig);

            cfg.SetValue("Shortcut Group", groupName.Replace(" ",""), false);
            cfg.Save();
        }
    }
}