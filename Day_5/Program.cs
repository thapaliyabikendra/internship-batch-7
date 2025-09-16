using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    public abstract class Animals
    {
        readonly private int _id;
        private int _age;
        public string Name {  get; set; }
        public int Id { get { return _id; } }
        public int Age { get { return _age; }
            set 
            {
                if (value >= 0 || value <= 100)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Age), "Age must be between 0 and 100.");
                }
            }
        }
        public Animals(int id, int age, string name)
        {
            _id = id;
            Age = age;
            Name = name;
        }
        public virtual void FoodCost()
        {
            Console.WriteLine($"Animal Usually eats food according to their age and body weight");
        }
    }
    public abstract class Reptiles:Animals
    {
        public bool layEgg=true;
        public Reptiles(int id,string name, int age) : base(id, age,name) { }
    }
    public interface Ifeedable
    {
        public string preferedFood { get; set; }
        public string preferedSchedule {  get; set; }
        public void preferedMeal();

    }
    public class Snakes:Reptiles ,Ifeedable
    {
        public Snakes(int id, string name, int age):base(id, name, age) { }
        public string preferedFood { get; set; } = "Frog";
        public string preferedSchedule { get; set; } = "3 Times a day with 8 hours interval every day";
        public void preferedMeal()
        {
            Console.WriteLine($"Snake prefers {preferedFood} and eats {preferedSchedule}");
        }
        public override void FoodCost()
        {
            Console.WriteLine("Snake's food cost depends on its size and feeding schedule.");
        }
    }
    class Turtles : Reptiles, Ifeedable
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
}
