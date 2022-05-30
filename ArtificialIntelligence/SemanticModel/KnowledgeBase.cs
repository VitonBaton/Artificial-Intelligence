using ArtificialIntelligence.SemanticModel.Structures;

namespace ArtificialIntelligence.SemanticModel;

public class KnowledgeBase
{
    public Node Person { get; init; } = new() {Name = "Человек"};
    public Node Client { get; init; } = new() {Name = "Клиент"};
    public Node Employee { get; init; } = new() {Name = "Сотрудник"};
    public Node Ivan { get; init; } = new() {Name = "Иван"};
    public Node Nikita { get; init; } = new() {Name = "Никита"};
    public Node IvanTicket { get; init; } = new() {Name = "Билет Ивана"};
    public Node Ticket { get; init; } = new() {Name = "Билет"};
    public Node TripVitebskMinsk { get; init; } = new() {Name = "Витебск-Минск"};
    public Node Trip { get; init; } = new() {Name = "Рейс"};
    public Node Shtadler { get; init; } = new() {Name = "Штадлер"};
    public Node Train { get; init; } = new() {Name = "Поезд"};

    public KnowledgeBase()
    {
        Client.Relations.Add(new Relation(From: Client, To: Person, Value: "является"));
        Client.Relations.Add(new Relation(From: Client, To: Ivan, Value: "например"));
        
        Employee.Relations.Add(new Relation(From: Employee, To: Person, Value: "является"));
        Employee.Relations.Add(new Relation(From: Employee, To: Nikita, Value: "например"));
        
        Ivan.Relations.Add(new Relation(From: Ivan, To: IvanTicket, Value: "купил"));
        Nikita.Relations.Add(new Relation(From: Nikita, To: IvanTicket, Value: "продал"));

        Ticket.Relations.Add(new Relation(From: Ticket, To: IvanTicket, Value: "например"));
        
        IvanTicket.Relations.Add(new Relation(From: IvanTicket, To: TripVitebskMinsk, Value: "это билет на рейс"));
        
        Trip.Relations.Add(new Relation(From: Trip, To: TripVitebskMinsk, Value: "например"));
        
        Train.Relations.Add(new Relation(From: Train, To: Shtadler, Value: "например"));
        Shtadler.Relations.Add(new Relation(From: Shtadler, To: TripVitebskMinsk, Value: "направляется по рейсу"));
    }
}