using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5;

public abstract class Animals // Abstract class cant create instance
{
    readonly private int _id; //readonly property
    private int _age;
    public string Name {  get; set; }
    public int Id { get { return _id; } } //uniquly identify 
    public int Age { get { return _age; } //logic for age verification
        set 
        {
            if (value <=0 || value>= 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Age), "Age must be between 0 and 100.");
            }
            _age = value;
        }
    }
    public Animals(int id, int age, string name) //constructor for setting object value
    {
        _id = id;
        Age = age;
        Name = name;
    }
    public virtual void FoodCost() //virtual method for overridding
    {
        Console.WriteLine($"Animal Usually eats food according to their age and body weight");
    }
}
public abstract class Reptiles:Animals //derived class from class animal
{
    public bool layEgg=true;
    public Reptiles(int id,string name, int age) : base(id, age,name) { }
}
public interface Ifeedable//interface for multiple inheritance
{
    public string preferedFood { get; set; }
    public string preferedSchedule {  get; set; }
    public void preferedMeal();

}
public class Snakes:Reptiles ,Ifeedable //multipule inheritance
{
    public Snakes(int id, string name, int age):base(id, name, age) { }
    public string preferedFood { get; set; } = "Frog"; //interface property
    public string preferedSchedule { get; set; } = "3 Times a day with 8 hours interval every day"; //interface property
    public void preferedMeal() 
    {
        Console.WriteLine($"Snake prefers {preferedFood} and eats {preferedSchedule}");
    }
    public override void FoodCost() //override foodcost of base class
    {
        Console.WriteLine("Snake's food cost depends on its size and feeding schedule.");
    }
}
public class Turtles : Reptiles, Ifeedable
{
    public Turtles(int id, string name, int age) : base(id, name, age) { }
    public string preferedFood { get; set; } = "Grass";
    public string preferedSchedule { get; set; } = "Grazing in day Time";
    public void preferedMeal()
    {
        Console.WriteLine($"Snake prefers {preferedFood} and eats {preferedSchedule}");
    }
    public new void FoodCost()
    {
        Console.WriteLine("Turtle's food cost is minimal due to its herbivorous diet.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Snakes snake = new(1, "Charley", 22);
        snake.FoodCost();
        snake.preferedMeal();
        Turtles turtle = new(2, "joe", 50);
        turtle.FoodCost();
        turtle.preferedMeal();
        
    }
}
