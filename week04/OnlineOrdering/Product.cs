// Product class represents an item that a customer can order
public class Product
{
    // Encapsulation: private member variables
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor initializes the product
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Encapsulation: Public getters provide controlled access to private fields
    public string GetName() => _name;
    public string GetProductId() => _productId;
    public double GetPrice() => _price;
    public int GetQuantity() => _quantity;

    // Method that calculates the total cost of this product
    public double GetTotalCost()
    {
        return _price * _quantity;
    }
}
