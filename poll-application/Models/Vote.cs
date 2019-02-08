using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace poll_application.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string IpAdress { get; set; }

        public int PollId { get; set; }
        public Poll Poll { get; set; }
    }
}