using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAcademmy{
    [Table("owners")]
    public class Owner{
        public int ClientId { get; set; }
        public int CourseId{get; set;}
        public Client Client { get; set; }
        public ICollection<Course> courses{get; set;}
    }

}