namespace ArtificialIntelligence.ProductionModel.Rules;

public class SeventhRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public SeventhRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "battery")!.CreateWithNewValue("большой"),
            variables.Find(v => v.Type == "camera")!.CreateWithNewValue("хорошая"),
            variables.Find(v => v.Type == "OC")!.CreateWithNewValue("Android"),
        };
        Result = variables.Find(v => v.Type == "phone")!.CreateWithNewValue("Google Pixel 6 Pro");
        IsSimple = false;
    }
}