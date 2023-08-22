using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Youtube_Live_Downloader
{
    class Settings
    {
        public static Dictionary<string, string> appsettings() // Change the return type to match the array of tuples
        {
            var MyIni = new IniFile("Settings.ini");
            var settingsDictionary = new Dictionary<string, string>
            {
                { "folder", "saves" }
            };

            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\" + settingsDictionary["folder"] + @"\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\" + settingsDictionary["folder"] + @"\");
                Console.WriteLine($"Folder '{Directory.GetCurrentDirectory() + @"\" + settingsDictionary["folder"] + @"\"}' created.");
            }
            


            if (!MyIni.KeyExists("YouTube_Url"))
            {
                MyIni.Write("YouTube_Url", "https://www.youtube.com/watch?v=zJ58jXq2qOo");
               
            }
            settingsDictionary.Add("YouTube_Url", MyIni.Read("YouTube_Url"));
            if (!MyIni.KeyExists("Telegram_Bot_Key"))
            {
                MyIni.Write("Telegram_Bot_Key", "botXXX:XXXX");
            }
            settingsDictionary.Add("Telegram_Bot_Key", MyIni.Read("Telegram_Bot_Key"));
            if (!MyIni.KeyExists("Telegram_chat_id"))
            {
                MyIni.Write("Telegram_chat_id", "00000000");
            }
            settingsDictionary.Add("Telegram_chat_id", MyIni.Read("Telegram_chat_id"));
            if (!MyIni.KeyExists("Live_date"))
            {
                MyIni.Write("Live_date", "28/11/1999");
            }
            settingsDictionary.Add("Live_date", MyIni.Read("Live_date"));
            if (!MyIni.KeyExists("Live_time"))
            {
                MyIni.Write("Live_time", "7:55:00 PM");
            }
            settingsDictionary.Add("Live_time", MyIni.Read("Live_time"));
            if (!MyIni.KeyExists("file_name"))
            {
                MyIni.Write("file_name", "video");
            }
            settingsDictionary.Add("file_name", MyIni.Read("file_name"));


            

            return settingsDictionary;



        }
    }
}
