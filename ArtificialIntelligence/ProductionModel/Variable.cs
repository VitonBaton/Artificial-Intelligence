namespace ArtificialIntelligence.ProductionModel;

public class Variable
{
    public string? Value { get;}
    
    public string Type { get;}
    
    public bool IsDefined => Value is not null;
    
    public string[] AvailableValues { get;}

    public Variable(string type, string[] availableValues, string? value = null)
    {
        Type = type;
        Value = value;
        AvailableValues = availableValues;
    }

    public Variable CreateWithNewValue(string? value = null)
    {
        return new Variable(Type, AvailableValues, value);
    }

    public Variable Clone()
    {
        return new Variable(Type, AvailableValues, Value);
    }
}