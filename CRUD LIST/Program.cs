using System;
using System.Collections.Generic;

namespace CRUD_LIST
{
    class Item
    {
        public string Name;
        public string Position;
        public string TimeStamp;
        
        public Item(string _name, string _position, string _timestamp) 
        {//constructor that takes name input and a timestamp as parametrs
            this.Name = _name;
            this.Position = _position; 
            this.TimeStamp = _timestamp;
            
        }

        public void PrintName()
        {
            Console.WriteLine(this.Name);
        }

        public void PrintInfo()
        {
            Console.WriteLine("Item name is {0}\nItem position is {1}", this.Name, this.Position);
            Console.WriteLine("Time stamp {0}\n", this.TimeStamp);
        }
    }


    class Program
    {
        static void Main()
        {
            Console.SetWindowSize(140, 40);
            //    Item i0 = new Item (Console.ReadLine(),(DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss")); 
            //    i0.PrintName();
            List<Item> ItemList = new List<Item>(); // a list that holds item objects
            bool exit = false;
            bool found = false;
            int k = 0;
            string choice = " ";
            string search = " ";

            do
            {
                found = false; //reseting
                Console.WriteLine("Item List:");
                for (int i = 0; i < ItemList.Count; i++) ItemList[i].PrintName();

                Console.WriteLine("\nWhat to do?");
                choice = Console.ReadLine().ToUpper();

                //creates new item in the list
                if (choice == "CREATE")
                {
                    //creating new item in the list
                    //need to test for name/position duplicates
                    Console.WriteLine("Please enter item name and item position");
                    ItemList.Add(new Item(Console.ReadLine(), Console.ReadLine(), (DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss")));

                }

                // Read an object, find it by it's name or position
                else if (choice == "READ")
                {

                    
                    Console.WriteLine("Enter the name or position of the object you want to read");
                    search = Console.ReadLine();

                    for (int i = 0; i < ItemList.Count; i++)
                    {
                        if (ItemList[i].Name.Equals(search))
                        {
                            ItemList[i].PrintInfo();
                            found = true;
                            break;
                        }
                        else if (ItemList[i].Position.Equals(search))
                        {
                            ItemList[i].PrintInfo();
                            found = true;
                            break;
                        }
                    }
                    if (found == false) Console.WriteLine("No item found based on the search parameter"); 
                }

                //Update an object
                else if (choice == "UPDATE")
                {
                    //will need to check for duplicates
                    Console.WriteLine("Enter the name or position of the object you want to update");
                    search = Console.ReadLine();

                    for (int i = 0; i < ItemList.Count; i++)
                    {
                        if (ItemList[i].Name.Equals(search))
                        {
                            ItemList[i].PrintInfo();
                            found = true;
                            Console.WriteLine("Type in object's new name");
                            ItemList[i].Name = Console.ReadLine();
                            Console.WriteLine("Type in object's new position");
                            ItemList[i].Position = Console.ReadLine();
                            ItemList[i].TimeStamp = (DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss");
                            Console.WriteLine("Object updated");
                            ItemList[i].PrintInfo();
                            break;
                        }
                        else if (ItemList[i].Position.Equals(search))
                        {
                            ItemList[i].PrintInfo();
                            found = true;
                            Console.WriteLine("Type in object's new name");
                            ItemList[i].Name = Console.ReadLine();
                            Console.WriteLine("Type in object's new position");
                            ItemList[i].Position = Console.ReadLine();
                            ItemList[i].TimeStamp = (DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss");
                            Console.WriteLine("Object updated");
                            ItemList[i].PrintInfo();
                            break;
                        }
                    }
                    if (found == false) Console.WriteLine("No item found based on the search parameter");
                }

                //Delete an object
                else if (choice == "DELETE")
                {
                    Console.WriteLine("Enter the name or position of the object you want to delete");
                    search = Console.ReadLine();

                    for (int i = 0; i < ItemList.Count; i++)
                    {
                        if (ItemList[i].Name.Equals(search))
                        {
                            Console.WriteLine("Deleting");
                            ItemList[i].PrintInfo();
                            ItemList.Remove(ItemList[i]);
                            found = true;
                            break;
                        }
                        else if (ItemList[i].Position.Equals(search))
                        {
                            Console.WriteLine("Deleting");
                            ItemList[i].PrintInfo();
                            ItemList.Remove(ItemList[i]);
                            found = true;
                            break;
                        }
                    }
                    if (found == false) Console.WriteLine("No item found based on the search parameter");
                }
                else if (choice == "HELP")
                {
                    Console.WriteLine("Placeholder for help menu");
                }
                else if (choice == "EXIT")
                {
                    Console.WriteLine("Exiting the application");
                    exit = true;
                }

            } while (exit == false);
        }
    }
}

/*
•	Create<name> <position> - Creates an item with current timestamp and adds it to the buy list the position number.
•	Read<name/position> - Items name, position and timestamp are shown in the console.
•	Update<name/position> <changed name> <position> - Updates chosen items name, position and replaces timestamp with current time.
•	Delete<name/position> - Deletes an Item
•	Help – Shows all possible commands and descriptions
*/

