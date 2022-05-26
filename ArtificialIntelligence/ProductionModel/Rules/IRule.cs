namespace ArtificialIntelligence.ProductionModel.Rules;

public interface IRule
{
    public Variable[] Conditions { get; }
    public Variable Result { get; }
    public bool IsSimple { get; }
}