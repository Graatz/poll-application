using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace poll_application.Models
{
    public class PollOption
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int PollId { get; set; }
        public Poll Poll { get; set; }

        public int Votes { get; set; }
    }
}