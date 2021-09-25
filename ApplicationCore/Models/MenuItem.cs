using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name="Menu Item")]
        public string Name { get; set; }
        [Range (1, int.MaxValue, ErrorMessage ="Price should be greater than $1")]
        public float Price { get; set; }
        public int CategoryID { get; set; }
        public int FoodTypeID { get; set; }

        //Connect objects or tables
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("FoodTypeId")]
        public virtual FoodType FoodType { get; set; }
    }
}
