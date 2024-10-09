using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace oopCourse
{
    class databaseForStudents : ILoading      //создаем список группы
    {
        List<student> StudentsOfGroup;
       
        string fileGroup;
        public databaseForStudents(List<student> StudentsList,string fileGroup)
        {
            StudentsOfGroup = StudentsList; //список студентов
            this.fileGroup = fileGroup;     //файл со студентами
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
            Console.WriteLine("Группа добавлена...");
        }
        public void createGroupOfStudents() //считывание файла
        {
            using (StreamReader reader = new StreamReader(fileGroup))   //файл для чтения
            {
                string line;
                while ((line = reader.ReadLine()) != null)  //считыванием строку
                {
                    string[] parts = line.Split(',');   //делим на части с помощью запятой
                    student student = new student   
                    {                                   //записываем студента из файла
                        name = parts[0],
                        group = int.Parse(parts[1]),
                        age = int.Parse(parts[2]),
                        idCard = int.Parse(parts[3]),
                        headgroup = bool.Parse(parts[4]),
                        grade=double.Parse(parts[5], CultureInfo.InvariantCulture), //конвертируем точку в запятую
                        numberExplanatory= int.Parse(parts[6])
                    };
                    StudentsOfGroup.Add(student);       //добавляем в список
                }
                reader.Close();
                load();
                loadSucsess();
            }
        }
        public void lengthGroup()
        {
            Console.WriteLine("Кол-во студентов в группе: {0}", StudentsOfGroup.Count);
        }   //вывод длины группы

        public int lengthGroupInt()
        {
            return StudentsOfGroup.Count;
        }   //вывод длины группы в инте
        public void printGroup()        //вывод студентов
        {
            int count = 1;
            foreach (student student in StudentsOfGroup)
            {
                Console.Write("{0}. ",count++); //порядковый номер
                student.printStudent();
                Console.WriteLine();
                
            }
        }

        
    }
}
