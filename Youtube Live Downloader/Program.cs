using System;
using System.IO;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Youtube_Live_Downloader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int EndApp = 0;
            String StreamUrl, StreamDate, StreamTime, Savefolder;

            Savefolder = AppDomain.CurrentDomain.BaseDirectory + @"\saves\";
            
            StreamUrl = "https://www.youtube.com/watch?v=uiZkYwiHRHI"; //https://youtu.be/xjAQin0gZsU
            StreamDate = "18/08/2023";
            StreamTime = "7:55:00 PM"; 
            


            Console.WriteLine("Stream Downloader!");

            using var client = new HttpClient();
            var content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text="+ HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Stream Downloader Started :" + StreamUrl));
           
           // Console.WriteLine(content);



            while (StreamDate != DateTime.Now.ToString("dd/MM/yyyy"))
            {
                Console.WriteLine("Date has not arrived yet! - "+ DateTime.Now.ToString("dd/MM/yyyy"));
               // using var client = new HttpClient();
                 content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: Date has not arrived yet. - "+ DateTime.Now.ToString("dd/MM/yyyy")));

                Thread.Sleep(1800000);
            }
                Console.WriteLine("Date has arrived! - " + DateTime.Now.ToString("dd/MM/yyyy"));
            content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: Date has arrived ! - "+ DateTime.Now.ToString("dd/MM/yyyy")));

            int count = 30;
            while (DateTime.Parse(DateTime.Now.ToString("h:mm:ss tt")) < DateTime.Parse(StreamTime)  )
            {
                Console.WriteLine("Time has not arrived yet! - "+ DateTime.Now.ToString("h:mm:ss tt"));
                if(count == 30)
                { 
                content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: Time has not arrived !- " + DateTime.Now.ToString("h:mm:ss tt")));
                    count = 0;
                }
                count++;
            Thread.Sleep(30000);
            }
            Console.WriteLine("Time has arrived!");
            content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: Time has arrived ! - " + DateTime.Now.ToString("h:mm:ss tt")));


            while (EndApp == 0)
            {

                content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: Attempting to download !"));



                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C yt-dlp --hls-use-mpegts --prefer-ffmpeg -R infinite -o \"" + Savefolder + "reollive.mp4\" "+StreamUrl;
                //startInfo.Arguments = "/C youtube-dl "+StreamUrl;

                //youtube-dl -f 94 -g https://www.youtube.com/watch\?v\=21X5lGlDOfg

                process.StartInfo = startInfo;
                //process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();


                string strOutput2 = process.StandardError.ReadToEnd();
                // Console.WriteLine("E:" + strOutput2);
                // string strOutput = process.StandardOutput.ReadToEnd();
                //Console.WriteLine("O:"+strOutput);

               

                if (Directory.GetFiles(Savefolder, "*.*").Length != 0)
                {
                    Console.WriteLine("File exists...");
                    content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: File Exists !"));

                    EndApp = 1;
                }
                else
                {
                    Console.WriteLine("Download Failed Retrying in 30 sec...");
                    content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Console: Download Failed Retryin in 30 Sec !"));

                    Thread.Sleep(30000);
                }



                /*
                if (strOutput2 == null)
                {
                    Console.WriteLine("Download Success!");
                    Console.WriteLine("O:" + strOutput2);
                    EndApp = 1;
                }
                else
                {
                    Console.WriteLine("Download Failed Retrying in 30 sec...");
                    Console.WriteLine("O:" + strOutput2);
                    Thread.Sleep(30000);
                }
                */

            }
            content = await client.GetStringAsync("https://api.telegram.org/bot1190059827:AAGqxkC9vITt_8zmP9emOyYxdyxbqZNHEo0/sendMessage?chat_id=552846698&text=" + HttpUtility.UrlEncode("[YTLIVEDOWNLOADER] Terminated successfully !"));


            Console.WriteLine("Press Enter to exit!");
            //Console.WriteLine("You entered '{0}'", testString);
            Console.ReadLine();
        }
    }
}
