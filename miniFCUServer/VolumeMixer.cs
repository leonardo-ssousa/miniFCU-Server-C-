using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Salaros.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Windows.Forms;

namespace MiniFCUServer
{
    public class VolumeMixer
    {
        static string appConfig = Application.StartupPath + @"\appConfig.ini";

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

        private static readonly string groupListName = "Shortcut Groups";
        private class ShortcutGroup
        {
            public string name { set; get; }
            public string ap { set; get; }
            public string vs { set; get; }
            public string nav { set; get; }
            public string apr { set; get; }
            public string hdr { set; get; }

            public bool apIsToggle { set; get; }
            public bool vsIsToggle { set; get; }
            public bool navIsToggle { set; get; }
            public bool aprIsToggle { set; get; }
            public bool hdrIsToggle { set; get; }
        }


        public static bool CreateNewShortcutGroup(string groupName)
        {
            var cfg = new ConfigParser(appConfig);


            var newGroup = new ShortcutGroup
            {
                name = groupName,
                ap = "F13",
                vs = "F14",
                nav = "F15",
                apr = "F16",
                hdr = "F17",

                apIsToggle = false,
                vsIsToggle = false,
                navIsToggle = false,
                aprIsToggle = false,
                hdrIsToggle = false,

            };

            //Save group
            cfg.SetValue("Shortcut Groups", groupName.Replace(" ", ""), JsonConvert.SerializeObject(newGroup));
            cfg.Save();

            return true;
        }
        public static string GetShortcutGroup(string groupName)
        {

            var cfg = new ConfigParser(appConfig);

            foreach(var key in cfg["Shortcut Groups"].Keys)
            {
                if (key.Name == groupName.Replace(" ", ""))
                {
                    return cfg["Shortcut Groups"][groupName.Replace(" ", "")];
                }
            }

            return "Shortcut group not found!";
        }
        public static string GetShortcutGroups()
        {

            var cfg = new ConfigParser(appConfig);
            string shortcutGroups = "[";

            foreach (var key in cfg["Shortcut Groups"].Keys)
            {
                shortcutGroups += $"\"{key.Name}\",";
                Debug.WriteLine(key);
            }

            shortcutGroups = shortcutGroups.Substring(0, shortcutGroups.Length - 1);
            shortcutGroups += "]";

            return shortcutGroups;
        }
        public static string SetShortcutButtons(string shortcutGroup, string buttonName, string keyToPress)
        {
            var cfg = new ConfigParser(appConfig);
            foreach (var key in cfg["Shortcut Groups"].Keys)
            {
                if (key.Name == shortcutGroup.Replace(" ", ""))
                {
                    string group = cfg.GetValue(groupListName, shortcutGroup.Replace(" ", "")); ;
                    ShortcutGroup toJson = JsonConvert.DeserializeObject<ShortcutGroup>(group);

                    switch (buttonName.ToLower())
                    {
                        case "ap":
                            toJson.ap = keyToPress;
                            break;
                        case "vs":
                            toJson.vs = keyToPress;
                            break;
                        case "nav":
                            toJson.nav = keyToPress;
                            break;
                        case "apr":
                            toJson.apr = keyToPress;
                            break;
                        case "hdr":
                            toJson.hdr = keyToPress;
                            break;
                        default:
                            Debug.Write("Key not found!");
                            break;
                    }

                    cfg.SetValue(groupListName, shortcutGroup.Replace(" ", ""), JsonConvert.SerializeObject(toJson));
                    cfg.Save();

                    return $"{buttonName} set to {keyToPress}";
                }
            }

            return "Shortcut group not found!";            
        }
        public static string SetShortcutButtons(string shortcutGroup, string buttonName, bool buttonMode)
        {
            var cfg = new ConfigParser(appConfig);
            foreach (var key in cfg["Shortcut Groups"].Keys)
            {
                if (key.Name == shortcutGroup.Replace(" ", ""))
                {
                    string group = cfg.GetValue(groupListName, shortcutGroup.Replace(" ", "")); ;
                    ShortcutGroup toJson = JsonConvert.DeserializeObject<ShortcutGroup>(group);

                    switch (buttonName.ToLower())
                    {
                        case "ap":
                            toJson.apIsToggle = buttonMode;
                            break;
                        case "vs":
                            toJson.vsIsToggle = buttonMode;
                            break;
                        case "nav":
                            toJson.navIsToggle = buttonMode;
                            break;
                        case "apr":
                            toJson.aprIsToggle = buttonMode;
                            break;
                        case "hdr":
                            toJson.hdrIsToggle = buttonMode;
                            break;
                        default:
                            Debug.Write("Key not found!");
                            break;
                    }

                    cfg.SetValue(groupListName, shortcutGroup.Replace(" ", ""), JsonConvert.SerializeObject(toJson));
                    cfg.Save();

                    return $"{buttonName} set to {(buttonMode ? "toggle" : "not toggle")}";
                }
            }

            return "Shortcut group not found!";
        }
        public static void DeleteShortcutGroup(string groupName)
        {
            var cfg = new ConfigParser(appConfig);

            cfg.SetValue("Shortcut Group", groupName.Replace(" ",""), false);
            cfg.Save();
        }
    }
}