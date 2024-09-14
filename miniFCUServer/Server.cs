using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

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
                                "       <p>/getactiveshortcutgroup -> obtem a lista de grupos de atalhos ativos</p>" +
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
                            setResponse($"pid: {pid} vol: {volume}");
                            break;

                        // #### SHORTCUT GROUP ####

                        case "/createshortcutgroup":
                            VolumeMixer.CreateNewShortcutGroup(groupName);
                            setResponse($"{groupName} criado!");
                            break;

                        case "/getshortcutgroup":
                            setResponse(VolumeMixer.GetShortcutGroup(groupName));
                            break;

                        case "/getactiveshortcutgroup":
                            setResponse(VolumeMixer.GetActiveShortcutGroup().ToString());
                            break;

                        case "/setshortcutbutton":
                            setResponse(VolumeMixer.SetShortcutButtons(groupName, buttonName, keyToPress));
                            break;

                        case "/deleteshortcutgroup":
                            VolumeMixer.DeleteShortcutGroup(groupName);
                            setResponse($"{groupName} deletado!");
                            break;

                        case "/btn3":
                            //SendKeys.Send(Keys.BrowserHome.ToString());
                            
                            btnState = !btnState;
                            Console.WriteLine(btnState);
                            setResponse(Convert.ToString(btnState));
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
