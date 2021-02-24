using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAcademmy{
    [Table("courses")]
    public class Course{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Decimal price { get; set; }
        public int timeCourse { get; set; }
        public string UrlImage { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Owner Owner { get; set; }  
        public ICollection<Signature> Signatures { get; set; }
    }
}