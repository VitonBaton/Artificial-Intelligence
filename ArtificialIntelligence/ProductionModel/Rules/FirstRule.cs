namespace ArtificialIntelligence.ProductionModel.Rules;

public class FirstRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }

    public FirstRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "diagonal")!.CreateWithNewValue("большая"),
        };
        Result = variables.Find(v => v.Type == "battery")!.CreateWithNewValue("большой");
        IsSimple = true;
    }
}