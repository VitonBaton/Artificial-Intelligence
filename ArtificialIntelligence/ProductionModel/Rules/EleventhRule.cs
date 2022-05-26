namespace ArtificialIntelligence.ProductionModel.Rules;

public class EleventhRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public EleventhRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "diagonal")!.CreateWithNewValue("маленькая"),
            variables.Find(v => v.Type == "OC")!.CreateWithNewValue("iOS"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("iPhone 8");
        IsSimple = false;
    }        
}