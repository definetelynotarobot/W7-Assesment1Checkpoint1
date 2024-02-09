using System;
using System.Collections.Generic;
using System.Linq;

namespace W7_Checkpoint_1_Assesment
{
    internal class Assesment7
    {

public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
    }

    public interface ICategory
    {
        int Id { get; }
        string Name { get; }
        List<IProduct> Products { get; }
        void AddProduct(IProduct product);
    }

    public interface ICompany
    {
        int Id { get; }
        string Name { get; }
        List<ICategory> Categories { get; }
    }

    public class Category : ICategory
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<IProduct> Products { get; private set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            Products.Add(product);
        }
    }


    public class Product : IProduct
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class Company : ICompany
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<ICategory> Categories { get; private set; }

        public Company(int id, string name)
        {
            Id = id;
            Name = name;
            Categories = new List<ICategory>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company(1, "Mehmet Store");

            Category electronicsCategory = new Category(1, "Electronics");
            electronicsCategory.AddProduct(new Product(101, "Smartphone", 799.99m));
            electronicsCategory.AddProduct(new Product(102, "PC", 1299.99m));

            Category clothingCategory = new Category(2, "Clothing");
            clothingCategory.AddProduct(new Product(201, "T-shirt", 19.99m));
            clothingCategory.AddProduct(new Product(202, "Jeans", 49.99m));

            company.Categories.Add(electronicsCategory);
            company.Categories.Add(clothingCategory);

                Console.WriteLine("Categories and Products:");
                Console.WriteLine("------------------------");
                Console.WriteLine("| Category    | Product ");
                Console.WriteLine("------------------------");
                foreach (var category in company.Categories)
                {
                    foreach (var product in category.Products)
                    {
                        Console.WriteLine($"| {category.Name,-12} | {product.Name}");
                    }
                }
                Console.WriteLine("------------------------");
            }
    }

}
}
