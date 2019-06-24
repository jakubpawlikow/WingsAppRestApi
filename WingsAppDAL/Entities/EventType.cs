using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace WingsAppDAL.Entities
{
    public class EventType
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public List<UserEvent> Events { get; set; }
    }
}
