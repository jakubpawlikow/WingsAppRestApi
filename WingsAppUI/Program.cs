using System;
using WingsAppBLL;
using WingsAppBLL.BusinessObjects;

namespace WingsAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade(); 
        static void Main(string[] args)
        {
            var userEvent = new UserEventBO()
            {
                Title = "First Title",
                Description = "First Description"
            };

            bllFacade.UserEventService.Create(userEvent);

            bllFacade.UserEventService.Create(new UserEventBO(){
                Title = "Second Title",
                Description = "Second Description"
            });

            string[] menuItems = {
                "List all user events",
                "Add user event",
                "Delete user event",
                "Edit user event",
                "Exit",
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListUserEvents();
                        break;
                    case 2:
                        AddUserEvent();
                        break;
                    case 3:
                        DeleteUserEvent();
                        break;
                    case 4:
                        EditUserEvent();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
        }

        private static UserEventBO FindUserEventById()
        {
            Console.WriteLine("Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong");
            }
            return bllFacade.UserEventService.Get(id);
        }

        private static void EditUserEvent()
        {
            var userEvent = FindUserEventById();
            if (userEvent != null)
            {
                Console.WriteLine("Title: ");
                userEvent.Title = Console.ReadLine();
                Console.WriteLine("Description: ");
                userEvent.Description = Console.ReadLine();
                bllFacade.UserEventService.Update(userEvent);
            }
            var response = userEvent == null ? "Not Found" : "Event Edited";
            Console.WriteLine(response);

        }

        private static void DeleteUserEvent()
        {
            var userEvent = FindUserEventById();
            if (userEvent != null)
            {
                bllFacade.UserEventService.Delete(userEvent.Id); 
                Console.WriteLine();
            }

            var response = userEvent == null ? "Not Found" : "Event Deleted";
            Console.WriteLine(response);
        }

        private static void AddUserEvent()
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();
            Console.WriteLine("Description: ");
            var description = Console.ReadLine();

            bllFacade.UserEventService.Create(new UserEventBO()
            {
                Title = title,
                Description = description,
            });
        }

        private static void ListUserEvents()
        {
            foreach (var userEvent in bllFacade.UserEventService.GetAll())
            {
                Console.WriteLine($"Id: {userEvent.Id} Title: {userEvent.Title} \n");
            }
        }
        public static int getIntValue(string msg, string wrongValueExceptionMsg = "Provied value is not a integer number")
        {

            int result;
            Console.Write(msg);         
            while (!int.TryParse(Console.ReadLine(), out result)) 
            {
                Console.WriteLine(wrongValueExceptionMsg);
                Console.WriteLine(msg);         
            }
            return result;
        }


        public static int ShowMenu(string[] menuValues){
            string menuToDisplay = "";
            int counter = 0;
            foreach (string item in menuValues)
            {
                counter++;
                menuToDisplay = menuToDisplay + $"{counter} - {item} \n";
            }
            Console.WriteLine(menuToDisplay);
            return getIntValue("Choose : ", "Wrong");
        }
    }
}
