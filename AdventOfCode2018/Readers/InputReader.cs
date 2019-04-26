namespace AdventOfCode2018.Readers
{
    using System.IO;

    public class InputReader : IInputReader
    {
        private const string _sameInputsPath = "..//..//..//..//Inputs//{0}.txt";
        private const string _otherInputsPath = "..//..//..//..//Inputs//{0}_{1}.txt";

        public string GetInput(int day)
        {
            var filePath = string.Format(_sameInputsPath, day);
            var input = GetInputFromFile(filePath);
            return input;
        }

        public string GetInput(int day, int task)
        {
            var filePath = string.Format(_otherInputsPath, day, task);
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

    public class SecondReader : IInputReader
    {
        public string GetInput(int day)
        {
            throw new System.NotImplementedException();
        }

        public string GetInput(int day, int task)
        {
            throw new System.NotImplementedException();
        }
    }
}
