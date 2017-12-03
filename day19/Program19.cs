using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day19
{
    public class Program19
    {
        public static void Main(string[] args)
        {
            string source = File.ReadAllText(@"..\..\input.txt");
            source = source.Remove(source.Length - 1);
            var sourceLines = source.Split('\n').ToList();
            var medicineMolecule = sourceLines.Last();
            sourceLines.RemoveAt(sourceLines.Count - 1);
            sourceLines.RemoveAt(sourceLines.Count - 1);
            var replacementMolecules = sourceLines.Select(c => c.Split(new string[] { " => " }, StringSplitOptions.None)).ToList();

            List<string> createdMedicineMolecules = GenerateMedicineMutations(medicineMolecule, replacementMolecules);

            var partOne = createdMedicineMolecules.Count;

        }

        private static List<string> GenerateMedicineMutations(string medicineMolecule, List<string[]> replacementMolecules)
        {
            List<string> createdMedicineMolecules = new List<string>();

            foreach (string[] molecule in replacementMolecules)
            {
                var indexesOfSubMolecule = medicineMolecule.GetAllIndexes(molecule[0]);

                foreach (var index in indexesOfSubMolecule)
                {
                    var newMolecule = medicineMolecule.Remove(index, molecule[0].Length);
                    newMolecule = newMolecule.Insert(index, molecule[1]);
                    createdMedicineMolecules.Add(newMolecule);
                }
            }

            return createdMedicineMolecules.Distinct().ToList();
        }
    }

    public static class Extensions
    {
        public static IEnumerable<int> GetAllIndexes(this string source, string matchString)
        {
            matchString = Regex.Escape(matchString);
            foreach (Match match in Regex.Matches(source, matchString))
            {
                yield return match.Index;
            }
        }
    }

}
