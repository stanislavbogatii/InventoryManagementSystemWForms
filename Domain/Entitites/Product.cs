﻿namespace Domain.Entitites
{
    public class Product
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        
        public string? Code { get; set; }

        public string? Article { get; set; }

        public int Quantity { get; set; } = 0;

        public int Price { get; set; } = 0;

        public int OldPrice { get; set; } = 0;

        public string Description { get; set; } = string.Empty;

        public int? CategoryId { get; set; } = null; 

        public Category Category { get; set; } = null!;
        public int? WarehouseId { get; set; } = null;
        public Warehouse? Warehouse { get; set; } = null;


        public ProductMemento SaveToMemento()
        {
            return new ProductMemento(this);
        }

        public void RestoreFromMemento(ProductMemento memento)
        {
            if (memento == null) return;

            Title = memento.Title;
            Code = memento.Code;
            Article = memento.Article;
            Description = memento.Description;
            Quantity = memento.Quantity;
            Price = memento.Price;
            OldPrice = memento.OldPrice;
            CategoryId = memento.CategoryId;
            WarehouseId = memento.WarehouseId;
        }
    }
}
