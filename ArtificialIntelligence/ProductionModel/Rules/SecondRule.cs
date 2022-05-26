namespace ArtificialIntelligence.ProductionModel.Rules;

public class SecondRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public SecondRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "cost")!.CreateWithNewValue("дорогой"),
            variables.Find(v => v.Type == "OC")!.CreateWithNewValue("iOS"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("iPhone 13");
        IsSimple = false;
    }
}