using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Razor_Form_Submit.Models
{
    public class WeatherModel
    {
        [BindProperty]
        public string SearchKey { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public string Condition { get; set; } = string.Empty;

        public string ConditionIcon { get; set; } = string.Empty;

        public int Rain { get; set; }

        public string Location { get; set; } = string.Empty;

        public bool Error { get; set; }
    }
}
