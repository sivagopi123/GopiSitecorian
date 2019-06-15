namespace MyFirstClassLibrary
{
    public class Student : IStudent
    {

        public string Name { get; set; }
        public int Id { get; set; }

        public int MathMark { get; set; }
        public int EnglishMark { get; set; }

        public int TotalMark()
        {
            return MathMark + EnglishMark;
        }

        public int TotalMark(int ScienceMark)
        {
            return MathMark + EnglishMark + ScienceMark;
        }

        public int TotalMark(int ScienceMark, int SocialMark)
        {
            return MathMark + EnglishMark + ScienceMark + SocialMark;
        }

    }
}
