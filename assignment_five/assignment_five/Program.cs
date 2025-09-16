using System;
using System.Collections.Generic;

namespace assignment_five
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zoo Management System");
            Console.WriteLine("------------------------");


            // create instance of derived class
            Animal animal = new Animal();
            Dog dog = new Dog();
            Eagle eagle = new Eagle();
            GoldFish fish = new GoldFish();

            // call the method on the derived class objects
            dog.MammalsName();
            double dogCost = dog.CalculateFoodCost();
            Console.WriteLine("The cost is : " +dogCost);

            Console.WriteLine();
            eagle.BirdName();
            double birdCost= eagle.CalculateFoodCost();
            Console.WriteLine("The cost is : " +birdCost);

            Console.WriteLine();
            fish.FishName();
            double fishCost= fish.CalculateFoodCost();
            Console.WriteLine("The cost is : " +fishCost);

            // Bonus challenges
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("Bonus Challenge");
            Console.WriteLine("__________________");

            Console.Write("Enter Cow name : ");
            string cowName= Console.ReadLine();

            Console.WriteLine();
            Console.Write("Enter Goat name : ");
            string goatName = Console.ReadLine();
            Console.WriteLine();

            Cow cow = new Cow { _name = cowName };
            Goat goat = new Goat { _name = goatName };

            List<IFeedable> animals = new List<IFeedable>();
            animals.Add(cow);
            animals.Add(goat);

            foreach (var animalName in animals)
            {
                Console.WriteLine($"Animal name : {animalName._name}");
                Console.WriteLine($"Feeding Schedule :{ animalName.GetFeedingSchedules()}");
                animalName.Feed();

                Console.WriteLine() ;
            }

        }

        #region Q1) Implement Encapsulation :

        // private field
        private  int _id;

        // public read only property for _id
        public int id { get { return _id; }}

        // validate age (0-100) in property set
        private int _age;
        public int age { get { return _age; } set { _age = (value > 0 || value < 100) ? value  : throw new ArgumentOutOfRangeException("Please insert age between 0 to 100") ; } }


        #endregion

        #region Q2) Add Inheritance Hierarchy:

        // base class Animal
        private class Animal
        {
            //property 

            // this is for Q3) virtual method

            public virtual double CalculateFoodCost()
            {
                return 0;
            }
        }

        // derived class inheritance in Reptile from Animal
        private class Reptile : Animal
        {

        }

        // derived class inheritance in Snake from Raptile
        private class Snake : Reptile
        {

        }

        // derived class inheritance in Turtle from Reptile
        private class Turtle : Reptile
        {

        }

        #endregion

        #region Q3) Demonstrate Polymorphism:

        //Animal base class is already in Q2.

        // Type of Animals
        private class Mammals : Animal
        {
            public virtual void MammalsName()
            {
                Console.WriteLine("Name of Mammals ");
            }
        }
        private class Birds : Animal
        {
            public virtual void BirdName()
            {
                Console.WriteLine("Name of Birds ");
            }
        }
        private class Fish : Animal
        {
            public virtual void FishName()
            {
                Console.WriteLine("Name of Fish ");
            }
        }

        // derived class of type of Animals
        private class Dog : Mammals
        {
            public override void MammalsName()
            {
                Console.WriteLine("Mammal Name of dog: german shepherd");
            }
            public override double CalculateFoodCost()
            {
                return 2000;
            }
        }

        private class Eagle : Birds
        {
            public override void BirdName()
            {
                Console.WriteLine("Bird Name : eagle");
            }
            public override double CalculateFoodCost()
            {
                return 300;
            }
        }

        private class GoldFish : Fish
        {
            public override void FishName()
            {
                Console.WriteLine("Fish Name : goldfish");
            }
            public override double CalculateFoodCost()
            {
                return 150;
            }
        }

        #endregion

    }
}
