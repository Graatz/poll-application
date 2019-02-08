using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using poll_application.Models;

namespace poll_application.ViewModels
{
    public class PollFormViewModel
    {
        public List<PollOption> Options { get; set; }
        public Poll Poll { get; set; }
    }
}