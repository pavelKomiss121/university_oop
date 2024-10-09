using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace oopCourse
{
    class databaseForGroups  : ILoading   //создаем список групп
    {
        List<group> GroupsList;
        public databaseForGroups(List<group> GroupsList)   
        {
            this.GroupsList = GroupsList;   //список групп (названия+файлы)
        }

        public void createGroupsList()      //считывание
        {
            using (StreamReader reader = new StreamReader("group.txt"))
            {

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    group Group = new group
                    {
                        name = int.Parse(parts[0]),
                        textFileOfGroup = parts[1]

                    };
                    GroupsList.Add(Group);
                }
            }
            load();
            loadSucsess();
            Console.WriteLine();
            Console.WriteLine("===========================================================================================================");
            Console.WriteLine("База успешно считалась! Вывести название групп и их файлы?");
            Console.Write("Введите yes, если нужно показать: ");
            string choiceStr = Console.ReadLine();

            Console.WriteLine("===========================================================================================================");
            Console.WriteLine();
            if (choiceStr == "yes")     //вывод списка групп с их текст документами
            {

                printGroupListWithText();

            }
            Console.WriteLine("===========================================================================================================");
        }

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

        public void printGroupWithText(int number)  //вывод одной группы с текст файлом
        {
            Console.WriteLine("Номер Группы: {0}", GroupsList[number].name);
            Console.WriteLine("   Тектовый файл для группы: {0}", GroupsList[number].textFileOfGroup);

        }
        public void printGroup(int number)
        {
            Console.WriteLine("Номер Группы: {0}", GroupsList[number].name);
        } //вывод одной группы
        public int lengthGroupList()
        {
            return GroupsList.Count;
        } //кол-во групп
        public void updateGroupsList()
        {
            GroupsList.Clear();
            createGroupsList();
        }   //обновить списки групп
        public void printGroupListWithText()    //вывод групп с текст файлами
        {
            int count = 1;
            foreach (group Groups in GroupsList)
            {
                Console.Write("{0}. ", count);
                printGroupWithText(count-1);
                count++;
                Console.WriteLine();
            }
        }
        public void printGroupList()
        {
            int count = 1;
            foreach (group Groups in GroupsList)
            {
                Console.Write("{0}. ", count++);
                Groups.printGroupName();
                Console.WriteLine();
            }
        }//вывод групп
    }
}
