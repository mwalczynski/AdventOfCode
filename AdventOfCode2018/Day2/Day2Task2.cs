namespace AdventOfCode2018.Day2
{
    using System.Linq;
    using System.Text;
    using Day;
    using Readers;

    public class Day2Task2 : BaseDay
    {
        public Day2Task2(IInputReader reader) : base(reader)
        {
        }

        public override string GetResult()
        {
            var input = GetInput();
            var data = input
                .ToArray();

            var length = data.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var (differByOneCharacter, differentCharacterIndex) = DifferByOnlyOneCharacter(data[i], data[j]);
                    if (differByOneCharacter)
                    {
                        var result = data[i].Remove(differentCharacterIndex.Value, 1);
                        return result;
                    }
                }
            }

            return "Something went wrong";
        }

        public (bool, int?) DifferByOnlyOneCharacter(string first, string second)
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
