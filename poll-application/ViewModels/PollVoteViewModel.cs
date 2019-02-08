using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using poll_application.Models;
using System.Web.Mvc;

namespace poll_application.ViewModels
{
    public class PollVoteViewModel
    {
        public IEnumerable<PollOption> PollOptions { get; set; }
        public Poll Poll { get; set; }
    }
}