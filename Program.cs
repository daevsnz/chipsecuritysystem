using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ColorChip> chips = new List<ColorChip>
            {
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple)
            };

            var securitySystem = new ChipSecuritySystem(chips);
            List<ColorChip> sequence = securitySystem.FindValidSequence();
            
            if (sequence == null)
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
            else
            {
                Console.Write("Blue -> ");
                foreach (var chip in sequence)
                {
                    Console.Write($"[{chip.StartColor}, {chip.EndColor}] -> ");
                }
                Console.WriteLine("Green");
            }
            Console.ReadKey();
        }

    }
}
