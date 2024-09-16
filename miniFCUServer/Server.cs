using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using WindowsInput;
using WindowsInput.Native;

namespace MiniFCUServer
{
    internal class Server
    {
        //Server State
        public string isRunning { get; private set; }
        public string HostIp = "";

        string url = "http://*:8085/";
        HttpListener listener = new HttpListener();

        public async void Start()
        {
            // Get the IP from GetHostByName method of dns class. 
            string IP = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
            HostIp = IP;
            Console.WriteLine("IP Address is : " + IP);

            isRunning = null;
            try
            {
                listener.Prefixes.Add(url);
                listener.Start(); //Inicia server
                isRunning = "OK";

                Console.WriteLine("Server running");
            }
            catch (Exception e)
            {
                isRunning = e.Message;
                Console.WriteLine("Server error: " + e.Message);
            }


            bool btnState = false;

            while (isRunning == "OK")
            {
                try
                {
                    //Aguarda Solicitação
                    HttpListenerContext context = await listener.GetContextAsync();

                    //Pega REQ e RES
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;

                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
                    context.Response.ContentType = "application/json";

                    //Pega a o Rota
                    string route = request.Url.LocalPath.ToLower();

                    //Separa Query
                    string pid = request.QueryString["pid"];
                    string volume = request.QueryString["vol"];
                    string processName = request.QueryString["processname"];
                    string friendlyName = request.QueryString["friendlyname"];

                    string groupName = request.QueryString["groupname"];
                    string buttonName = request.QueryString["buttonname"];
                    string keyToPress= request.QueryString["keytopress"];
                    bool buttonMode= Convert.ToBoolean( request.QueryString["istoggle"] );

                    int increaseValue = 5;



                    switch (route)
                    {
                        case "/":
                            context.Response.ContentType = "text/html";
                            setResponse("" +
                                "<html>" +
                                "   <body>" +
                                "       <h1>MiniFCU - Servidor rodando</h1>" +
                                "       <p>/savedprocesslist -> Lista de apps salvos para acompanhar </p>" +
                                "       <p>/openprocesslist -> Lista de apps abertos (Emitindo som) </p>" +
                                "       <p>/setvolume -> Muda volume (Necessário PID e Vol como query) </p>" +
                                "       <p>/getvolume -> Pega volume (Necessário PID como query) </p>" +
                                "       <p>/gettime -> Retorna hora do sistema </p>" +
                                "       <p>/volumeup -> Aumenta volume conforme EncreaseValue (Necessário PID como query) </p>" + 
                                "       <p>/volumedown -> Diminui volume conforme EncreaseValue (Necessário PID como query) </p>" + 
                                "       <p>/savenewapp -> salva novo app (Necessario PROCESSNAME e FRIENDLYNAME como query) </p>" +
                                "       <p></p>" +
                                "       <p>/createshortcutgroup -> salva novo grupo de atalhos (Necessario GROUPNAME) </p>" + 
                                "       <p>/getshortcutgroup -> obtem novo grupo de atalhos (Necessario GROUPNAME) </p>" +
                                "       <p>/setshortcutbutton -> configura certo botao de atalhos (Necessario GROUPNAME, BUTTONNAME e KEYTOPRESS) </p>" + 
                                "       <p>/deleteshortcutgroup -> deleta novo grupo de atalhos (Necessario GROUPNAME) </p>" + 
                                "   </body>" +
                                "</html>" +
                                "");
                            Console.WriteLine("Processo: " + pid);
                            Console.WriteLine("Volume: " + volume);
                            break;

                        case "/savedprocesslist":
                            setResponse(VolumeMixer.VolumeMixerList()); ;
                            break;

                        case "/openprocesslist":
                            setResponse(VolumeMixer.GetOpenApps()); ;
                            break;

                        case "/setvolume":

                            response.ContentType = "text/html";
                            if (int.Parse(pid) == 0) //master
                            {
                                int newVolume = Convert.ToInt32(volume);
                                AudioControl.SetMasterVolume((float)newVolume / 100 > 1 ? 1 : (float)newVolume / 100);
                                setResponse($"Volume: {(AudioControl.GetMasterVolume() * 100).ToString()}");
                            }
                            else
                            {
                                WinMixerAPI.SetApplicationVolume(int.Parse(pid), float.Parse(volume));
                                setResponse("Volume: " + volume);
                            }

                            break;

                        case "/getvolume":
                            response.ContentType = "text/html";
                            if (int.Parse(pid) == 0) //master
                            {
                                float masterVolume = AudioControl.GetMasterVolume() * 100;
                                setResponse(masterVolume.ToString());
                            }
                            else
                            {
                                setResponse(WinMixerAPI.GetApplicationVolume(int.Parse(pid)).ToString());
                            }
                            break;

                        case "/gettime":
                            context.Response.ContentType = "text/html";
                            String hourMinute = DateTime.Now.ToString("HH:mm");
                            setResponse(hourMinute);
                            break;

                        case "/volumeup":
                            response.ContentType = "text/html";

                            if (int.Parse(pid) == 0) //master
                            {
                                float currentMaster = AudioControl.GetMasterVolume();
                                float newMaster = currentMaster + (float)increaseValue / 100;
                                AudioControl.SetMasterVolume(newMaster > 1 ? 1 : newMaster);
                                setResponse("Volume: " + newMaster*100);
                            }
                            else
                            {
                                int currentVolume = int.Parse(WinMixerAPI.GetApplicationVolume(int.Parse(pid)).ToString());
                                WinMixerAPI.SetApplicationVolume(int.Parse(pid), currentVolume + increaseValue);
                                setResponse("Volume: ");
                            }
                            break;

                        case "/volumedown":
                            response.ContentType = "text/html";

                            if (int.Parse(pid) == 0)
                            {
                                float currentMaster = AudioControl.GetMasterVolume();
                                float newMaster = currentMaster - (float)increaseValue / 100;
                                AudioControl.SetMasterVolume(newMaster < 0 ? 0 : newMaster);
                                setResponse("Volume: " + newMaster * 100);
                            }
                            else
                            {
                                int currentVolume = int.Parse(WinMixerAPI.GetApplicationVolume(int.Parse(pid)).ToString());
                                WinMixerAPI.SetApplicationVolume(int.Parse(pid), currentVolume - increaseValue);
                                setResponse("Volume: ");
                            }
                            break;

                        case "/savenewapp":
                            VolumeMixer.SaveNewApp(processName, friendlyName);
                            setResponse($"Process: {processName} Friendly name: {friendlyName} saved!");
                            break;


                        // #### SHORTCUT GROUP ####

                        case "/createshortcutgroup":
                            VolumeMixer.CreateNewShortcutGroup(groupName);
                            setResponse($"{groupName} criado!");
                            break;

                        case "/getshortcutgroup":
                            setResponse(VolumeMixer.GetShortcutGroup(groupName));
                            break;

                        case "/getshortcutgroups":
                            setResponse(VolumeMixer.GetShortcutGroups());
                            break;

                        case "/setshortcutbutton":
                            setResponse(VolumeMixer.SetShortcutButtons(groupName, buttonName, keyToPress));
                            break;

                        case "/setshortcutbuttonmode":
                            setResponse(VolumeMixer.SetShortcutButtons(groupName, buttonName, buttonMode));
                            break;

                        case "/deleteshortcutgroup":
                            VolumeMixer.DeleteShortcutGroup(groupName);
                            setResponse($"{groupName} deletado!");
                            break;

                        case "/pressbutton":
                            //SendKeys.Send("{" + keyToPress +"}");
                            InputSimulator InputSimulator = new InputSimulator();
                            VirtualKeyCode key; 

                            if(Enum.TryParse(keyToPress, true, out key))
                            {
                                InputSimulator.Keyboard.KeyPress(key);
                                setResponse($"{keyToPress} pressed!");
                            } else
                            {
                                setResponse($"key not found!!");
                            }
                            break;

                        case "/buttonslist":
                            string buttonsList = "{\"Backspace\":\"BACK\",\"Tab\":\"TAB\",\"Clear\":\"CLEAR\",\"Enter\":\"RETURN\",\"Shift\":\"SHIFT\",\"Pause\":\"PAUSE\",\"CapsLock\":\"CAPITAL\",\"Space\":\"SPACE\",\"PageUp\":\"PRIOR\",\"PageDown\":\"NEXT\",\"End\":\"END\",\"Home\":\"HOME\",\"Left\":\"LEFT\",\"Up\":\"UP\",\"Right\":\"RIGHT\",\"Down\":\"DOWN\",\"Select\":\"SELECT\",\"Print\":\"PRINT\",\"PrintScreen\":\"SNAPSHOT\",\"Insert\":\"INSERT\",\"Delete\":\"DELETE\",\"0\":\"VK_0\",\"1\":\"VK_1\",\"2\":\"VK_2\",\"3\":\"VK_3\",\"4\":\"VK_4\",\"5\":\"VK_5\",\"6\":\"VK_6\",\"7\":\"VK_7\",\"8\":\"VK_8\",\"9\":\"VK_9\",\"A\":\"VK_A\",\"B\":\"VK_B\",\"C\":\"VK_C\",\"D\":\"VK_D\",\"E\":\"VK_E\",\"F\":\"VK_F\",\"G\":\"VK_G\",\"H\":\"VK_H\",\"I\":\"VK_I\",\"J\":\"VK_J\",\"K\":\"VK_K\",\"L\":\"VK_L\",\"M\":\"VK_M\",\"N\":\"VK_N\",\"O\":\"VK_O\",\"P\":\"VK_P\",\"Q\":\"VK_Q\",\"R\":\"VK_R\",\"S\":\"VK_S\",\"T\":\"VK_T\",\"U\":\"VK_U\",\"V\":\"VK_V\",\"W\":\"VK_W\",\"X\":\"VK_X\",\"Y\":\"VK_Y\",\"Z\":\"VK_Z\",\"Left_Win\":\"LWIN\",\"Right_Win\":\"RWIN\",\"Sleep\":\"SLEEP\",\"Numpad0\":\"NUMPAD0\",\"Numpad1\":\"NUMPAD1\",\"Numpad2\":\"NUMPAD2\",\"Numpad3\":\"NUMPAD3\",\"Numpad4\":\"NUMPAD4\",\"Numpad5\":\"NUMPAD5\",\"Numpad6\":\"NUMPAD6\",\"Numpad7\":\"NUMPAD7\",\"Numpad8\":\"NUMPAD8\",\"Numpad9\":\"NUMPAD9\",\"*\":\"MULTIPLY\",\"+\":\"ADD\",\"-\":\"SUBTRACT\",\",\":\"DECIMAL\",\"/\":\"DIVIDE\",\"F1\":\"F1\",\"F2\":\"F2\",\"F3\":\"F3\",\"F4\":\"F4\",\"F5\":\"F5\",\"F6\":\"F6\",\"F7\":\"F7\",\"F8\":\"F8\",\"F9\":\"F9\",\"F10\":\"F10\",\"F11\":\"F11\",\"F12\":\"F12\",\"F13\":\"F13\",\"F14\":\"F14\",\"F15\":\"F15\",\"F16\":\"F16\",\"F17\":\"F17\",\"F18\":\"F18\",\"F19\":\"F19\",\"F20\":\"F20\",\"F21\":\"F21\",\"F22\":\"F22\",\"F23\":\"F23\",\"F24\":\"F24\",\"Numlock\":\"NUMLOCK\",\"Scroll\":\"SCROLL\",\"Left_shift\":\"LSHIFT\",\"Right_shift\":\"RSHIFT\",\"Left_ctrl\":\"LCONTROL\",\"Right_ctrl\":\"RCONTROL\",\"Browser_Back\":\"BROWSER_BACK\",\"Browser_Forward\":\"BROWSER_FORWARD\",\"Browser_Refresh\":\"BROWSER_REFRESH\",\"Browser_Stop\":\"BROWSER_STOP\",\"Browser_Search\":\"BROWSER_SEARCH\",\"Browser_Favorites\":\"BROWSER_FAVORITES\",\"Browser_Home\":\"BROWSER_HOME\",\"Volume_Mute\":\"VOLUME_MUTE\",\"Volume_Down\":\"VOLUME_DOWN\",\"Volume_Up\":\"VOLUME_UP\",\"Media_Next_Track\":\"MEDIA_NEXT_TRACK\",\"Media_Prev_Track\":\"MEDIA_PREV_TRACK\",\"Media_Stop\":\"MEDIA_STOP\",\"Media_Play_Pause\":\"MEDIA_PLAY_PAUSE\",\"Launch_Mail\":\"LAUNCH_MAIL\"}"; 
                            setResponse(buttonsList);
                            break;

                        case "/teste":
                            VolumeMixer.SaveNewApp(processName, friendlyName);
                            setResponse($"pid: {pid} vol: {volume}");
                            break;


                    }

                    void setResponse(string res)
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(res);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                        response.OutputStream.Close();
                    }

                }
                catch (Exception e)
                {
                    isRunning = e.Message.ToString();

                    Debug.WriteLine("Server error:");
                    Debug.WriteLine(e.Message);
                }

            }

        }

        public void Stop()
        {
            listener.Stop();
            isRunning = "Disconnected";

        }
    }
}
