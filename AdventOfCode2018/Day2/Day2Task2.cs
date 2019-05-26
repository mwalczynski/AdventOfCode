namespace AdventOfCode2018.Day2
{
    using AdventOfCode.Common;

    public class Day2Task2 : BaseDay
    {
        public override string GetResult(string[] input)
        {
            var length = input.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var (differByOneCharacter, differentCharacterIndex) = DifferByOnlyOneCharacter(input[i], input[j]);
                    if (differByOneCharacter)
                    {
                        var result = input[i].Remove(differentCharacterIndex.Value, 1);
                        return result;
                    }
                }
            }

            return "Something went wrong";
        }

        private (bool, int?) DifferByOnlyOneCharacter(string first, string second)
        {
            int? differentCharacterIndex = null;

            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] == second[i]) continue;

                if (differentCharacterIndex.HasValue)
                {
                    return (false, null);
                }
                else
                {
                    differentCharacterIndex = i;
                }
            }

            return (true, differentCharacterIndex);
        }
    }
}
