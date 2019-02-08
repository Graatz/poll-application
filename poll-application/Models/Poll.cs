using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace poll_application.Models
{
    public class Poll
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime? Date { get; set; }

        public int Votes { get; set; }

        public bool MultiVote { get; set; }

        public bool Private { get; set; }
    }
}