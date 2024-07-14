namespace Lec1Apis.Models
{
    public class Person()
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public Person(string name, int age):this()
        {
            Name = name;
            Age = age;
            Id = Guid.NewGuid();
        }
    }
}
