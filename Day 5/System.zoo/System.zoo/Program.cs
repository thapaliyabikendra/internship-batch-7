using System.Xml.Linq;

namespace System.zoo;

public interface IFeedable
{
    void SetFeedingSchedule(string schedule);
    string GetFeedingSchedule();
}
public class Animal : IFeedable
{
    private int _id;   
    private int _age=0;
    public string feedingSchedule;

    public Animal(int id, int age,string feedingSchedule)
    {
        _id = id;
        this.feedingSchedule = feedingSchedule;
        Age = age;
    }
    public int Age
    {

        get => _age;
        set
        {
            if (value <= 100 && value > 0)
            {
                _age = value;
                Console.WriteLine("The age is: "+ _age);
            }
            else
            {
                Console.WriteLine("Age must be between 0 and 100");
            }
        }
    }

    public virtual double CalculateFoodCost()
    {
        Console.WriteLine("this is food cost of animal");
        return Age * 1.0;
        
    }

    public virtual string GetFeedingSchedule()
    {
        
        Console.WriteLine("the schedule id: "+feedingSchedule); 
        return feedingSchedule;
    }

    public virtual void SetFeedingSchedule(string schedule)
    {
        feedingSchedule = schedule;
    }
}

public class Reptile : Animal
{
    public Reptile(int id,int age, string feedingSchedule) : base(id,age,feedingSchedule) { }

    public override double CalculateFoodCost() 
    {
        Console.WriteLine("this is food cost of Reptile");
        return Age * 1.5;

    }

    public override string GetFeedingSchedule()
    {

        Console.WriteLine("the schedule id: " + feedingSchedule);
        return feedingSchedule;
    }

    public override void SetFeedingSchedule(string schedule)
    {
        feedingSchedule = schedule;
    }

}

public class Turtle : Reptile
{
    public Turtle(int id, int age, string feedingSchedule) : base(id, age, feedingSchedule) { }

    public override double CalculateFoodCost()
    {
        Console.WriteLine("this is food cost of Turtle");
        return Age * 1.2;

    }
}

public class Snake : Reptile
{
    public Snake(int id, int age, string feedingSchedule) : base(id, age, feedingSchedule) { }

    public override double CalculateFoodCost()
    {
        Console.WriteLine("this is food cost of Snake");
        return Age * 1.8;

    }
}

public class Pices : Animal
{
    public Pices(int id, int age, string feedingSchedule) : base(id, age, feedingSchedule) { }

    public override double CalculateFoodCost()
    {
        return Age * 2.0;
    }


    static void Main()
    {
        Animal a = new Animal(3, 5, "noon");

        Console.WriteLine("Animal Class");
        a.CalculateFoodCost();
        a.SetFeedingSchedule("noon");
        a.GetFeedingSchedule();


        Snake s = new Snake(3,5,"noon");
        Console.WriteLine("Snake Class");
        s.CalculateFoodCost();
        s.SetFeedingSchedule("night");
        s.GetFeedingSchedule();
    }

}