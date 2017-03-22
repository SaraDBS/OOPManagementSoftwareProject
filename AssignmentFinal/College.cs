//Sara Silva
//Student number: 1669329


using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFinal

{
    public class College  //The college class is the entry point to the programme.
    {
        public static People people = new People(); //Creating list object from People class which extends ICollection
        static void Main(string[] args)
        {
            //declaring variables
            int choice;
            bool backToMenu = true;

            try // Wrapping code in a try/catch block to handle exceptions.
            {
                //Creating student objects and adding them to the list.

                Student student1 = new Student("1234567a", "Ryan Murphy", "45 Nothing Hill","234-5678", "ryan@mail.com", 22344, StudentStatus.undergraduate);
                Student student2 = new Student("2345767b", "Julie Holmes", "76 Wilston Church", "234-6587", "julie@mail.com", 34566, StudentStatus.postgraduate);
                Student student3 = new Student("3456789c","Nicole Smith","43 Holland Street","234-8593","nicole@mail.com",45988,StudentStatus.undergraduate);
                people.Add(student1);
                people.Add(student2);
                people.Add(student3);

                //Creating arrays which will store the subjects taught by each lecturer. Creating Lecturer objects.
                string[] array1 = { "programming", "web design" };
                Lecturer lecturer1 = new Lecturer("2345678b", "Seamus Finn", "67 Wolfe Tone St", "234-6789", "seamus@mail.com", 22448, 45000, array1);
                string[] array2 = { "information management", "database development" };
                Lecturer lecturer2 = new Lecturer("4567882c","Brian Halford","35 Castleview","234-9845","brian@mail.com",23644,48000,array2);
                string[] array3 = { "Operating Systems", "Networking","Cloud Computing" };
                Lecturer lecturer3 = new Lecturer("5678901d","Ailish Hilton","41 Campus Road","234-8765","ailish@mail.com",22455,43000,array3);

                //Adding lecturer objects to the list
                people.Add(lecturer1);
                people.Add(lecturer2);
                people.Add(lecturer3);

                Console.WriteLine("Welcome to DBS database system!");

                do
                {
                    //menu to be displayed to the user

                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Press:");
                    Console.WriteLine("1. To add a student");
                    Console.WriteLine("2. To add a lecturer");
                    Console.WriteLine("3. To search for a student by name ");
                    Console.WriteLine("4. To search for a lecturer by name ");
                    Console.WriteLine("5. To search for a student by Id ");
                    Console.WriteLine("6. To search for a lecturer by Id");
                    Console.WriteLine("7. Show details for all students");
                    Console.WriteLine("8. Show names of all lecturers");
                    Console.WriteLine("9. To Quit");
                    Console.WriteLine("--------------------------------------");
                    int.TryParse(Console.ReadLine(), out choice);

                    switch (choice)  // Switch statement for options
                    {

                        case 1:
                            AddStudent();  // Calling addStudent method which adds the student to the person list.
                            break;
                        case 2:
                            AddLecturer();  // Calling addLecturer method which adds the lecturer to the person list.
                            break;
                        case 3:
                            Console.WriteLine("Please enter student name: ");   
                            string StudentName = Console.ReadLine();
                            if (people.Contains(StudentName))   //Calling the contains method to check if name property is in the list.
                            {
                                if (people.Where(i => i.Name == StudentName).FirstOrDefault() is Student) //lambda expression to determine if name found belongs to a student
                                {
                                         Console.WriteLine("Student found\n"); //Output if list contains name and it belongs to a student.
                                         Console.WriteLine(people.Where(i => i.Name == StudentName).FirstOrDefault());
                                } 
                            else
                            {
                                Console.WriteLine("{0} is not a student",StudentName); //Output if the list contains the name property but it doesnt belong to a student. 
                            }
                            }
                            
                            else
                            {
                                Console.WriteLine("Student not found"); //Output if the list does not contain the name input by the user.
                            }
                            
                            break;
                        case 4:
                            Console.WriteLine("Please enter lecturer name: "); //Here same process is repeated now for lecturer.
                            string LecturerName = Console.ReadLine();
                           
                                if (people.Contains(LecturerName))
                                {   //Checking if the list contains name property.
                                    if (people.Where(i => i.Name == LecturerName).FirstOrDefault() is Lecturer) //Checking if name property belongs to a lecturer.
                                    {
                                        Console.WriteLine("Lecturer found\n"); //Ouput if list contains name and it belongs to a lecturer.
                                        Console.WriteLine(people.Where(i => i.Name == LecturerName).FirstOrDefault());
                                    }
                                    else
                                    {
                                        Console.WriteLine("{0} is not a lecturer", LecturerName); //Output if name property is in the list but does not belong to a lecturer.
                                    }
                                }

                                else
                                {
                                    Console.WriteLine("Lecturer not found"); //Output if the list does not contain the name input by user.
                                }
                                 
                            break;
                        case 5:
                            Console.WriteLine("Please enter student number: ");
                            int studentNumber = int.Parse(Console.ReadLine());
                            bool studentFound = false;
                            foreach (Person p in people) 
                            {
                                if (p is Student) //Iterating through the list and checking for students.
                                {

                                    var a = ((Student)p).StudentId; //Each time a student is found in the list we check its id against the student number input by the user.
                                    if (a == studentNumber)
                                    {
                                        studentFound = true;
                                        Console.WriteLine("Student found"); //Output if input is an id that belongs to a student. We call Show info method to display student name.
                                        Console.WriteLine(p.ShowInfo()); //We call Show info method to display student name.
                                        break;
                                    }
                                }
                            }

                            if (!studentFound)
                            {
                                Console.WriteLine("Student not found"); //Output if id is not found or it does not belong to a student.
                            }


                            break;
                            
                        case 6:
                            Console.WriteLine("Please enter lecturer Id: ");
                            int lecturerid = int.Parse(Console.ReadLine());
                            bool lecturerFound = false;
                            foreach (Person p in people)
                            {
                               
                                if (p is Lecturer)   //Iterating through the list and checking for lecturers.
                                {

                                    var a = ((Lecturer)p).StaffId;   //Each time a lecturer is found in the list we check its id against the lecturer id input by the user.
                                    if (a == lecturerid)
                                    {
                                        lecturerFound = true;
                                        Console.WriteLine("Lecturer found"); //Output if input is an id that belongs to a lecturer. We call Show info method to display lecturer name.
                                        Console.WriteLine(p.ShowInfo()); //We call Show info method to display lecturer name.
                                        break;
                                    }
                               }
                            }

                            if (!lecturerFound)
                            {
                                Console.WriteLine("Lecturer not found"); //Output if id is not found or it does not belong to a lecturer.
                            }

                               
                            break;

                        case 7:
                            ShowStudentDetails();  //Calling method to display all students details.
                            break;
                        case 8:
                            ShowLecturerNames();  //Calling method to display all lecturers names.
                            break;
                        case 9:
                            backToMenu = false; //Quit option
                            break;
                        default:
                            Console.WriteLine("Invalid option selected"); //In case number input by the user is invalid according to the menu.
                            break;

                    }

                } while (backToMenu);
            }

            //Catch blocks to handle possible exceptions.
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
                Console.Read();
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }

        //AddStudent method

        public static void AddStudent()
        {
            Student student = new Student();
            Console.WriteLine("Enter PPS number: ");
            student.PPSN = Console.ReadLine();
            Console.WriteLine("Enter name: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter address:");
            student.Address = Console.ReadLine();
            Console.WriteLine("Enter phone number: ");
            student.Phone = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            student.Email = Console.ReadLine();
            Console.WriteLine("Enter Student Id: ");
            student.StudentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter student status: ");
            student.Status = (StudentStatus)Enum.Parse(typeof(StudentStatus), Console.ReadLine()); //Parsing and Casting Enum student status input from user
            people.Add(student);
           
        }

        //AddLecturer method

        public static void AddLecturer() {

            Lecturer lecturer = new Lecturer();
            Console.WriteLine("Enter PPS number: ");
            lecturer.PPSN = Console.ReadLine();
            Console.WriteLine("Enter name: ");
            lecturer.Name = Console.ReadLine();
            Console.WriteLine("Enter address:");
            lecturer.Address = Console.ReadLine();
            Console.WriteLine("Enter phone number: ");
            lecturer.Phone = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            lecturer.Email = Console.ReadLine();
            Console.WriteLine("Enter Staff Id: ");
            lecturer.StaffId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter salary: ");
            lecturer.Salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("How many subjects does this lecturer teach: ");
            int length = int.Parse(Console.ReadLine());
            string[] SubjectsTaught = new string[length];   //Creating array to store subjects taught
            for(int i = 0; i< SubjectsTaught.Length; i++)  //For loop to store a lecturer's subjects taught as an array of strings.
            {
                Console.WriteLine("Enter subject: ");
                SubjectsTaught[i] = Console.ReadLine();
            
            }
            lecturer.SubjectsTaught = SubjectsTaught;
            people.Add(lecturer);


        }

        //ShowStudentDetails method

        static void ShowStudentDetails()
        {
            people.SortByName();   
            foreach (Person p in people)
            {   
              if (p is Student)
              Console.WriteLine(p+"\n");
              
            }
        }

        //ShowLecturerNames method

        static void ShowLecturerNames() {

            people.SortByName();  //Sorting lecturer names before outputting them to the screen.
            foreach (Person p in people)
           {
               if (p is Lecturer)
               Console.WriteLine(p.Name);
             
               
           }
        }
    }
}
