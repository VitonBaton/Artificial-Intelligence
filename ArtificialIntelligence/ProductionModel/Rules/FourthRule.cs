namespace ArtificialIntelligence.ProductionModel.Rules;

public class FourthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public FourthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "display")!.CreateWithNewValue("IPS"),
            variables.Find(v => v.Type == "OC")!.CreateWithNewValue("iOS"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("iPhone 11");
        IsSimple = false;
    }
}