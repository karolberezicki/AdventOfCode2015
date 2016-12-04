using System.Collections.Generic;
using System.Linq;

namespace day09
{

    public static class Permutations
    {
        public static List<List<T>> GeneratePermutations<T>(List<T> items)
        {
            T[] current_permutation = new T[items.Count];
            bool[] in_selection = new bool[items.Count];
            List<List<T>> results = new List<List<T>>();
            PermuteItems(items, in_selection, current_permutation, results, 0);
            return results;
        }

        private static void PermuteItems<T>(List<T> items, bool[] in_selection,
            T[] current_permutation, List<List<T>> results,
            int next_position)
        {

            if (next_position == items.Count)
            {
                results.Add(current_permutation.ToList());
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (!in_selection[i])
                    {
                        in_selection[i] = true;
                        current_permutation[next_position] = items[i];
                        PermuteItems(items, in_selection, current_permutation, results, next_position + 1);
                        in_selection[i] = false;
                    }
                }
            }
        }
    }

}
