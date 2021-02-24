using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAcademmy{
    [Table("clients")]
    public class Client{
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public int password { get; set; }
        public bool isActive {get; set;}
        public DateTime createAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<Signature> signatures{get; set;} = new List<Signature>();
        public Owner Owner {get; set;}

    }
}