﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckNorrisClassLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Type { get; set; } = string.Empty;

        public List<ChuckNorrisFact> Facts { get; set; } = new();
    }
}
