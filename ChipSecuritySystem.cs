using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class ChipSecuritySystem
    {
        public List<ColorChip> Chips { get; private set; }

        public ChipSecuritySystem(List<ColorChip> chips)
        {
            Chips = chips;
        }

        public List<ColorChip> FindValidSequence()
        {
            foreach (var chip in Chips)
            {
                if (chip.StartColor == Color.Blue || chip.EndColor == Color.Blue)
                {
                    var orientedChip = OrientChip(chip, Color.Blue);
                    var sequence = BuildSequence(new List<ColorChip> { orientedChip }, RemoveChip(Chips, chip));
                    if (sequence != null)
                    {
                        return sequence;
                    }
                }
            }
            return null;
        }

        private List<ColorChip> BuildSequence(List<ColorChip> currentSequence, List<ColorChip> remainingChips)
        {
            var lastColor = currentSequence[currentSequence.Count - 1].EndColor;

            if (lastColor == Color.Green)
            {
                return currentSequence;
            }

            foreach (var chip in remainingChips)
            {
                if (chip.StartColor == lastColor || chip.EndColor == lastColor)
                {
                    var orientedChip = OrientChip(chip, lastColor);
                    var newSequence = new List<ColorChip>(currentSequence) { orientedChip };
                    var result = BuildSequence(newSequence, RemoveChip(remainingChips, chip));
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        private ColorChip OrientChip(ColorChip chip, Color startColor)
        {
            return chip.StartColor == startColor ? chip : new ColorChip(chip.EndColor, chip.StartColor);
        }

        private List<ColorChip> RemoveChip(List<ColorChip> chips, ColorChip chip)
        {
            var newList = new List<ColorChip>();
            foreach (var c in chips)
            {
                if (c != chip)
                {
                    newList.Add(c);
                }
            }
            return newList;
        }
    }
}
