using ArtificialIntelligence.ProductionModel;

// TestDirectChain();

TestReversedChain();

void TestDirectChain()
{
    var variable = KnowledgeBase.GetAllVariables().Find(v => v.Type == "diagonal")!.CreateWithNewValue("маленькая");

    var knownInfo = Algorithms.DirectChain(new[]{variable});


    Console.WriteLine("Известные данные:");
    foreach (var v in knownInfo)
    {
        Console.WriteLine(v.Type + " = " + v.Value);
    }

    if (!knownInfo.Exists(v => v.Type == "phone"))
    {
        Console.WriteLine("Подходящий телефон не найден");
    }
    
}

void TestReversedChain()
{
    var variable = KnowledgeBase.GetAllVariables().Find(v => v.Type == "phone")!;

    var knownInfo = Algorithms.ReversedChain(variable);


    Console.WriteLine("Известные данные:");
    foreach (var v in knownInfo)
    {
        Console.WriteLine(v.Type + " = " + v.Value);
    }

    if (!knownInfo.Exists(v => v.Type == "phone"))
    {
        Console.WriteLine("Подходящий телефон не найден");
    }
    
}