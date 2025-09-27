// Customer class represents a client who places an order
public class Customer
{
    // Encapsulation: private fields
    private string _name;
    private Address _address;

    // Constructor initializes the customer with a name and an address
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Public getters to access encapsulated fields
    public string GetName() => _name;
    public Address GetAddress() => _address;

    // Method that checks if the customer lives in the USA
    // This delegates the check to the Address class (encapsulation & responsibility separation)
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}
