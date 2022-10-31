using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalGroupProject.Models;
using System.Xml;

namespace FinalGroupProject
{
    public partial class NextBus : System.Web.UI.Page
    {
        private String userID = "unlogged";
        private String stopTitle = "";
        private List<Prediction> predictions = new List<Prediction>();
        private String URLString = "http://retro.umoiq.com/service/publicXMLFeed?command=predictions&a=ttc&stopId=";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                txtStopID.Text = "246"; //set a default value to test
                if (User.Identity.IsAuthenticated)
                {
                    lblTest.Text = "Welcome, " + Context.User.Identity.GetUserName() + "!";
                    userID = Context.User.Identity.GetUserId();

                    btnSave.Visible = true;
                    
                }
                else
                {
                    lblTest.Text = "Welcome, Guest!";

                }               
            }

        }

        protected void btnSave_Clicked(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                userID = Context.User.Identity.GetUserId();
            }
            using (NextBusEntities context = new NextBusEntities())
            {
                UserRecord userRecord = new UserRecord
                {
                    UserID = userID,
                    StopID = Convert.ToInt32(txtStopID.Text)
                };
                context.UserRecords.Add(userRecord);
                context.SaveChanges();

            }
        }

        protected void btnCheckBus_Clicked(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblStopTitle.Text = "";
            stopTitle = "";
            URLString = URLString + txtStopID.Text;
            XmlTextReader reader = new XmlTextReader(URLString);
            while (reader.Read())
            {
                if (reader.Name.Equals("predictions") && stopTitle.Equals("") )
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name.Equals("stopTitle")) stopTitle = reader.Value;
                    }
                }
                if (reader.Name.Equals("prediction"))
                {
                    Prediction p = new Prediction();
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name.Equals("minutes")) p.Time = reader.Value;
                        if (reader.Name.Equals("branch")) p.Route = reader.Value;
                    }
                    predictions.Add(p);
                }
            }

            lblStopTitle.Text = "Stop Title: " + stopTitle;
            if (predictions.Count == 0) lblError.Text = "No predictions received!";
            else
            {
                foreach(Prediction p in predictions)
                {
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = p.Time;
                    row.Cells.Add(cell1);
                    TableCell cell2 = new TableCell();
                    cell2.Text = p.Route;
                    row.Cells.Add(cell2);
                    BusTable.Rows.Add(row);

                }
            }


        }
    }
}