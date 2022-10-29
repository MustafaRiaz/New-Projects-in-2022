using System.Text;

namespace Project
{
    internal static class Program
    {
        internal class AppointmentList
        {
            public static List<holdAppointment> appointments = new List<holdAppointment>();
            public static void addIntoList(holdAppointment appointment)
            {
                appointments.Add(appointment);
            }
            public static void showAppointments()
            {

                bool x = false;
                for (int i = 0; i < appointments.Count; i++)
                {
                    ProjectUI.showPeople(appointments[i].appointment, i + 1, appointments[i].time);
                    x = true;
                }
                if (x == false)
                {
                    Console.WriteLine("Please make a schedule first");
                }
                Console.ReadKey();
            }
        }
        public class Person
        {
            public string firstName;
            public string lastName;
            public string gender;
            public string birthDate;
            public Person(string firstName, string lastName, string gender, string birthDate)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.gender = gender;
                this.birthDate = birthDate;
            }
            public static void trim()
            {
                Console.WriteLine("The Trim Service Was Performed");
            }
            public static void fullCut()
            {
                Console.WriteLine("The Full Cut Service Was Performed");
            }
            public static void dye()
            {
                Console.WriteLine("The Dye Service Was Performed");
            }
            public static void bearedTrim()
            {
                Console.WriteLine("The Beard Trim Service Was Performed");
            }
        }
        internal class PersonDL
        {

            public static List<string> schedule = new List<string>();
            public static List<hairdresser> people = new List<hairdresser>();
            public static void addPersonIntoList(hairdresser person)
            {
                people.Add(person);
            }

            public static void showAllPeople()
            {
                for (int i = 0; i < people.Count; i++)
                {
                    ProjectUI.printPeople(people[i], i + 1);
                }
            }
            public static string changeNumber(string number)
            {

                StringBuilder sb = new StringBuilder(number);
                if (number != null)
                {
                    string n = number;
                    for (int i = 0; i < 3; i++)
                    {
                        sb[i] = 'X';
                    }
                }
                number = sb.ToString();
                return number;

            }
            public static void createASchedule()
            {
                string sched = "";
                int k = 8;
                int l = 9;
                string z = " am";
                for (int i = 0; i < people.Count; i++)
                {
                    if (l == 12)
                    {
                        l = l - 12;
                        z = " pm";


                    }
                    if (k == 12)
                    {
                        k = k - 12;

                    }
                    k = k + 1;
                    l = l + 1;
                    sched = k + " to " + l + z;
                    Console.WriteLine("\n" + sched);
                    schedule.Add(sched);
                }

            }
            public static int x = 0;
            public static void createAppointments()
            {
                PersonDL.createASchedule();
                while (x < people.Count)
                {
                    holdAppointment a1 = new holdAppointment(people[x], PersonDL.schedule[x]);
                    AppointmentList.addIntoList(a1);
                    x = x + 1;
                }
            }
            //Validation
            public static void nameValidation(string name)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    for (int j = 0; j < name.Length; j++)
                    {

                    }
                }
            }
        
        }
        internal class holdAppointment
        {
            public hairdresser appointment;
            public string time;
            public holdAppointment(hairdresser appointment, string time)
            {
                this.appointment = appointment;
                this.time = time;
            }
        }
        public class hairdresser : Person
        {
            public string customerNumber;
            public List<string> services;

            public hairdresser(string firstName, string lastName, string gender, string birthDate,
                string customerNumber, List<string> services) : base(firstName, lastName, gender, birthDate)
            {
                this.customerNumber = customerNumber;
                this.services = services;

            }


        }
        public class ProjectUI
        {
            public static void header()
            {
                Console.Clear();
                Console.WriteLine("-----------------------");
                Console.WriteLine("Welcome to Braber's Shop");
                Console.WriteLine("-----------------------\n");
            }
            public static void Menu()
            {
                header();
                Console.WriteLine("Main Menu :");
                Console.WriteLine("-----------\n");
                Console.WriteLine("1-List all people:");
                Console.WriteLine("2-Create A Schedule:");
                Console.WriteLine("3-Diplay the Day's Schedule:");
                Console.WriteLine("4-Exit the Program:\n");
                Console.WriteLine("Enter Your Option :");
            }
            public static void headerlistPeople()
            {
                Console.WriteLine("List of all People :");
                Console.WriteLine("--------------------\n");
            }
            public static void printPeople(hairdresser people, int i)
            {

                Console.WriteLine("Person No:" + " " + i);
                Console.WriteLine("-----------");
                Console.WriteLine(people.firstName);
                Console.WriteLine(people.lastName);
                Console.WriteLine(people.gender);
                Console.WriteLine(people.birthDate);
                string number = PersonDL.changeNumber(people.customerNumber);
                Console.WriteLine(number + "\n");
                Console.WriteLine("Services Are :");

                for (int x = 0; x < people.services.Count; x++)
                {
                    Console.WriteLine(people.services[x]);
                }
                Console.WriteLine("\n");

            }

            public static void showPeople(hairdresser people, int i, string time)
            {

                Console.WriteLine("Person No:" + " " + i);
                Console.WriteLine("-----------\n");
                Console.WriteLine("Schedule is: " + time);
                Console.WriteLine(people.firstName);
                Console.WriteLine(people.lastName);
                Console.WriteLine(people.gender);
                Console.WriteLine(people.birthDate);
                string number = PersonDL.changeNumber(people.customerNumber);
                Console.WriteLine(number + "\n");
                for (int x = 0; x < people.services.Count; x++)
                {
                    if (people.services[x].ToUpper() == "TRIM")
                    {
                        Person.trim();
                    }
                    if (people.services[x].ToUpper() == "FULL CUT")
                    {
                        Person.fullCut();
                    }
                    if (people.services[x].ToUpper() == "DYE")
                    {
                        Person.dye();
                    }
                    if (people.services[x].ToUpper() == "BEARD TRIM")
                    {
                        Person.bearedTrim();
                    }
                }
                Console.WriteLine("\n");

            }
            public static void wrongInput()
            {
                Console.WriteLine("Wrong Input");
                Console.WriteLine("Press any Key to Go Back");
                Console.ReadKey();
            }
            public static void scheduleCompleted()
            {
                Console.WriteLine("Schdule Created");
                Console.WriteLine("Press any key to go Back :");
                Console.ReadKey();
                Console.Clear();
            }
            public static void goBack()
            {
                Console.WriteLine("\nPress any key to go back :");
                Console.ReadKey();
            }
            public static hairdresser getUserInput()
            {
                List<string> services = new List<string>();
                string firstName, lastName, gender, birthDate, customerNumber;
                header();
                Console.WriteLine("Enter your first name");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter your last name");
                lastName = Console.ReadLine();
                Console.WriteLine("Enter your gender");
                gender = Console.ReadLine();
                Console.WriteLine("Enter your date of birth");
                birthDate = Console.ReadLine();
                Console.WriteLine("Enter your customer number");
                customerNumber = Console.ReadLine();
                string option = "";
                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine("Enter the service : " + i);
                    string s = Console.ReadLine();
                    services.Add(s);
                    Console.WriteLine("Enter 0 to exit or press any key to continue");

                    if (option == "0")
                    {
                        break;
                    }
                }
                hairdresser p = new hairdresser(firstName, lastName, gender, birthDate, customerNumber, services);
                return p;
            }
            public static void addHairdressorInList()
            {

                for (int i = 0; i < PersonDL.people.Count; i++)
                {
                    if (PersonDL.people.Count != 8)
                    {
                        hairdresser p4 = getUserInput();
                        PersonDL.addPersonIntoList(p4);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, Cannot add more users for today");
                    }
                    break;
                }
            }
            public static string addUserOrMakeSched()
            {
                string option = "";
                Console.WriteLine("1: Add More Users ");
                Console.WriteLine("2: Make Schedule for the Users \n");
                Console.WriteLine("Enter your option :");
                option = Console.ReadLine();
                return option;
            }
            /// <summary>
            ///  The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                string option = "";
                List<string> services = new List<string>();
                string a = "Trim";
                string b = "Full Cut";
                string c = "Dye";
                services.Add(a);
                services.Add(b);
                services.Add(c);
                hairdresser p1 = new hairdresser("Honey", "Singh", "Male", "12-1-1995", "123452349", services);
                hairdresser p2 = new hairdresser("Tony", "Kakar", "Male", "28-8-1992", "134432489", services);
                hairdresser p3 = new hairdresser("Mahi", "Sing", "Male", "12-11-1998", "546456789", services);
                //Adding persong into the lists
                PersonDL.addPersonIntoList(p1);
                PersonDL.addPersonIntoList(p2);
                PersonDL.addPersonIntoList(p3);

                //Objects of the persons to be added as hardcore
                while (option != "4")
                {
                    //Print the main UI Menu
                    ProjectUI.Menu();
                    //Taking the Input from the user
                    option = Console.ReadLine();
                    if (option == "1")
                    {
                        ProjectUI.header();
                        ProjectUI.headerlistPeople();
                        PersonDL.showAllPeople();
                        ProjectUI.goBack();
                    }
                    else if (option == "2")
                    {

                        //Creatin Schedule Here
                        ProjectUI.header();
                        string op = ProjectUI.addUserOrMakeSched();
                        if (op == "1")
                        {
                            ProjectUI.header();
                            ProjectUI.addHairdressorInList();
                        }
                        else if (op == "2")
                        {
                            ProjectUI.header();
                            PersonDL.createAppointments();
                            ProjectUI.scheduleCompleted();
                        }
                        else
                        {
                            ProjectUI.wrongInput();
                        }

                    }
                    else if (option == "3")
                    {
                        ProjectUI.header();
                        AppointmentList.showAppointments();
                    }

                    else if (option == "4")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        ProjectUI.wrongInput();
                    }
                }
            }
        }
    }
}
