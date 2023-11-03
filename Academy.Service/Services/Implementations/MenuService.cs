using Academy.Core.Enums;
using Academy.Service.Services.Implementations;
using System;
using System.Collections.Generic;

namespace Academy.Service.Services.Implementations
{
    public class MenuService
    {
        IStudentService studentService = new StudentService();

        public async Task RunApp()
        {
            Console.ResetColor();
            await Menu();
            var key = Console.ReadKey();
          

            while (key.Key != ConsoleKey.D0)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        await CreateStudent();
                        break;
                    case ConsoleKey.D2:
                        await UpdateStudent();
                        break;
                    case ConsoleKey.D3:
                        await RemoveStudent();
                        break;
                    case ConsoleKey.D4:
                        await GetAllStudents();
                        break;
                    case ConsoleKey.D5:
                        await Get();
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        break;



                }

                await Menu();
                key = Console.ReadKey();
            }
        }

        async Task CreateStudent()
        {
            Console.WriteLine("           ");
            Console.WriteLine("Please add fullname");
            string Fullname = Console.ReadLine();
            Console.WriteLine("Please add group");
            string Group = Console.ReadLine();
            Console.WriteLine("Please add average");
            double.TryParse(Console.ReadLine(), out double Average);

            Console.WriteLine("Please choose a category");
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(EducationCategory)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;

            }

            bool DoesExist;
            int EnumIndex; 
            int count = 0;
            do
            {
                

                if (count >0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please add a valid edication category");
                   
                }
                int.TryParse(Console.ReadLine(), out EnumIndex);
                DoesExist = Enum.IsDefined(typeof(EducationCategory), (EducationCategory)EnumIndex);
                count++;
               
            } while (!DoesExist);
         

            string result = await studentService.CreateAsync(Fullname, Group, Average, (EducationCategory)EnumIndex);
            Console.WriteLine(result);
        }

        async Task UpdateStudent()
        {
            Console.WriteLine("           ");
            Console.WriteLine("Please add ID");
            string Id = Console.ReadLine();
            Console.WriteLine("Please add fullname");
            string Fullname = Console.ReadLine();
            Console.WriteLine("Please add group");
            string Group = Console.ReadLine();
            Console.WriteLine("Please add average");
            double.TryParse(Console.ReadLine(), out double Average);

            Console.WriteLine("Please choose a category");
            int i = 1;
            foreach (var item in Enum.GetValues(typeof(EducationCategory)))
            {
                Console.WriteLine($"{i}.{item}");
                i++;

            }

            bool DoesExist;
            int EnumIndex;
            do
            {
                Console.WriteLine("Please add a valid edication category");
                int.TryParse(Console.ReadLine(), out EnumIndex);
                DoesExist = Enum.IsDefined(typeof(EducationCategory), (EducationCategory)EnumIndex);
            } while (!DoesExist);

            string result = await studentService.UpdateAsync(Id, Fullname, Group, Average, (EducationCategory)EnumIndex);
            Console.WriteLine(result);
        }
        async Task RemoveStudent()
        {
            Console.WriteLine("           ");
            Console.WriteLine("Please add ID");
            string Id = Console.ReadLine();
            string result = await studentService.RemoveAsync(Id);
            Console.WriteLine(result);

        }

        async Task GetAllStudents()
        {
            Console.WriteLine("           ");
            await studentService.GetAllAsync();
        }
        async Task Get()
        {
            Console.WriteLine("           ");
            Console.WriteLine("Please add ID");
            string Id = Console.ReadLine();
            string result = await studentService.GetAsync(Id);
            Console.WriteLine(result);

        }


        async Task Menu()
        {

            Console.ResetColor();
            Console.WriteLine("1. Create a student");
            Console.WriteLine("2. Update student's information");
            Console.WriteLine("3. Remove a student");
            Console.WriteLine("4. Get all students");
            Console.WriteLine("5. Get a specific student");
            Console.WriteLine("0. Quit");
        }

    }
}
