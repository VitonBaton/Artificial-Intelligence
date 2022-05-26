namespace ArtificialIntelligence.ProductionModel.Rules;

public class SixthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public SixthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "diagonal")!.CreateWithNewValue("маленькая"),
            variables.Find(v => v.Type == "camera")!.CreateWithNewValue("плохая"),
        };
        Result = variables.Find(v => v.Type == "cost")!.CreateWithNewValue("дешевая");
        IsSimple = false;
    }
}