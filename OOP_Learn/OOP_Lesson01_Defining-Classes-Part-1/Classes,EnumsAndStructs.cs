using System;

class Cat
{
    public string name, breed;
    public Cat()
    {
        name = "cat";
        breed = "persian";
    }
    public Cat(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
    }
}

public class Dog
{
    private string name = "Sharo";
    // ...
    private void Bark()
    {
        Console.WriteLine("wow-wow");
    }
    // ...
    private void Dummy()
    {
        Dog myDog = new Dog();
        Console.WriteLine("My dog's name is " + myDog.name);
        myDog.Bark();
    }
    //static void Main()
    //{
    //    Dog newDog = new Dog();
    //    newDog.Dummy();
    //}
}

class ConstReadonlyModifiersTest
{
    public readonly double size;
}

class Sequence
{
    private static int currentValue = 0;
    private Sequence()
    {

    }
    public static int NextValue()
    {
        return ++currentValue;
    }
}

class Program
{
    static void Main()
    {
        //one object variable can assign different instances to itself over time
        //= one object variable, different object instances
        Cat aCat = new Cat();
        Console.WriteLine(aCat.name + " " + aCat.breed);
        aCat = new Cat("buddy", "furless");
        Console.WriteLine(aCat.name + " " + aCat.breed);

        //a default ctor initializes every type member; an explicit initialization is not required
        Dog aDog = new Dog();
        //Console.WriteLine(aDog.id + " " + aDog.address);

        //static fields are initalized on first class invoke (class initialization - already initialized)
        //Console.WriteLine(Dog.isHomeless + " " + Dog.state);

        //call static method
        Console.WriteLine(Sequence.NextValue());
        Console.WriteLine(Sequence.NextValue());

        //can not initialize uninitializable (utility) class
        //Sequence aSequence = new Sequence();
        //Console.WriteLine(aSequence.currentValue);

        //using some constants
        Console.WriteLine("pi = " + Math.PI);
        Console.WriteLine("e = " + Math.E);

        Console.WriteLine(new ConstReadonlyModifiersTest().size);

        Days days = (Days)5;
        Console.WriteLine((Days)10.2);

        Console.WriteLine(typeof(Days));
        Console.WriteLine(typeof(SomeEnum));

        SomeEnum someEnumVar = SomeEnum.one;
        Console.WriteLine(someEnumVar);
        Console.WriteLine((int)SomeEnum.one + " " + (int)SomeEnum.two + " " + (int)SomeEnum.three + " " + (int)SomeEnum.four + " " + (int)SomeEnum.five);
    }
}

enum Days
{
    Mon,
    Tue,
    Wed,
    Thu,
    Fri,
    Sat,
    Sun
}

enum SomeEnum
{
    one = -5,
    two,
    three,
    four,
    five = unchecked((int)4000000000)
}