using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLib
{
    public class Armor{
        [Key]
        public string Name{get; set;}
        public double Defense{get; set;}
    }
}