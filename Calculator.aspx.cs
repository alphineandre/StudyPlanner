using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ST10097490_POE
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int Credit, ClassHoursPerWeek, Weeks, result;

            Credit = int.Parse(txtNumber1.Text);
            ClassHoursPerWeek = int.Parse(txtNumber2.Text);
            Weeks = int.Parse(txtNumber3.Text);


            result = ((Credit * 10) / Weeks) - ClassHoursPerWeek;

            StudyHours.Text = "Studyhours are: " + result.ToString();

        }
    }
}