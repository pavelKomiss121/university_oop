using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopCourse
{
    class GroupMenu
    {

        dekanatFunctions groupList;
        
        public GroupMenu(dekanatFunctions groupList)       //конструктор
        { 
            this.groupList = groupList;
        }
        

        public void menu(List<student> students)
        {
            
            int choiceInt;
            string choiceStr;
            
            
            do                      //меню
            {
                try
                {
                    Console.WriteLine("===========================================================================================================");
                    Console.WriteLine("Доступные действия: ");
                    Console.WriteLine("===========================================================================================================");
                    Console.WriteLine("1. Вывести численность группы");
                    Console.WriteLine("2. Вывести группу на экран");
                    Console.WriteLine("3. Вывести средний балл группы");
                    Console.WriteLine("4. Вывести неуспевающих студентов");
                    Console.WriteLine("5. Исключить студента");
                    Console.WriteLine("6. Вывести старосту группы");
                    Console.WriteLine("7. Написать объяснительную");
                    Console.WriteLine("8. Отчислить всех неуспевающих студентов");
                    Console.WriteLine();
                    Console.WriteLine("0. Вернуться к списку групп");
                    Console.WriteLine("===========================================================================================================");
                    choiceInt = int.Parse(Console.ReadLine());
                    Console.WriteLine("===========================================================================================================");
                    Console.WriteLine();
                }
                catch
                {
                    Console.WriteLine("Введено не число! Попробуйте снова");

                    choiceInt = -1;
                };
                switch (choiceInt)
                {
                    case 1:     //численность группы
                        groupList.lengthGroup();
                        Console.WriteLine();
                        break;

                    case 2:     //вывод студентов на экран
                        groupList.printStudents();
                        break;

                    case 3: //подсчет среднего балла
                        double summ=groupList.averageGrade();
                        Console.Write("Средний балл по группе: {0}", summ);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                    case 4:     //список неуспевающих студентов
                        groupList.underachieversStudents();
                        break;
                    case 5:     //отсчисление
                        groupList.printStudents();  //вывод списка студентов для выбора
                        do
                        {
                            Console.Write("Введите номер студента, которого нужно исключить: ");
                           
                            try         //ввод с проверками
                            {
                                choiceInt = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Введено не число! Попробуйте снова");
                                choiceInt = -1;
                            }
                            if (choiceInt > groupList.lengthGroupInt() || choiceInt < 1)
                            {
                                Console.WriteLine("Ошибка ввода! Попробуйте снова");
                            }
                        } while (choiceInt > groupList.lengthGroupInt() || choiceInt < 1) ;
                        Console.Write("Вы уверены? Напишите yes если да: ");
                        choiceStr = Console.ReadLine(); //подтверждение выбора
                        if (choiceStr == "yes")
                        {
                            groupList.load();       //загрузка
                            groupList.removePerson(choiceInt);  //удаление
                        }
                        break;
                    case 6:     //проерка наличия старосты(+добавление)
                        groupList.CheckMonitorInGroup();
                        break;
                    case 7:     //принести объяснительную
                        int number = 0;
                        groupList.printStudents();  //вывод списка студентов для выбора
                        do {        //выбор с проверками
                            Console.Write("Напишите номер студента, который должен принести объяснительную: ");
                            try
                            {
                                number = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                               Console.WriteLine("Введено не число! Попробуйте снова");
                                number = -1;
                            }
                            if(number > groupList.lengthGroupInt() || number < 1)
                            {
                                Console.WriteLine("Ошибка ввода! Попробуйте снова");
                            }
                        } while (number > groupList.lengthGroupInt() || number < 1) ;
                        groupList.load();   //загрузка
                        groupList.addExplanatory(number-1);
                        break;
                    case 8:     //отсчисление всех неуспевающих
                        groupList.removeUnderachieversStudents();
                        break;
                    case 0:
                        
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет! Попробуйте снова");
                        Console.WriteLine();
                        break;
                }
            } while (choiceInt!=0);
        }

        
    }
}
