using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalGroupProject.Models;
using System.Xml;
using System.Collections;
using System.Data;

namespace FinalGroupProject
{
    public partial class MyNextBus : System.Web.UI.Page
    {
        private String stopTitle = "";
        private List<Prediction> predictions = new List<Prediction>();
        private String URLString = "http://retro.umoiq.com/service/publicXMLFeed?command=predictions&a=ttc&stopId=";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    lblTest.Text = "Welcome, " + Context.User.Identity.GetUserName() + "!";

                    StopList.DataSource = GetDataSource();
                    StopList.DataTextField = "TextField";
                    StopList.DataValueField = "ValueField";
                                       
                    StopList.DataBind();
                    StopList.SelectedIndex = 0;
                }
                else
                {
                    lblTest.Text = "Please login to see your saved stop IDs!";
                    btnDelete.Visible = false;
                    btnCheckBus.Visible = false;

                }
            }

        }

        protected ICollection GetDataSource()
        {

            // Create a data table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

             String userID = Context.User.Identity.GetUserId();
            
            using (NextBusEntities context = new NextBusEntities())
            {
                IQueryable<UserRecord> query = context.UserRecords.Where(r => r.UserID == userID);
                foreach (UserRecord r in query)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "StopID: " + r.StopID.ToString();
                    dr[1] = r.Id.ToString();
                    dt.Rows.Add(dr);
                }
                    
            }
            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            DataView dv = new DataView(dt);
            return dv;

        }
               

        protected void btnDelete_Clicked(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(StopList.SelectedItem.Value);
            using (NextBusEntities context = new NextBusEntities())
            {
                UserRecord recordToDelete = context.UserRecords.Find(id);
                if (recordToDelete!= null)
                {
                    context.UserRecords.Remove(recordToDelete);
                    context.SaveChanges();
                }
            }

            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void btnCheckBus_Clicked(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblStopTitle.Text = "";
            stopTitle = "";
            // remove "StopID: " from dropdownlist displayed text
            URLString = URLString + StopList.SelectedItem.Text.Substring(8); 
            XmlTextReader reader = new XmlTextReader(URLString);
            while (reader.Read())
            {
                if (reader.Name.Equals("predictions") && stopTitle.Equals(""))
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
                foreach (Prediction p in predictions)
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