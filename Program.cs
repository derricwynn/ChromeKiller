using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Media;
using System.IO;



namespace StealthProcesskiller
{
    // 
    // OK this is my 2nd Program... Kinda
    // Its actually my 1st program but in console format to work in conjunction with windows task scheduler
    // See readme for details. 

    

    // The Reminder class contains a method that Flashes a message on the console screen, displays time/date and plays the windows shutdown sound. to let my kids know they are up TOO LATE!

    class Reminder
    {
        public void Ohyea()
        {

            SoundPlayer gotobed = new SoundPlayer(@"C:\windows\media\Windows Shutdown.wav");
            gotobed.Play();


            for (int i = 0;  i <= 9000; i++)
            { 
            Console.WriteLine("    |          TIME FOR BED LADIES!!!");
                Console.WriteLine("     |");
             
        }
            DateTime datime = DateTime.Now;
            Console.WriteLine("It is  {0}", datime );
        Console.ReadKey();

        }

    }
    
    class Program
    {
        static bool flag;   //boolean flag to see if chrome is running or not

        class AppActiveOrNah    
        {
            public void ActiveAppOrNah(string appName = "chrome")  // Replace chrome with program you want to see if it is running. 
            {
                Process[] ProcessList = Process.GetProcessesByName(appName);

                foreach (Process p in ProcessList)
                {

                    Console.WriteLine(ProcessList);
                    if (p.ProcessName.Contains(appName))
                    {

                        flag = true;
                        
                        break;

                    }
                    else
                    {

                        flag = false;

                    }
                                        
                }
                                                             
            }

        }
        
                                 
        static void Main(string[] args)
        {
              var k = new AppActiveOrNah();
              var r = new Reminder();
           
             k.ActiveAppOrNah();
            if (flag)
            {
                foreach (var chromeprocess in Process.GetProcessesByName("chrome"))    // Here if the application in question is currently running we kill it
                {
                    chromeprocess.Kill();

                    
                }
                r.Ohyea();
            }
                      
        }
    }
}
