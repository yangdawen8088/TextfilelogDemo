using System;
using System.IO;

namespace TextfilelogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("\n请输入日志信息：");
                string logMSG = Console.ReadLine();
                Console.Write("请输入日志保存日期（eg：2021-05-16 12:35）：");
                string logTimestr = Console.ReadLine();
                DateTime logTime = new DateTime();
                while (!DateTime.TryParse(logTimestr, out logTime))
                {
                    Console.Write("日期输入出错，请重新输入：");
                    logTimestr = Console.ReadLine();
                }
                logTime = Convert.ToDateTime(logTimestr);
                string path = @"D:\LogDemo\";
                logMSG = Guid.NewGuid().ToString() + " " + DateTime.Now.ToString("G") + " " + logMSG;
                action(logMSG, logTime, path);
                Console.WriteLine("按任意键继续，按ESC键结束程序。");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void action(string logMSG, DateTime logTime, string path)
        {
            string dirPath = path + logTime.ToString("Y");
            if (!Directory.Exists(dirPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(dirPath);
                directoryInfo.Create();
            }
            string logFileName = dirPath + "\\" + logTime.ToString("D") + ".txt";
            if (!File.Exists(logFileName))
            {
                FileStream fileStream = File.Create(logFileName);
                fileStream.Close();
            }
            StreamWriter streamWriter = new StreamWriter(logFileName, true, System.Text.Encoding.Default);
            streamWriter.WriteLine(logMSG);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}