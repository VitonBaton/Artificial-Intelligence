namespace ArtificialIntelligence.ProductionModel.Rules;

public class ThirdRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public ThirdRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "cost")!.CreateWithNewValue("дешевый"),
        };
        Result = variables.Find(v => v.Type == "cpu")!.CreateWithNewValue("медленный");
        IsSimple = true;
    }
}