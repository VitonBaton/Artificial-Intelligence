namespace ArtificialIntelligence.ProductionModel.Rules;

public class EighthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public EighthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "cost")!.CreateWithNewValue("дорогая"),
            variables.Find(v => v.Type == "battery")!.CreateWithNewValue("плохая"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("iPhone 11");
        IsSimple = false;
    }
}