class Person
{
    public string name = "Undefined";
    public int age;

    // public Person() { }
    // public Person(int ageage) { name = "Baby"; age = 35; }
    // public Person(string name) { this.name = "SSS"; age = 50; }
    public Person(int age) : this("sss", age) { }
    public Person(int age, string name) : this(name, age) { }
    public Person(string name = "noname", int age = 0)
    {
        this.name = name + name; this.age = 100 - age;
    }


    public void Print()
    {
        Console.WriteLine($"Имя: {name}  Возраст: {age}");
    }
}