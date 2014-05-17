public class HumanGenerator
{
    public enum Sex
    {
        Male, Female
    }
    
    public void CreateHuman(int age)
    {
        Human newHuman = new Human();
        newHuman.Age = age;
        if (age % 2 == 0)
        {
            newHuman.Name = "Bro";
            newHuman.Sex = Sex.Male;
        }
        else
        {
            newHuman.Name = "Chick";
            newHuman.Sex = Sex.Female;
        }
    }

    public class Human
    {
        public Sex Sex { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}