using StudentRecords;
using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        MyList<Student> studentList = new MyList<Student>();
        int choice = 0;
        //Testing Add method
        studentList.Add(new Student { Id = 1, Name = "Alice", GPA = 3.8 });
        studentList.Add(new Student { Id = 2, Name = "Bob", GPA = 3.5 });
        studentList.Add(new Student { Id = 3, Name = "Charlie", GPA = 3.9 });

        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Display All Students");
        Console.WriteLine("3. Insert Student at Position");
        Console.WriteLine("4. Remove first instance");
        Console.WriteLine("5. Remove at Index");
        Console.WriteLine("6. Sort Students by GPA");
        Console.WriteLine("0. Exit");

        Console.WriteLine(studentList[-1]);
        do
        {
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    { 
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter GPA: ");
                        double gpa = double.Parse(Console.ReadLine());
                        studentList.Add(new Student { Id = id, Name = name, GPA = gpa });
                        break;
                    }  

                case 2:
                    studentList.DisplayAll();
                    break;

                case 3:
                    {
                        Console.Write("Enter Position: ");
                        int pos = int.Parse(Console.ReadLine());
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter GPA: ");
                        double gpa = double.Parse(Console.ReadLine());
                        studentList.Insert(pos, new Student { Id = id, Name = name, GPA = gpa });
                        break;
                    }

                case 4:
                    {
                        Console.Write("Enter ID to remove: ");
                        int id = int.Parse(Console.ReadLine());
                        Student toRemove = null;

                        for (int i = 0; i < studentList.Count; i++)
                        {
                            if (studentList.Get(i).Id == id)
                            {
                                toRemove = studentList.Get(i);
                                break;
                            }
                        }

                        if (toRemove != null && studentList.Remove(toRemove))
                            Console.WriteLine("Student removed.");
                        else
                            Console.WriteLine("Student not found.");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Enter index to remove: ");
                        int index = int.Parse(Console.ReadLine());
                        if (index >= 0 && index < studentList.Count)
                        {
                            studentList.RemoveAt(index);
                            Console.WriteLine("Student removed.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }

                        break;
                    }
                case 6:
                    {
                        studentList.Sort();
                        Console.WriteLine("Students sorted by GPA.");
                        break;
                    }
            }
        } while (choice != 0);

    }
   
}
