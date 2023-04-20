﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QenaDtos.Category
{
    public class CategoryMinimalDto
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(200)]
        public string? Name { get; set; }
        
    }
}
