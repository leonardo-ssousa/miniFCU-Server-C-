using Salaros.Configuration;
using System;
using System.Diagnostics;
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

        public static bool CreateNewShortcutGroup(string groupName)
        {
            var cfg = new ConfigParser(appConfig);

            cfg.SetValue(groupName, "apBtn", "");
            cfg.SetValue(groupName, "vsBtn", "");
            cfg.SetValue(groupName, "navBtn", "");
            cfg.SetValue(groupName, "aprBtn", "");
            cfg.SetValue(groupName, "hdrBtn", "");

            cfg.Save();

            return true;
        }

        public static bool SetShortcutButtons(string buttonName, string keyToPress)
        {
            var cfg = new ConfigParser(appConfig);

            switch (buttonName)
            {
                case "apBtn":
                    cfg.SetValue(currentShortcutGroup, "apBtn", "keyToPress");
                    break;
                case "vsBtn":
                    cfg.SetValue(currentShortcutGroup, "vsBtn", "keyToPress");
                    break;
                case "navBtn":
                    cfg.SetValue(currentShortcutGroup, "navBtn", "keyToPress");
                    break;
                case "aprBtn":
                    cfg.SetValue(currentShortcutGroup, "aprBtn", "keyToPress");
                    break;
                case "hdrBtn":
                    cfg.SetValue(currentShortcutGroup, "hdrBtn", "keyToPress");
                    break;
                default:
                    Debug.Write("Key not found!");
                    break;
            }

            cfg.Save();

            return true;
        }
    }
}