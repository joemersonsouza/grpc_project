using System;

namespace Core
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public Product(string name, string description, double price)
        {
            Id = Guid.NewGuid();
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(Name)) : name;
            Description = description;
            Price = price < 0.01 ? throw new ArgumentNullException(nameof(Price)) : price;
        }
    }
}
