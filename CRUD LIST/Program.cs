using System;


namespace CRUD_LIST
{
    class Item
    {
        string Name;
        string TimeStamp;
        public Item(string _name, string _timestamp) 
        {//constructor that takes name input and a timestamp as parametrs
            this.Name = _name;
            this.TimeStamp = _timestamp;
        }

        public void PrintName()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine(this.TimeStamp);
        }
    }


    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(140, 40);
            Item i0 = new Item (Console.ReadLine(),(DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss")); 
            i0.PrintName();

        }
    }
}
