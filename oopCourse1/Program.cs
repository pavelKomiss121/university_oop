using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace oopCourse
{
    class Program : ILoading
    {
        public void load()
        {
            Console.WriteLine("загрузка...");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("...");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("...");
            System.Threading.Thread.Sleep(500);
        }       //функция для имитации загрузки
        public void loadSucsess()
        {
            Console.WriteLine("Загрузка завершена");
        }
       
         static void Main(string[] args)
        {
            
            List<group> groups = new List<group>();                 //список групп(название группы+текст файл)
            List<student> studentsInGroup2322 = new List<student>(); //список студентов группы 2322
            List<student> studentsInGroup2117 = new List<student>(); //список студентов группы 2117

            databaseForGroups DataGroups = new databaseForGroups(groups);   //база для групп (считывание файла)
            
            Console.WriteLine();
            Console.WriteLine("\t\t\tДобро пожаловать в программу, обеспечивающую работу деканата");
            Console.WriteLine("\tПервым делом необходимо заполнить базу групп, считывание осуществляется из текстового документа 'group.txt'");
            Console.WriteLine();
            int choiceInt;
            string choiceStr;
            bool choiceBool = false;

            do                                                      //меню для считывания из файла
            {
                try
                {
                    Console.WriteLine("Доступные действия: ");
                    Console.WriteLine("===========================================================================================================");
                    Console.WriteLine("1. Считать файл групп");
                    Console.WriteLine("0. Выйти из программы");
                    Console.WriteLine("===========================================================================================================");
                    choiceInt = int.Parse(Console.ReadLine());
                }
                catch 
                {
                    Console.WriteLine("Введено не число! Попробуйте снова");
                    choiceInt = -1; 
                };
                switch (choiceInt)
                {
                    case 1:
                        DataGroups.createGroupsList();
                        choiceBool = true;
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет! Попробуйте снова");
                        Console.WriteLine();
                        break;
                }
            } while (!choiceBool);      //проверки на ввод
            choiceBool = false;
           
            
            databaseForStudents DataStudents2322 = new databaseForStudents(studentsInGroup2322, groups[0].textFileOfGroup); //создание базы для студентов группы 2322
            databaseForStudents DataStudents2117 = new databaseForStudents(studentsInGroup2117, groups[1].textFileOfGroup); //создание базы для студентов группы 2117

            Console.WriteLine("===========================================================================================================");
            Console.WriteLine("Формируем списки групп, подождите... ");
            


            DataStudents2322.createGroupOfStudents();   //создание списков студентов
            groups[0].groupList(studentsInGroup2322);   //присваивание группе списка студентов
            DataStudents2117.createGroupOfStudents();
            groups[1].groupList(studentsInGroup2117);

            Console.WriteLine();
            Console.WriteLine("Студенты добавлены в списки, спасибо за ожидание");
            Console.WriteLine("===========================================================================================================");
            Console.WriteLine();
           
            GroupMenu menuGroup;            //класс, где находится меню
            do
            {
                Console.WriteLine("===========================================================================================================");
                Console.WriteLine("Доступные группы: ");
                DataGroups.printGroupList();        //вывод списка групп
                Console.WriteLine("===========================================================================================================");
                Console.WriteLine("Чтобы выйти из программы, нажмите 0 ");
                Console.Write("Выберите группу(ее порядковый номер): ");
                try
                {
                    choiceInt = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введено не число! Попробуйте снова");
                    choiceInt = -1;
                };
                
                switch (choiceInt)      //выбор группы для работы с ней
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Выбрана группа {0}", groups[0].name);
                        dekanatFunctions groupList1 = new dekanatFunctions(groups[0]);  //создание объекта класса для работы с группой
                        groupList1.getGroupList();//присваивание студентов
                        menuGroup = new GroupMenu(groupList1);  //генерация меню для работы деканата
                        menuGroup.menu(studentsInGroup2322);
                        
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Выбрана группа {0}", groups[1].name);
                        dekanatFunctions groupList2 = new dekanatFunctions(groups[1]);
                        groupList2.getGroupList();//присваивание студентов
                        menuGroup = new GroupMenu(groupList2);
                        menuGroup.menu(studentsInGroup2117);
                        
                        break;
                    case 0:
                        choiceBool = true;
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет! Попробуйте снова");
                        Console.WriteLine();
                        break;
                }
            } while (!choiceBool);
            choiceBool = false;
            Console.WriteLine();
            Console.WriteLine("Для завершения программы нажмите любую клавишу...");
            Console.Read(); 
        }
    
    }
}
