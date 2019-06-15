namespace MyFirstClassLibrary
{
    public class Major : Student
    {
        public enum MajorSubject
        {
            English,
            Tamil,
            Kannada,
            Hindi
        }

        public int SubjectId { get; set; }

        public int SubjectMark { get; set; }

        public new int TotalMark()
        {
            return 2;
        }
    }
}
