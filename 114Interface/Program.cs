// See https://aka.ms/new-console-template for more information
using _114Interface;

Console.WriteLine("Hello, World!");


public class Manager : IEmployee
{
    private string _region;
    private int _id;
    private string _name;
    private string _location;
    public int EmpID { get => _id; set => _id=value; }
    public string EmpName { get => _name; set => _name=value; }
    public string Location { get =>_location; set => _location=value; }

    public string GetHealthInsuranceAmount()
    {
        return "1000";
    }
}