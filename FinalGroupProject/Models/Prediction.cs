using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalGroupProject.Models
{
    public class Prediction
    {
        public string Time { get; set; }
        public string Route { get; set; }

        public Prediction( )
        {
            Time = "";
            Route = "";
        }
    }
}