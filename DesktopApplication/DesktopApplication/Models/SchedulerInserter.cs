using System;
using System.Collections.Generic;
using System.Text;
using Desktop_Application.Models;
using Syncfusion.UI.Xaml.Scheduler;
using Desktop_Application.ViewModels;
namespace DesktopApplication.Models
{
    public interface ISchedulerInserter
    {
        public void InsertItem(string subject, DateTime start, DateTime end, ScheduleAppointmentCollection col);
    }
    public class SchedulerInserter : ISchedulerInserter
    {
      
        public void InsertItem(string subject, DateTime start, DateTime end, ScheduleAppointmentCollection col)
        {
            ScheduleAppointment appointment1 = new ScheduleAppointment();
            appointment1.StartTime = start;
            appointment1.EndTime = end;
            appointment1.Subject = subject;
            col.Add(appointment1);
        }
    }

    public class Schedular
    {
        private List<DateTime> CreateListOfLecturesDateForCourse(ScheduleAppointmentCollection col, Course course, Student s1)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (ScheduleAppointment varAppointment in col)
            {
                var AppointmentName = varAppointment.Subject;

                if (varAppointment.Subject.Length > 5)
                {
                    AppointmentName = varAppointment.Subject.Remove(5);
                }


                if (course.Name == AppointmentName)
                {
                    dates.Add(varAppointment.StartTime);
                } 
            }

            return dates;
        }
        
        private bool checkIfCourseExistInStudent(Student s1, String name)
        {
            foreach(string varcourse in s1.Courses)
            {
                if (varcourse == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void insertPrep(ScheduleAppointmentCollection col, Course course, Student s1)
        {
            SchedulerInserter sI = new SchedulerInserter();
            var datelist = CreateListOfLecturesDateForCourse(col, course, s1);


            for (int i = 0; i < course.Lectures.Count; i++)
            {

                    var TimeStart = datelist[i].AddDays(-1);
                    DateTime dateStart = new DateTime(TimeStart.Year, TimeStart.Month, TimeStart.Day, 16, 0, 0);
                    DateTime dateEnd = dateStart.AddHours(2);

                    string subject = "";
                    foreach (string varPrepitem in course.Lectures[i].PreparationItems)
                    {
                        subject += $"{varPrepitem}\n";

                    }
                    sI.InsertItem(subject, dateStart, dateEnd, col);

                //if there a to few dates on the calendar in comparison with the lectures in the couse object
                    if (datelist.Count < course.Lectures.Count)
                        {
                            i = course.Lectures.Count;
                        }
            }
        }

    }
}
