using System;

namespace assignment_five
{
    internal interface IFeedable
    {
        string _name { get; set; }
        string GetFeedingSchedules();
        void Feed();
    }

    //  interface Ifeedable implementing (from all of the above methods, property should implement while inheritance)
    public class Cow : IFeedable
    { 
        // property 
        public string _name { get; set; }

        public string GetFeedingSchedules()
        {
            return "Cow eat twice times a day.";
        }
        public void Feed()
        {
            Console.WriteLine("Cow eat grass.");
        }

    }

    public class Goat : IFeedable
    { 
        public string _name { get; set; }

        public string GetFeedingSchedules()
        {
            return "Goat eat three times a day.";
        }
        public void Feed()
        {
            Console.WriteLine("Goat also eat grass hay.");
        }
    }
}
