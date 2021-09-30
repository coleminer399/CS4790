using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public float Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public int FoodTypeID { get; set; }

        //Connect objects or tables
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        [ForeignKey("FoodTypeID")]
        public virtual FoodType FoodType { get; set; }
    }
}
