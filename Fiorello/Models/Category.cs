﻿namespace Fiorello.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
