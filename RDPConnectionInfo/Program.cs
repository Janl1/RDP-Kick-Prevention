using Microsoft.Win32;
using System;
using System.IO;
using IniParser;
using IniParser.Model;
using System.Security;

namespace RDPConnectionInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileIniDataParser parser;
                IniData data;
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.ini"))
                {
                    StreamWriter ws = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "config.ini");
                    ws.WriteLine("[Settings]");
                    ws.WriteLine("MessagesCaption = \"WARNING!\"");
                    ws.WriteLine("MessageText = \"There is currently a user connected to this rdp session! If you countinue, he will get kicked out!\"");
                    ws.Flush();
                    ws.Close();
                }

                if (args.Length != 1)
                {
                    Console.WriteLine("RDPConnectionInfo V.0.0.1\nUsage: <RDPConnectionInfo>.exe start|stop");
                    Console.ReadLine();
                    return;
                }

                parser = new FileIniDataParser();
                data = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini");

                if (args[0] == "start")
                {
                    try
                    {
                        RegistryKey myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                        if (myKey != null)
                        {
                            myKey.SetValue("legalnoticetext", data["Settings"]["MessageText"].Replace("\"", ""), RegistryValueKind.String);
                            myKey.SetValue("legalnoticecaption", data["Settings"]["MessagesCaption"].Replace("\"", ""), RegistryValueKind.String);
                            myKey.Close();
                        }
                        Console.WriteLine("Done");
                    }
                    catch (SecurityException ex)
                    {
                        Console.WriteLine("Fehler: {0}", ex.GetBaseException());
                        Console.ReadLine();
                        return;
                    }
                }
                else if (args[0] == "stop")
                {
                    try
                    {
                        RegistryKey myKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                        if (myKey != null)
                        {
                            myKey.SetValue("legalnoticetext", "", RegistryValueKind.String);
                            myKey.SetValue("legalnoticecaption", "", RegistryValueKind.String);
                            myKey.Close();
                        }
                        Console.WriteLine("Done");
                    }
                    catch(SecurityException ex)
                    {
                        Console.WriteLine("Fehler: {0}", ex.GetBaseException());
                        Console.ReadLine();
                        return;
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Fehler: {0}", ex.GetBaseException());
                Console.ReadLine();
            }
        }
    }
}
