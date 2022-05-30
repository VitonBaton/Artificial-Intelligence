namespace ArtificialIntelligence.SemanticModel.Structures;

public class Node
{
    public string Name { get; set; } = null!;
    public List<Relation> Relations { get; set; } = new ();

    public override string ToString()
    {
        return Name;
    }
}