namespace AdventOfCode2018.Day7
{
    public class Task
    {
        public char Id { get; set; }

        public readonly int CompletionTime;

        public int CompletedTime { get; set; }
        public int TimeToComplete => CompletionTime - CompletedTime;

        public Task(char id, int baseSecondToComplete)
        {
            Id = id;
            CompletionTime = baseSecondToComplete + id - 'A' + 1;
        }

        public bool IsCompleted()
        {
            return CompletedTime == CompletionTime;
        }

        protected bool Equals(Task other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Task)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
