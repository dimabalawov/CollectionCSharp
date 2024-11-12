using System;
using System.Collections.Generic;
Cafe cafe = new Cafe(totalTables: 5);

Visitor visitor1 = new Visitor("Alice", false);
Visitor visitor2 = new Visitor("Bob", true, DateTime.Now.AddMinutes(10));
Visitor visitor3 = new Visitor("Charlie", false);
Visitor visitor4 = new Visitor("Diana", true, DateTime.Now.AddMinutes(15));
Visitor visitor5 = new Visitor("Eve", false);

cafe.Arrive(visitor1);
cafe.Arrive(visitor2);
cafe.Arrive(visitor3);
cafe.Arrive(visitor4);
cafe.Arrive(visitor5);

cafe.FreeTable();
cafe.ShowStatus();

cafe.FreeTable();
cafe.ShowStatus();

cafe.FreeTable();
cafe.ShowStatus();
public class Visitor
{
    public string Name { get; set; }
    public bool HasReservation { get; set; }
    public DateTime? ReservationTime { get; set; }

    public Visitor(string name, bool hasReservation, DateTime? reservationTime = null)
    {
        Name = name;
        HasReservation = hasReservation;
        ReservationTime = reservationTime;
    }
}

public class Cafe
{
    private Queue<Visitor> queue = new Queue<Visitor>();
    private List<Visitor> tables = new List<Visitor>();
    private int totalTables;

    public Cafe(int totalTables)
    {
        this.totalTables = totalTables;
    }

    public void Arrive(Visitor visitor)
    {
        if (visitor.HasReservation)
        {
            Console.WriteLine($"{visitor.Name} has a reservation for {visitor.ReservationTime}. They skip the queue and get a table.");
            tables.Add(visitor);
        }
        else
        {
            Console.WriteLine($"{visitor.Name} joins the queue.");
            queue.Enqueue(visitor);
        }
    }

    public void FreeTable()
    {
        if (tables.Count < totalTables)
        {
            if (queue.Count > 0)
            {
                Visitor nextVisitor = queue.Dequeue();
                tables.Add(nextVisitor);
                Console.WriteLine($"{nextVisitor.Name} from the queue is seated at a table.");
            }
            else
            {
                Console.WriteLine("No visitors in the queue.");
            }
        }
        else
        {
            Console.WriteLine("All tables are currently occupied.");
        }
    }

    public void ShowStatus()
    {
        Console.WriteLine("\n--- Cafe Status ---");
        Console.WriteLine("Occupied tables:");
        foreach (var visitor in tables)
        {
            Console.WriteLine($"- {visitor.Name} {(visitor.HasReservation ? "(Reserved)" : "")}");
        }

        Console.WriteLine("Queue:");
        foreach (var visitor in queue)
        {
            Console.WriteLine($"- {visitor.Name}");
        }
        Console.WriteLine();
    }
}



