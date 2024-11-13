using System;

class A
{
    public A()
    {
        Console.WriteLine("A created");
    }
}

class B : A
{
    private B()
    {
        Console.WriteLine("B created");
    }

    public B(string parametr)
    {
        Console.WriteLine("B created with parametr: {0}", parametr);
    }

    public B()
    {
        Console.WriteLine("B created");
    }
}

class C : B
{
    public C()
    {
        Console.WriteLine("C created");
    }
}

class Program
{
    static void Main(string[] args)
    {
        A ab = new B("inheritance");
        A ac = new C();


    }
}