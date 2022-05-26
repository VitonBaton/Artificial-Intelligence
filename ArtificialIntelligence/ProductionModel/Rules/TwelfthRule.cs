namespace ArtificialIntelligence.ProductionModel.Rules;

public class TwelfthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public TwelfthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "cost")!.CreateWithNewValue("дорогой"),
        };
        Result = variables.Find(v => v.Type == "OC")!.CreateWithNewValue("iOS");
        IsSimple = true;
    }    
}