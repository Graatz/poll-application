﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using poll_application.Models;

namespace poll_application.ViewModels
{
    public class PollBrowseViewModel
    {
        public List<Poll> LatestPolls { get; set; }
        public List<Poll> PopularPolls { get; set; }
    }
}