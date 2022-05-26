namespace ArtificialIntelligence.ProductionModel.Rules;

public class TenthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public TenthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "display")!.CreateWithNewValue("LPTO"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("Google Pixel 6 Pro");
        IsSimple = true;
    }    
}