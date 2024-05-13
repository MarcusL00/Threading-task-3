using System;
using System.Threading;

namespace Threading_task_3
{
    internal class Program
    {
        static int alarmCount = 0;
        static bool isAlarmThreadAlive = true;
        static void Main()
        {
            // Creates a thread that generates a random themperature
            Thread temperatureThread = new Thread(GenerateTemperature);
            temperatureThread.Start();
            // Creates a thread to check status of the alarm thread
            Thread checkThread = new Thread(CheckAlarmThread);
            checkThread.Start();
            // Await TemperatureThread thread to be done
            temperatureThread.Join();

            // Temperaturethread is done, stop checkThread
            isAlarmThreadAlive=false;
            checkThread.Join();

            Console.WriteLine("Alarm tråd er død");
        }


        static void GenerateTemperature()
        {
            // Create an instance of a random class
            Random rnd = new Random();

            while (alarmCount < 3)
            {
                // Generates a random value from -20 upto 120
                int temperature = rnd.Next(-20,121);

                Console.WriteLine("temperaturen: " + temperature + " C");

                // Check for alarm and increments alarmCount, if the temperature is out of the allowed scope
                if (temperature < 0 || temperature > 100)
                {
                    Console.WriteLine("ALARM! temperaturen er udenfor det tilladte interval");
                    alarmCount++;
                }
                // wait 2 secounds
                Thread.Sleep(2000);
            }
        }
        static void CheckAlarmThread()
        {
            while (isAlarmThreadAlive) 
            {
            // Await 10 secounds
             Thread.Sleep(10000);
            // Checks if the alarm thread is alive
             if (!isAlarmThreadAlive) 
                
             return;
             // If the alarm thread is done, write to the console
             Console.WriteLine("Alarm-tråd stadig i live...");
                
            }
        }
    }
}
