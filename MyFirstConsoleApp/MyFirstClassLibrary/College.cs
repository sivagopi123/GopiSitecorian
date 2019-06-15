using System;

namespace MyFirstClassLibrary
{
    public abstract class College
    {
        public abstract void Attendance();

        public void LabAttendance()
        {
            Console.WriteLine("This is lab attendance");
        }
    }
}
