using System.Collections.Generic;
using System.Text;

// Order class represents a purchase made by a customer
public class Order
{
    // Encapsulation: private fields
    private List<Product> _products;
    private Customer _customer;

    // Constructor initializes the order with a customer
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate the total cost of the order, including shipping
    public double GetTotalCost()
    {
        double total = 0;

        // Sum the cost of all products
        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // Add shipping cost depending on the country
        if (_customer.IsInUSA())
            total += 5;  // Domestic shipping
        else
            total += 35; // International shipping

        return total;
    }

    // Method to generate the packing label
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} (ID: {p.GetProductId()})");
        }
        return sb.ToString();
    }

    // Method to generate the shipping label
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }
}
