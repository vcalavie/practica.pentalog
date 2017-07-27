using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RequestWorkflow.Models
{
    public class Event
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Details")]
        public string Details { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("Date and Time")]
        public string DateAndTime { get; set; }

        public string Image { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}