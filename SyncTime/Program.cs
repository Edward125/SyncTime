using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace SyncTime
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;  
            bool FolderExist = false;
            string DiskName = string.Empty;



            while (!isExit)
            {
                displaymsg();
                //ConsoleKeyInfo kinfo = Console.ReadKey();   //获取用户按键

                //if (kinfo.Key == ConsoleKey.Escape)
                //{
                //    Environment.Exit(0);
                //}
                //else
                //{
                    do
                    {
                        DiskName = Console.ReadLine();

                        if (DiskName.Trim().ToUpper() != "!Q")
                        {
                            Console.WriteLine("你输入的盘符为:" + DiskName);
                            FolderExist = Directory.Exists(DiskName + @":\");
                            if (!FolderExist)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("你输入的盘符" + DiskName + @":\不存在,请重新输入.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("侦测到字符:" + DiskName + ",软件将退出.");
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                        }



                       
                    } while (!FolderExist);
                    writetime(DiskName);
               // }
            }


        }


        static void writetime(string Folder)
        {
            StreamWriter sw = new StreamWriter( Folder + @":\DATE.txt", false);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("已生成同步时间的文件DATE.txt,时间为:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.ForegroundColor = ConsoleColor.White;
            sw.Close ();
        }


        static  void displaymsg()
        {
          //  Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("恒安电击枪时间同步工具,Ver:1.0.1.0");
            Console.WriteLine("Copyright @ HengAn 2018");
            Console.WriteLine("插入电击枪后,输入电击枪行成的U盘盘符,如G,按回车,需要退出软件,输入!q(不区分大小写),按回车退出");
            Console.WriteLine("*****************************************************************");
        }
    }
}
