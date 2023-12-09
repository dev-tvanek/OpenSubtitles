using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSubtitles
{
    public class SubtitleBlockValidator
    {
        public bool IsValidTimeFormat(SubtitleBlock block)
        {
            // Implementace kontroly času
            return block.StartTime < block.EndTime && block.StartTime.TotalMilliseconds >= 0 && block.EndTime.TotalMilliseconds >= 0;
        }

        // Metoda pro kontrolu celistvosti bloku
        public bool IsComplete(SubtitleBlock block)
        {
            // Implementace kontroly celistvosti
            return block.Id >= 0 && IsValidTimeFormat(block) && block.Lines.Any();
        }

        // Metoda pro kontrolu celkové správnosti bloku
        public bool IsValid(SubtitleBlock block)
        {
            // Implementace kontroly platnosti
            return IsComplete(block) && block.Lines.All(IsValidLine);
        }

        // Metoda pro kontrolu jednotlivých řádků titulků
        private bool IsValidLine(string line)
        {
            // Implementace kontroly řádků
            return !string.IsNullOrEmpty(line) && line.Length <= 100; // Příklad kontroly
        }

        // Metoda pro kontrolu překryvů časů mezi titulky
        public bool HasTimeOverlaps(List<SubtitleBlock> subtitleBlocks)
        {
            for (int i = 0; i < subtitleBlocks.Count - 1; i++)
            {
                var currentBlock = subtitleBlocks[i];
                for (int j = i + 1; j < subtitleBlocks.Count; j++)
                {
                    var nextBlock = subtitleBlocks[j];
                    if (DoBlocksOverlap(currentBlock, nextBlock))
                    {
                        return true; // Nalezen překryv
                    }
                }
            }
            return false; // Žádný překryv nebyl nalezen
        }

        // Pomocná metoda pro určení, zda se dva bloky časově překrývají
        private bool DoBlocksOverlap(SubtitleBlock block1, SubtitleBlock block2)
        {
            return block1.StartTime < block2.EndTime && block2.StartTime < block1.EndTime;
        }
    }
}
