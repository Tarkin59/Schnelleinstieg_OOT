namespace SharedModel
{
    public class Product
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

        public class Order
        {
            public Guid OrderId { get; init; }
            public string ProductName { get; init; }
            public decimal Price { get; init; }
            public DateTime CreatedAt { get; init; }

            public Order(Guid orderId, string productName, decimal price, DateTime createdAt)
            {
                OrderId = orderId;
                ProductName = productName;
                Price = price;
                CreatedAt = createdAt;
            }
        }

    }
