using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using poll_application.Models;

namespace poll_application.ViewModels
{
    public class PollSearchViewModel
    {
        public string Phrase { get; set; }
        public List<Poll> Polls { get; set; }
    }
}