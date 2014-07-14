using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            var name = Console.ReadLine();
            //var greeter = new Greeter(new TimeService());
            var greeter = new GreeterV2(new TimeService().GetCurrentTime);
            Console.WriteLine(greeter.Greet(name));
            Console.ReadLine();
        }


    }

    //public delegate DateTime CurrentTimeDeletegate();
    public class GreeterV2
    {
        Func<DateTime> _currentTime;
        public GreeterV2(Func<DateTime> currentTime) {
            _currentTime = currentTime;
        }

        public string Greet(string name)
        {
            var currentHour = _currentTime().Hour;
            if (currentHour < 12)
            {
                return string.Format("Hello {0}, Have a nice day!", name);
            }
            else
            {
                return string.Format("Hello {0}, Good Evening!!", name);
            }
        }
    }

    public class Greeter
    {
        ITimeService _timeService;
        public Greeter(ITimeService timeService)
        {
            _timeService = timeService;
        }
        
        public string Greet(string name) {
            var currentHour = _timeService.GetCurrentTime().Hour;
            if (currentHour < 12)
            {
                return string.Format("Hello {0}, Have a nice day!", name);
            }
            else
            {
                return string.Format("Hello {0}, Good Evening!!", name);
            }
        }
    }

    public interface ITimeService
    {
        DateTime GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
