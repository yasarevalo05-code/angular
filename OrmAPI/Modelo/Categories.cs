﻿using System.ComponentModel.DataAnnotations;

namespace OrmAPI.Modelo
{
    public class Categories
    {
          
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    
    }
}
