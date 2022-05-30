using ArtificialIntelligence.ProductionModel;
using ArtificialIntelligence.SemanticModel;
using KnowledgeBase = ArtificialIntelligence.ProductionModel.KnowledgeBase;

// TestDirectChain();

//TestReversedChain();

TestSemanticModel();

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

void TestSemanticModel()
{
    var knowledgeBase = new ArtificialIntelligence.SemanticModel.KnowledgeBase();

    var node = knowledgeBase.Client;
    
    ViewModel.Show(2, node);
}