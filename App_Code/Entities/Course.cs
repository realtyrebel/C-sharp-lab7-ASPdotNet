using System;
using System.Collections;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Course
/// </summary>
public class Course
{
    public string Code { get; set; }
    public string Title { get; set; }
    public int WeeklyHours { get; set; }
    public double Fee { get; set; }

    //total number of students that may be enrolled in this course
    public int MaxEnrollment { get; set; }

    private ArrayList students;//list of students in course

    public Course(string code, string title)
    {
        Code = code;
        Title = title;
        students = new ArrayList();//blank list of students in course
    }

    public void addStudent(Student student)
    {
        students.Add(student);//adds to ArrayList
    }

    public override string ToString()
    {
        return Code + " " + Title + "  -  " + WeeklyHours.ToString() + (WeeklyHours==1 ? " hour":" hours") + " per week";
    }
}