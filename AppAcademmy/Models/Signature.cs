using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAcademmy{
    [Table("signatures")]
    public class Signature{
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsActive { get; set; }
        public Client Client { get; set; }
        public ICollection<Course> courses{get; set;}
    }

}