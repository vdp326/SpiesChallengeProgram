using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesProgram
{
     public partial class Default : System.Web.UI.Page
     {
          protected void Page_Load(object sender, EventArgs e)
          {
               if (!Page.IsPostBack)
               {
                    previousCalendar.SelectedDate = DateTime.Now.Date; //get current date
                    newCalendar.SelectedDate = DateTime.Now.Date.AddDays(14); //14 days from the current date
                    endCalendar.SelectedDate = DateTime.Now.Date.AddDays(21); //21 days from the current date
               }
          }

          protected void assignButton_Click(object sender, EventArgs e)
          {
              //spies cost $500 per day
              TimeSpan totalDurationsOfAssignments = endCalendar.SelectedDate.Subtract(newCalendar.SelectedDate);
              double totalCost = totalDurationsOfAssignments.TotalDays * 500;

              //if > 21 days then add $1000
              if (totalDurationsOfAssignments.TotalDays > 21)
              {
                   totalCost += 1000.0;
              }

              resultLabel.Text = String.Format("Assignment of {0} to assignment {1} is authorized. Budget total: {2:C}",
                   codeNameTextBox.Text, newAssignmentTextBox.Text, totalCost);


              TimeSpan timeBetweenAssignments = newCalendar.SelectedDate.Subtract(previousCalendar.SelectedDate);
              if (timeBetweenAssignments.TotalDays < 14)
              {
                   resultLabel.Text = "Error: Must allow at least two weeks between previous assignment and new assignment";

                   DateTime earliestNewAssignmentDate = previousCalendar.SelectedDate.AddDays(14);

                   newCalendar.SelectedDate = earliestNewAssignmentDate;
                   newCalendar.VisibleDate = earliestNewAssignmentDate;

              }
          }
     }
}