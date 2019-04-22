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
        {//constructor that takes name, position and a timestamp as parametrs
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
            bool duplicate = false;
            string choice = " ";
            string search = " ";
            string Name = " ";
            string Position;
            int test1, test2;

            Program.Help();

            do
            {
                
               
                found = false; //reseting for a fresh loop
                duplicate = false; //reseting for a fresh loop
                Console.WriteLine("Item List:");
                for (int i = 0; i < ItemList.Count; i++) ItemList[i].PrintName();

                Console.WriteLine("\nCommand list: CREATE, READ, UPDATE, DELETE, HELP, EXIT\nPlease type in a command");
                choice = Console.ReadLine().ToUpper();


                // Create new item in the list
                if (choice == "CREATE")
                {
                    //creating new item in the list
                    //need to test for name/position duplicates, correctness of input
                    Console.WriteLine("Please enter new item's Name and Position.");
                    string[] tokens = Console.ReadLine().Split();
                    if (tokens.Length == 2) // check that there were 2 inputs
                    {
                        Name = tokens[0];
                        Position = tokens[1];
                        for (int i = 0; i < ItemList.Count; i++) //checking for duplicates
                        {
                            if (ItemList[i].Name == Name || ItemList[i].Position == Position)
                            {
                                Console.WriteLine("Item attributes have to be unique. Type in HELP for HELP MENU");
                                duplicate = true;
                                break;
                            }
                        }
                        if (!duplicate)//There must be no duplicates in the list (identical names and positions)
                        {
                            if (int.TryParse(Position, out test1) && !(int.TryParse(Name, out test2))) //Position must be a number, Name must not be a number
                            {
                                ItemList.Add(new Item(Name, Position, (DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss"))); //constructor takes name, position and time stamp
                                Console.Clear();
                            }
                            else Console.WriteLine("Incorrect input. Name must be a string, position must be an integer. Type in HELP for HELP MENU.");
                        }
                    }
                    else Console.WriteLine("Incorrect input. Input format: Name Position (Example: Apple 1). Type in HELP for HELP MENU");
                }

                // Read an object, find it by it's name or position
                else if (choice == "READ")
                {
                    Console.WriteLine("Enter the Name or Position of the item you want to read");
                    search = Console.ReadLine();

                    for (int i = 0; i < ItemList.Count; i++)
                    {
                        if (ItemList[i].Name == search || ItemList[i].Position == search)
                        {
                            Console.Clear();
                            ItemList[i].PrintInfo();
                            found = true;
                            break;
                        }
                    }
                    if (found == false) Console.WriteLine("No item found based on the search parameter");
                }

                //Update an object, works very similar to create
                else if (choice == "UPDATE")
                {
                    Console.WriteLine("Enter the Name or Position of the item you want to update");
                    search = Console.ReadLine();

                    //need to test for name/position duplicates, correctness of inputs
                    for (int i = 0; i < ItemList.Count; i++)
                    {
                        if (ItemList[i].Name == search || ItemList[i].Position == search)
                        {
                            ItemList[i].PrintInfo();
                            found = true;

                            Console.WriteLine("Please enter item's new Name and new Position");
                            string[] tokens = Console.ReadLine().Split();
                            if (tokens.Length == 2) // check that there were 2 inputs
                            {
                                Name = tokens[0];
                                Position = tokens[1];
                                for (int j = 0; j < ItemList.Count; j++) //checking for duplicates
                                {
                                    if (ItemList[j].Name == Name || ItemList[j].Position == Position)
                                    {
                                        Console.WriteLine("Item's attributes have to be unique. Type in HELP for HELP MENU");
                                        duplicate = true;
                                        break;
                                    }
                                }
                                if (!duplicate)//There must be no duplicates in the list (identical names and positions)
                                {
                                    if (int.TryParse(Position, out test1) && !(int.TryParse(Name, out test2))) //Position must be a number, Name must not be a number
                                    {
                                        ItemList[i].Name = Name;
                                        ItemList[i].Position = Position;
                                        ItemList[i].TimeStamp = (DateTime.Now).ToString("yyyy.MM.dd HH:mm:ss");
                                        Console.Clear();
                                        Console.WriteLine("Item updated");
                                        ItemList[i].PrintInfo();
                                        break;
                                    }
                                    else Console.WriteLine("Incorrect input. Name must be a string, Position must be an integer. Type in HELP for HELP MENU.");
                                }
                            }
                            else Console.WriteLine("Incorrect input. Input format: Name Position (Example: Apple 1). Type in HELP for HELP MENU");



                        }
                    }
                    if (found == false) Console.WriteLine("No item found based on the search parameter");
                }

                //Delete an object
                else if (choice == "DELETE")
                {
                    Console.WriteLine("Enter the Name or Position of the item you want to delete");
                    search = Console.ReadLine();

                    for (int i = 0; i < ItemList.Count; i++)
                    {
                        if (ItemList[i].Name == search || ItemList[i].Position == search)
                        {
                            Console.WriteLine("Deleting:");
                            ItemList[i].PrintInfo();
                            ItemList.Remove(ItemList[i]);
                            found = true;
                            break;
                        }
                    }
                    if (found == false) Console.WriteLine("No item found based on the search parameter");
                }

                //HELP
                else if (choice == "HELP")
                {
                    Program.Help();
                }

                //EXIT
                else if (choice == "EXIT")
                {
                    Console.WriteLine("Exiting the application");
                    exit = true;
                }
                else Console.WriteLine("Incorrect input. Type in HELP for HELP MENU");

            } while (exit == false);
        }


        public static void Help()
        {
            Console.Clear();
            Console.WriteLine("HELP MENU\nCommand list: CREATE, READ, UPDATE, DELETE, HELP, EXIT\nCommands are not case sensitive.\n");
            Console.WriteLine("CREATE command creates a new item (object) in the list. Parameters: Name(string) Position(integer) separated by a space.");
            Console.WriteLine("Time stamp is generated automatically. Both Name and Position must be unique in the list. Example CREATE\nApple 1 \n");

            Console.WriteLine("READ command shows item's name, position and timestamp in the console. Parameters: Name(string) or Position(integer).");
            Console.WriteLine("Example READ\nApple\n");

            Console.WriteLine("UPDATE command updates chosen item's name, position and automatically replaces timestamp with current time.");
            Console.WriteLine("Parameters: Name(string) or Position(integer) to select an object. Name(string) Position(integer) separated by a space to update");
            Console.WriteLine("Example UPDATE\nApple\nOrange 2\n");

            Console.WriteLine("DELETE command deletes an item from the list. Parameters: Name(string) or Position(integer).");
            Console.WriteLine("Example DELETE\n2\n");

            Console.WriteLine("HELP command opens the HELP MENU\n");
            Console.WriteLine("EXIT command exits the application\n");

            Console.WriteLine("Press any key to go to the list");
            Console.ReadKey();
            Console.Clear();
        }

        
    }

}



