using System;
using System.Collections;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public abstract class Student
{
    private string name;

    protected ArrayList courses;

    //CONSTRUCTOR
    protected Student(string name)
    {
        this.name = name;
        courses = new ArrayList();
    }

    //student Name
    public string Name
    {
        get { return name; }
    }

    //total weekly hours
    public int totalWeeklyHours()
    {
        int totalHours = 0;
        foreach (Course course in courses)
        {
            totalHours += course.WeeklyHours;
        }
        return totalHours;
    }

    //total fee payable
    public virtual double feePayable()
    {
        double totalFee = 0.0;
        foreach (Course course in courses)
        {
            totalFee += course.Fee;
        }
        return totalFee;
    }

    public abstract void addCourse(Course course);//extend this abstract class


    public ArrayList getEnrolledCourses()
    {
        return courses;
    }
}