using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWeek[] weeks = new WorkWeek[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                weeks[i] = new WorkWeek(rnd);
            }
            int totalBuyers = 0;
            int totalCash = 0;
            int totalCard = 0;
            string cashWeeks = String.Empty;
            int[] cash = new int[10];
            for (int i = 0; i < 10; i++)
            {
                int weekCash = 0;
                int weekCard = 0;
                for (int j = 0; j < weeks[i].workDays.Length; j++)
                {
                    totalBuyers += weeks[i].workDays[j].card + weeks[i].workDays[j].cash;
                    weekCash += weeks[i].workDays[j].cash;
                    weekCard += weeks[i].workDays[j].card;
                }
                totalCash += weekCash;
                totalCard += weekCard;
                if (weekCash > weekCard)
                {
                    cashWeeks += ", " + (i + 1);
                }
            }
            Console.WriteLine("Общее кол-во покупателей {0}", totalBuyers);
            Console.WriteLine("Покупатели с наличкой {0}", totalCash);
            Console.WriteLine("Покупатели с картами {0}", totalCard);
            if (!cashWeeks.Equals(String.Empty))
            {
                Console.WriteLine("Недели где налички было больше " + cashWeeks.Substring(2));
            }
            else
            {
                Console.WriteLine("Картой всегда платили чаще");
            }
        }

        public class Day
        {
            public int cash, card;

            public Day(Random rnd)
            {
                this.cash = rnd.Next(0, 101);
                this.card = rnd.Next(0, 101);
            }
        }

        public class WorkWeek
        {
            public Day[] workDays;

            public WorkWeek(Random rnd)
            {
                workDays = new Day[rnd.Next(4, 8)];
                for (int i = 0; i < workDays.Length; i++)
                {
                    workDays[i] = new Day(rnd);
                }
            }
        }

    }
}
