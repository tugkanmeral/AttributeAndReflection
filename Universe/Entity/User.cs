using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Universe.CustomAttribute;

namespace Universe.Entity
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Secret]
        public string TCKN { get; set; }
    }
}
