﻿namespace EstanteVirtual.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
    }
}
