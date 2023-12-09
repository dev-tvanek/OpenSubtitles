using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenSubtitles
{
    public class SubtitleBlockValidator : ISubtitleBlockValidator
    {
        public bool IsValidTimeFormat(SubtitleBlock block)
        {
            // Kontrola, že StartTime a EndTime nejsou nulové a StartTime je menší než EndTime
            if (block.StartTime == null || block.EndTime == null || block.StartTime >= block.EndTime)
            {
                return false;
            }

            // Kontrola, že časy nejsou v minulosti
            return block.StartTime.TotalMilliseconds >= 0 && block.EndTime.TotalMilliseconds >= 0;
        }


        // Metoda pro kontrolu celistvosti bloku
        public bool IsComplete(SubtitleBlock block)
        {
            return block.Id >= 0 && IsValidTimeFormat(block) && block.Lines.Any() && block.Lines.All(line => IsValidLine(line));
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
            // Příklad: Kontrola, že řádek neobsahuje neplatné HTML tagy
            // a zároveň kontrola, že délka řádku není příliš dlouhá
            return !string.IsNullOrEmpty(line) && line.Length <= 100 && IsHtmlContentValid(line);
        }

        private bool IsHtmlContentValid(string line)
        {
            var htmlTagPattern = new Regex("<(/?[^>]+)>");
            var tags = new Stack<string>();

            foreach (Match match in htmlTagPattern.Matches(line))
            {
                string tag = match.Groups[1].Value;

                if (!tag.StartsWith("/"))
                {
                    // Je to otevírací tag, uložíme ho
                    tags.Push(tag);
                }
                else
                {
                    // Je to zavírací tag, ověříme, zda odpovídá poslednímu otevíracímu tagu
                    if (tags.Count == 0 || tags.Pop() != tag.Substring(1))
                    {
                        // Není správně uzavřený nebo neodpovídá poslednímu otevíracímu tagu
                        return false;
                    }
                }
            }

            // Všechny tagy by měly být správně uzavřeny
            return tags.Count == 0;
        }


        // Metoda pro kontrolu překryvů časů mezi titulky
        public bool HasTimeOverlaps(List<SubtitleBlock> subtitleBlocks)
        {
            var sortedBlocks = subtitleBlocks.OrderBy(block => block.StartTime).ToList();
            for (int i = 0; i < sortedBlocks.Count - 1; i++)
            {
                if (sortedBlocks[i].EndTime > sortedBlocks[i + 1].StartTime)
                {
                    return true; // Nalezen překryv
                }
            }
            return false;
        }


        // Pomocná metoda pro určení, zda se dva bloky časově překrývají
        private bool DoBlocksOverlap(SubtitleBlock block1, SubtitleBlock block2)
        {
            return block1.StartTime < block2.EndTime && block2.StartTime < block1.EndTime;
        }
    }



}
