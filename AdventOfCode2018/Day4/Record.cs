namespace AdventOfCode2018.Day4
{
    using System;

    public class Record
    {
        public Record(DateTime timestamp, string information)
        {
            Timestamp = timestamp;
            Information = information;
        }

        public DateTime Timestamp { get; set; }
        public string Information { get; set; }
    }
}
