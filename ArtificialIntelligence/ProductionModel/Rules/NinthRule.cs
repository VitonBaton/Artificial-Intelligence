namespace ArtificialIntelligence.ProductionModel.Rules;

public class NinthRule : IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
    
    public NinthRule()
    {
        var variables = KnowledgeBase.GetAllVariables();
        Conditions = new[]
        {
            variables.Find(v => v.Type == "diagonal")!.CreateWithNewValue("большая"),
            variables.Find(v => v.Type == "cost")!.CreateWithNewValue("дешевый"),
        };
        Result = variables.Find(v => v.Type == "OC")!.CreateWithNewValue("Android");
        IsSimple = false;
    }
}