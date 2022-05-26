namespace ArtificialIntelligence.ProductionModel.Rules;

public class FifthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public FifthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "battery")!.CreateWithNewValue("маленький"),
            variables.Find(v => v.Type == "camera")!.CreateWithNewValue("плохая"),
            variables.Find(v => v.Type == "cpu")!.CreateWithNewValue("медленный"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("Xiaomi Redmi 9");
        IsSimple = false;
    }
}