namespace AdventOfCode.Common.Readers
{
    using System.IO;

    public class InputReader : IInputReader
    {
        private const string _sameInputsPath = "..//..//..//..//AdventOfCode{0}//Inputs//{1}.txt";
        private const string _otherInputsPath = "..//..//..//..//AdventOfCode{0}//Inputs//{1}_{2}.txt";

        public string GetInput(int year, int day)
        {
            var filePath = string.Format(_sameInputsPath, year, day);
            var input = GetInputFromFile(filePath);
            return input;
        }

        public string GetInput(int year, int day, int task)
        {
            var filePath = string.Format(_otherInputsPath, year, day, task);
            var input = GetInputFromFile(filePath);
            return input;
        }

        private string GetInputFromFile(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var data = streamReader.ReadToEnd();
                    return data;
                }
            }
        }
    }
}
