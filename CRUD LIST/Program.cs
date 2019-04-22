using System;


namespace CRUD_LIST
{
    class Item
    {
        string name;
        public Item(string _name)
        {
            this.name = _name;
        }

        public void PrintName()
        {
            Console.WriteLine(this.name);
        }
    }


    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(140, 40);
            Item i0 = new Item(Console.ReadLine());
            i0.PrintName();

        }
    }
}
