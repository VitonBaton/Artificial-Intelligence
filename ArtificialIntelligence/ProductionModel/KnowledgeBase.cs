using ArtificialIntelligence.ProductionModel.Rules;

namespace ArtificialIntelligence.ProductionModel;

public static class KnowledgeBase
{
    public static List<Variable> GetAllVariables()
    {
        return new List<Variable>
        {
            new("OC", new[] {"Android", "iOS"}),
            new("diagonal", new[] {"большая", "маленькая"}),
            new("display", new[] {"IPS", "Amoled", "LPTO"}),
            new("cpu", new[] {"быстрый", "медленный"}),
            new("cost", new[] {"дорогой", "дешевый"}),
            new("camera", new[] {"хорошая", "плохая"}),
            new("battery", new[] {"большой", "маленький"}), 
            new("phone", new[] {
                "iPhone 13",
                "iPhone 11",
                "iPhone 8",
                "Google Pixel 6 Pro",
                "Xiaomi Redmi 9",
            }),
        };
    }

    public static List<IRule> GetAllRules()
    {
        return new List<IRule>
        {
            new FirstRule(),
            new SecondRule(),
            new ThirdRule(),
            new FourthRule(),
            new FifthRule(),
            new SixthRule(),
            new SeventhRule(),
            new EighthRule(),
            new NinthRule(),
            new TenthRule(),
            new EleventhRule(),
            new TwelfthRule(),
        };
    }
}