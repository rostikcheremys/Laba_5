using System;

namespace Program
{
    struct MyTime 
    {
        public int hour, minute, second;
        public MyTime(int h, int m, int s)
        {
            if (h > 23 || h < -23 )
            {
                hour = h %= 24;
            }
            if (m >= 0 && m <= 59 && s >= 0 && s <= 59)
            {
                hour = h;
                minute = m;
                second = s;
            }
            else
            {
                throw new Exception("Invalid time format!");
            }
        }
        public override string ToString()
        {
            return $"{hour:D1}:{minute:D2}:{second:D2}";
        }
    }
    internal class Program
    {
        public static int TimeSinceMidnight(MyTime t)
        {
            return t.hour * 3600 + t.minute * 60 + t.second;
        }
        
        public static MyTime TimeSinceMidnight(int t)
        {
            int hour = t / 3600;
            t %= 3600;
            int minute = t / 60;
            int second = t % 60;
            
            return new MyTime(hour, minute, second);
        }
        
        public static MyTime AddOneSecond(MyTime t) 
        {
            int totalSeconds = TimeSinceMidnight(t) + 1;
            
            return TimeSinceMidnight(totalSeconds);
        }
        
        public static MyTime AddOneMinute(MyTime t) 
        {
            int totalSeconds = TimeSinceMidnight(t) + 60;
            
            return TimeSinceMidnight(totalSeconds);
        }
        
        public static MyTime AddOneHour(MyTime t) 
        {
            int totalSeconds = TimeSinceMidnight(t) + 3600;
            
            return TimeSinceMidnight(totalSeconds);
        }
        
        public static MyTime AddSeconds(MyTime t) 
        {
            Console.Write("How many seconds do you want to add: ");
            
            int  s = Convert.ToInt32(Console.ReadLine());
            int totalSeconds = TimeSinceMidnight(t) + s;
            
            if (totalSeconds < 0)
            {
                while (totalSeconds < 0)
                {
                    totalSeconds += 86400;
                }
            }
            
            return TimeSinceMidnight(totalSeconds);
        }
        
        public static int Difference(MyTime mt1, MyTime mt2) 
        {
            int totalFirst = TimeSinceMidnight(mt1);
            int totalSecond = TimeSinceMidnight(mt2);
            
            int diff = Math.Abs(totalFirst - totalSecond);
            
            if (diff > 43200) diff = 86400 - diff;

            return diff;
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Enter the time separated by spaces: ");

            string time = Console.ReadLine();
            string[] values = time.Split(' ');
            
            int hour = int.Parse(values[0]);
            int minute = int.Parse(values[1]);
            int second = int.Parse(values[2]);
            
            try
            {
                MyTime t = new MyTime(hour, minute, second);
                
                Console.WriteLine($"Time: {t.ToString()}"); 
                Console.WriteLine($"Seconds since midnight: {TimeSinceMidnight(t)}");
                Console.WriteLine($"Time from seconds: {TimeSinceMidnight(hour * 3600 + minute * 60 + second)}");
                Console.WriteLine($"Add one second: {AddOneSecond(t)}");
                Console.WriteLine($"Add one minute: {AddOneMinute(t)}");
                Console.WriteLine($"Add one hour: {AddOneHour(t)}");
                Console.WriteLine($"Difference between 12:00 and {t.ToString()} is {Difference(new MyTime(12, 0, 0), t)} seconds");
                Console.WriteLine($"Add 10 seconds: {AddSeconds(t)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}