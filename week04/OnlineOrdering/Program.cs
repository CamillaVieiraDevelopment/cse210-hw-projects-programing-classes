using System;

class Program
{
    static void Main(string[] args)
    {
       
        // Create addresses
        Address addr1 = new Address("5083 Star the sky St", "Florida", "CA", "USA");
        Address addr2 = new Address("456 Avenue Sampayo", "Minas Gerais", "MG", "Brazil");

        // Create customers with encapsulated address
        Customer cust1 = new Customer("Mia Sorella", addr1);
        Customer cust2 = new Customer("Pedro Souza", addr2);

        // Create first order for a US-based customer
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Dress", "P001", 50, 4));
        order1.AddProduct(new Product("T-shirt", "P002", 25, 6));

        // Create second order for an international customer
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Pants", "P003", 40, 2));
        order2.AddProduct(new Product("Shoes", "P004", 60, 3));
        order2.AddProduct(new Product("Sweater", "P005", 100, 1));

        // Display results for order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        // Display results for order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}\n");
    }
}
