using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;//needed for CultureInfo function

public partial class CourseRegistration : System.Web.UI.Page
{
    Student newStudent;
    public string studentName;
    public string studentType;
    public int studentTypeIndexNumber;

    protected void Page_Load(object sender, EventArgs e)
    {
        pnlRegistration.Visible = true;
        pnlResult.Visible = false;

        if (this.IsPostBack == false)//only when page loads
        {
            foreach (Course course in Helper.GetCourses())
            {
                checklist.Items.Add(course.ToString());
                //string checklistItem = course.Code + " " + course.Title + "  -  " + course.WeeklyHours.ToString() + (course.WeeklyHours == 1 ? " hour" : " hours") + " per week";
                //checklist.Items.Add(checklistItem);
            }
        }
    }

    protected void Submit_Page(object sender, EventArgs e)
    {
        //reset error label to blank
        LabelError.Text = "";

        try
        {
            //get student name
            studentName = new CultureInfo("en-US").TextInfo.ToTitleCase(Student_Name.Text);


            //get student type (FT, PT, Co-op)
            //int studentType = Student_Type.SelectedValue;
            studentType = Student_Type.SelectedValue;
            studentTypeIndexNumber = Student_Type.SelectedIndex;


            //create new student
            if (studentType == "Full Time")
            {
                newStudent = new FullTimeStudent(studentName);
            }
            else if (studentType == "Part Time")
            {
                newStudent = new PartTimeStudent(studentName);
            }
            else if (studentType == "Co-op")
            {
                newStudent = new CoopStudent(studentName);
            }

            //create list of all courses
            List<Course> allCourses = Helper.GetCourses();

            //total number of courses
            //int totalChecklistItems = checklist.Items.Count;
            int totalChecklistItems = allCourses.Count;

            //check which courses have been selected
            //foreach (ListItem listItem in checklist.Items)
            for (int i = 0; i < totalChecklistItems; i++)
            {
                //if (listItem.Selected == true)
                if (checklist.Items[i].Selected == true)
                {
                    //get index number of each selected course
                    //LabelError.Text = listItem.Value;
                    //LabelError.Text += checklist.Items[i] + "<br/>";
                    //LabelError.Text += "Index: " + i + " - " + allCourses[i].Title + "<br/>";//works

                    //add each selected course to specific student
                    newStudent.addCourse(allCourses[i]);
                }
            }

            //display Results Panel
            Display_Results_Panel();           

        }
        catch(Exception error)
        {
            LabelError.Text += error.Message;
        }
    }

    protected void Display_Results_Panel()
    {
        pnlRegistration.Visible = false;
        pnlResult.Visible = true;

        //display selections
        //LabelConfirmation.Text += studentName + " is a " + studentType + " Student. Selected Index Number:" + studentTypeIndexNumber + "<br/>";

        LabelConfirmation.Text = "<p>Thank you <span class=\"emphsis\">" + studentName + "</span>, for using our online registration system.<br/>";
        LabelConfirmation.Text += "You have been registered as a <span class=\"distinct\">" + studentType + "</span> for the following courses:</p>";

        LabelConfirmation.Text += "<table class=\"table\">";
        LabelConfirmation.Text += "<th>Course Code</th>";
        LabelConfirmation.Text += "<th>Course Title</th>";
        LabelConfirmation.Text += "<th>Weekly Hours</th>";
        LabelConfirmation.Text += "<th>Fee Payable</th>";

        foreach (Course course in newStudent.getEnrolledCourses())
        {
            //LabelConfirmation.Text += course.Code + " - " + course.Title + " (Weekly Hours: " + course.WeeklyHours + "): $" + course.Fee + "<br/>";

            LabelConfirmation.Text += "<tr>";
            LabelConfirmation.Text += "<td>" + course.Code + "</td>";
            LabelConfirmation.Text += "<td>" + course.Title + "</td>";
            LabelConfirmation.Text += "<td>" + course.WeeklyHours + "</td>";
            LabelConfirmation.Text += "<td>$" + course.Fee + "</td>";
            LabelConfirmation.Text += "</tr>";
        }

        LabelConfirmation.Text += "<tr>";
        LabelConfirmation.Text += "<td colspan=\"2\" align=\"right\">Total</td>";
        LabelConfirmation.Text += "<td>" + newStudent.totalWeeklyHours() + "</td>";
        LabelConfirmation.Text += "<td>$" + newStudent.feePayable() + "</td>";
        LabelConfirmation.Text += "</tr>";

        //total hours each week
        //LabelConfirmation.Text += "Total weekly hours: " + newStudent.totalWeeklyHours() + "<br/>";

        //total fee payable
        //LabelConfirmation.Text += "Total fee payable: $" + newStudent.feePayable() + "<br/>";

        LabelConfirmation.Text += "</table>";
    }
}