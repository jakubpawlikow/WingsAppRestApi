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
            var user_event = new UserEventBO()
            {
                Title = "First Title",
                Description = "First Description"
            };

            bllFacade.UserEventService.Create(user_event);

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
            var user_event = FindUserEventById();
            if (user_event != null)
            {
                Console.WriteLine("Title: ");
                user_event.Title = Console.ReadLine();
                Console.WriteLine("Description: ");
                user_event.Description = Console.ReadLine();
                bllFacade.UserEventService.Update(user_event);
            }
            var response = user_event == null ? "Not Found" : "Event Edited";
            Console.WriteLine(response);

        }

        private static void DeleteUserEvent()
        {
            var user_event = FindUserEventById();
            if (user_event != null)
            {
                bllFacade.UserEventService.Delete(user_event.ID); 
                Console.WriteLine();
            }

            var response = user_event == null ? "Not Found" : "Event Deleted";
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
            foreach (var user_event in bllFacade.UserEventService.GetAll())
            {
                Console.WriteLine($"Id: {user_event.ID} Title: {user_event.Title} \n");
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
