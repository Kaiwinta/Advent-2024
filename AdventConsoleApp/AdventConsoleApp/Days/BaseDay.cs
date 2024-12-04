using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventConsoleApp.Days
{
    public class BaseDay
    {
        private string _Data = string.Empty;
        public string Data
        {
            get { return _Data; }
            set { _Data = value ?? string.Empty; }
        } 

        protected virtual int Part1()
        {
            return 0;
        }

        protected virtual int Part2()
        {
            return 0;
        }

        public void ExecuteTodaysProgram()
        {
            int valuePart1 = this.Part1();
            int valuePart2 = this.Part2();

            Console.WriteLine($"Part1 returned : {valuePart1}");
            Console.WriteLine($"Part2 returned : {valuePart2}");
        }
    }
}
