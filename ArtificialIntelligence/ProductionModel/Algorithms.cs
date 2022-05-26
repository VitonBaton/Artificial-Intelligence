using ArtificialIntelligence.ProductionModel.Rules;

namespace ArtificialIntelligence.ProductionModel;

public static class Algorithms
{
    public static List<Variable> DirectChain(IEnumerable<Variable> startValues)
    {
        var knownVariables = new List<Variable>(startValues);
        var allVariables = KnowledgeBase.GetAllVariables();
        var rules = KnowledgeBase.GetAllRules();

        bool isStop;
        do
        {
            var countRules = rules.Count;
            for (var i = 0; i < rules.Count;)
            {
                var currentRule = rules[i];
                if (!currentRule.IsSimple && CheckOnDefined(currentRule, knownVariables))
                {
                    var notKnown = CheckOnUndefined(currentRule, knownVariables);
                    knownVariables.AddRange(notKnown.Select(GetInputFromUser));
                }

                if (IsFact(currentRule, knownVariables) &&
                    !knownVariables.Exists(v => v.Type == currentRule.Result.Type))
                {
                    knownVariables.Add(currentRule.Result.Clone());
                    rules.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }

            isStop = (knownVariables.Count == allVariables.Count)
                         || (countRules == rules.Count)
                         || (rules.Count == 0);
        } while (!isStop);

        return knownVariables;
    }

    private static IEnumerable<Variable> CheckOnUndefined(IRule rule, List<Variable> variables)
    {
        return rule.Conditions
            .Where(c => variables.Find(v => v.Type == c.Type) is null);
    }

    private static bool CheckOnDefined(IRule rule, List<Variable> variables)
    {
        return rule.Conditions
            .Any(c => variables.Find(v => v.Type == c.Type && v.Value == c.Value) is not null);
    }

    private static bool IsFact(IRule rule, List<Variable> variables)
    {
        return rule.Conditions
            .All(c => variables.Find(v => v.Type == c.Type  && v.Value == c.Value) is not null);
    }

    private static Variable GetInputFromUser(Variable variable)
    {
        var inputValues = variable.AvailableValues;

        Console.WriteLine("Значение переменной " + variable.Type + " неизвестно");
        Console.WriteLine("Введите одно из следующих значений:");
        foreach (var value in inputValues)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
        
        string? fromUser;

        do
        {
            fromUser = Console.ReadLine();
        } while (!inputValues.Contains(fromUser));

        if (fromUser is null)
        {
            throw new ArgumentNullException(nameof(variable));
        }

        return variable.CreateWithNewValue(fromUser);
    }
    
    public static List<Variable> ReversedChain(Variable searchedValue)
    {
        var knownVariables = new List<Variable>();
        var allVariables = KnowledgeBase.GetAllVariables();
        var rules = KnowledgeBase.GetAllRules();

        var stackRules = new Stack<RuleIndex<IRule, int>>();

        while (!IsDefined(searchedValue, knownVariables))
        {
            if (TryFindRuleWithRequiredResult(searchedValue, rules, out var founded))
            {
                stackRules.Push(founded);
            }
            else
            {
                Console.WriteLine("Невозможно определить переменную вывода " + searchedValue.Type);
                return knownVariables;
            }
            
            var lastConclusion = true;
            
            while (stackRules.Count != 0)
            {
                var rule = stackRules.Peek();

                if (IsDefined(rule.Rule.Conditions[rule.Index], knownVariables))
                {
                    rule.Index++;
                }
                else
                {
                    if (!TryFindRuleWithRequiredResult(rule.Rule.Conditions[rule.Index], rules, out founded) || !lastConclusion)
                    {
                        var v = GetInputFromUser(rule.Rule.Conditions[rule.Index]);
                        knownVariables.Add(v);
                        rule.Index++;
                    }
                    else
                    {
                        stackRules.Push(founded);
                    }
                }

                if (rule.Index >= rule.Rule.Conditions.Length)
                {
                    if (IsFact(rule.Rule, knownVariables))
                    {
                        knownVariables.Add(rule.Rule.Result.Clone());
                    }
                    else
                    {
                        rules.Remove(rule.Rule);
                        lastConclusion = false;
                    }

                    stackRules.Pop();
                }
            }
        }

        Console.WriteLine("Переменная вывода " + searchedValue.Type + " определена");
        return knownVariables;
    }

    private static bool IsDefined(Variable variable, List<Variable> knownVariables)
    {
        return knownVariables.Exists(v => v.Type == variable.Type);
    }
    
    private static bool TryFindRuleWithRequiredResult(Variable result, IEnumerable<IRule> rules, out RuleIndex<IRule, int> rule)
    {
        try
        {
            rule = new RuleIndex<IRule, int>(rules.First(r => r.Result.Type == result.Type), 0);
            return true;
        }
        catch (InvalidOperationException)
        {
            rule = null!;
            return false;
        }
    }

    private class RuleIndex<TRule, TIndex>
    {
        public TRule Rule { get; set; }
        public TIndex Index { get; set; }

        public RuleIndex(TRule rule, TIndex index)
        {
            this.Rule = rule;
            this.Index = index;
        }
    }
}