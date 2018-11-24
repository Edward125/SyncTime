using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SyncTime
{
    class Program
    {
        static void Main(string[] args)
        {

            bool FolderExist = false;
            string DiskName = string.Empty;
            do
            {
                Console.WriteLine("请输入电击枪行成的U盘盘符,如G,按回车");
                DiskName = Console.ReadLine();
                Console.WriteLine("你输入的盘符为:" + DiskName);
                 FolderExist = Directory.Exists(DiskName + @":\");
                if (!FolderExist )
                {
                    Console.WriteLine("你输入的盘符" + DiskName + @":\不存在,请重新输入.");
                }
            } while (!FolderExist);
            writetime(DiskName);
            Console.WriteLine("按任意键退出");
            Console.ReadKey(); 
        }


        static void writetime(string Folder)
        {
            StreamWriter sw = new StreamWriter( Folder + @":\DATE.txt", false);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("已生成同步时间的文件DATE.txt,时间为:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sw.Close ();
        }
    }
}
