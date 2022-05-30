using ArtificialIntelligence.SemanticModel.Structures;

namespace ArtificialIntelligence.SemanticModel;

public static class ViewModel
{
    public static void Show(int deep, Node node)
    {
        Show(0, deep, node);
    }
    
    private static void Show (int level, int deep, Node node)
    {
        const int tab = 3;

        if (level != deep*2 && node.Relations.Count != 0)
        {
            Console.WriteLine(string.Empty.PadLeft(level*tab) + $"{node.Name}:");
            level++;
            foreach (var (value, _, to) in node.Relations)
            {
                var str = string.Empty.PadLeft(level*tab) + $"{value} {to}";
                Console.WriteLine(str);
                Show(level + 1, deep, to);
            }
        }
    }
}