// Address class represents the customer's address information
public class Address
{
    // Encapsulation: private fields
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Constructor initializes the address
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    // Method that checks if the address is located in the USA
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa" || _country.ToLower() == "united states";
    }

    // Method that returns a formatted full address string
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}
