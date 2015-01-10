using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateHacks
{
    class Program
    {
        static void Main(string[] args)
        {
            // convert DateTime to UTC with and without offset
            DateTime dtNow = DateTime.Now;
            DateTime uTCNow = dtNow.ToUniversalTime();

            // get HI time from current time (HI is three hours behind PST)
            DateTime hITime = dtNow.AddHours(-3);
            //DateTime hITime = uTCNow.AddHours(4);
            
            Console.WriteLine("Current DateTime: " + dtNow);
            Console.WriteLine("Current DateTime (UTC): " + uTCNow);
            Console.WriteLine("Calculated DateTime in Hawaii: " + hITime);
            Console.WriteLine("Calculated DateTime (UTC) in Hawaii: " + hITime.ToUniversalTime());
            //DateTimeOffset.Equals(DateTimeOffset.Now, 
            //    );
            Console.ReadLine();

            // DateTimeOffset dtoffset = DateTimeOffset.Now;

            // convert HI UTC time to Redmond time 
            // Apply time difference (3 hrs)
            DateTime redmondTime = hITime.AddHours(-3);
            // 2. Back out the additional IST offset that was originally applied
            //redmondTime = redmondTime.AddHours(-5.5);
            DateTime redmondTimeUTC = redmondTime.ToUniversalTime();

            Console.WriteLine("Calculated DateTime in Hawaii: " + hITime);
            Console.WriteLine("Redmond DateTime derived from Hawaii: " + redmondTime);
            Console.WriteLine("Derived Redmond UTC DateTime: " + redmondTimeUTC);
            Console.WriteLine("Actual Redmond Time: " + dtNow);
            Console.WriteLine("Actual Redmond Time (UTC): " + uTCNow);
            Console.ReadLine();
 
            DateTime dt = new DateTime(2013, 10, 09, 15, 4, 0);
            foreach (var tzi in TimeZoneInfo.GetSystemTimeZones())
            {
                Console.WriteLine(string.Format("Time in {0} is {1}", tzi.DisplayName, TimeZoneInfo.ConvertTimeFromUtc(dt, tzi)));
            }
            Console.ReadLine();
            
            // convert DateTime to DateTimeOffset
            // DateTime d1 = DateTime.Now;
           //DateTime d1 = Convert.ToDateTime("2013-10-10 09:00:00.6433306");
            DateTime d1 = Convert.ToDateTime("2013-10-10 09:00:00.6433306");
            // DateTime s1 = Convert.ToDateTime("2013-06-24T23:52:41Z");
            
            DateTimeOffset o1 = new DateTimeOffset(d1);
            // DateTimeOffset of1 = new DateTimeOffset(d1, new TimeSpan(5, 30, 0));
            Console.WriteLine("\nDateTime: " + d1);
            Console.WriteLine("\nDateTimeOffset: " + o1);
            Console.ReadLine();

            DateTime dateTime1 = d1;
            //DateTime dateTime2 = DateTime.UtcNow;
            DateTime dateTime2 = d1.ToUniversalTime();
            
            //Console.WriteLine("\nCurrent DateTime: " + DateTime.Now);
            Console.WriteLine("\nDateTime: " + d1);
            //Console.WriteLine("DateTime.UtcNow Conversion: " + dateTime2);
            Console.WriteLine("DateTime.Utc Conversion: " + dateTime2);
            Console.WriteLine("DateTimeOffset Conversion from DateTime.Now: " + o1);
                        
            Console.WriteLine("\nDate differences: DateTime - UTC\n {0} - {1} =", dateTime1, dateTime2);
            Console.WriteLine(dateTime1 - dateTime2);

            Console.WriteLine();

            DateTimeOffset offset1 = DateTimeOffset.Now;
            DateTimeOffset offset2 = DateTimeOffset.UtcNow;
            Console.WriteLine("\nDate differences: DateTimeOffset.Now - DateTimeOffset.UtcNow\n {0} - {1} =", offset1, offset2);
            Console.WriteLine(offset1 - offset2);
            
            Console.WriteLine();

            DateTimeOffset ao1 = new DateTimeOffset(2008, 8, 22, 12, 0, 0, new TimeSpan(-5, 0, 0));
            DateTimeOffset ao2 = new DateTimeOffset(2008, 8, 22, 9, 0, 0, new TimeSpan(-8, 0, 0));
            Console.WriteLine("Are 12 PM EST and 9AM PST equal?\nDateTimeOffset1 = " + ao1 + "\nDateTimeOffset2 = " + ao2);
            Console.WriteLine(ao1 == ao2);
             
            Console.ReadLine();
        }
    }
}
