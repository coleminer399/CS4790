﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class FoodType
    {
        [Key]
        public int MyProperty { get; set; }
        [Display(Name="Food Type")]
        public string Name { get; set; }
    }
}
