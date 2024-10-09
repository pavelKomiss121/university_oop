using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace oopCourse
{
    class dekanatFunctions : Dekanat, ILoading
    {
        List<student> StudentsGroup;
        group Group;
        public dekanatFunctions(group Group)
        {
            this.Group = Group;
        }
        public void getGroupList()
        {
            StudentsGroup=Group.setGroupList();
        }   //присваивание стписка студентов
        public double averageGrade()
        {
            double summ = 0;
            foreach (student Student in StudentsGroup)
            {
                summ += Student.grade;

            }
            return summ / StudentsGroup.Count();
        }   //средний балл всей группы
        public void CheckMonitorInGroup()
        {

            Console.WriteLine("   Староста группы:");

            int count = 1;
            foreach (student Student in StudentsGroup)
            {
                if (Student.headgroup)
                {
                    Console.Write("{0}. ", count++);
                    Student.printPerson();
                    Console.WriteLine();
                }
            }
            if (count == 1)     //если старосты нет, предложение назначить
            {
                string choice;

                Console.Write("Старосты нет!\n\nНазначить нового старосту?\nНапишите yes, если нужно: ");
                choice = Console.ReadLine();
                Console.WriteLine();
                if (choice == "yes")
                {
                    Random rand = new Random();
                    int random = rand.Next(0, Group.lengthGroupInt());
                    setMonitor(random);
                }
            }
        }   //проверка на наличие старосты(+добавление)

        public void removeUnderachieversStudents()  //удадение всех неуспевающих студентов
        {
            underachieversStudents();   //список неуспевающих
            int count = 0;
            List<int> indexForRemove = new List<int>(); //список, в котором хранятся индексы неуспевающих студентов
            foreach (student Student in StudentsGroup)      //поиск студентов
            {
                count++;
                if (Student.grade < 3.0)
                {
                    Console.WriteLine("Отчисление студента {0}, средний балл студента: {1} ", Student.name, Student.grade);
                    load();
                    Console.WriteLine();
                    count--;
                }
            }
            foreach (int index in indexForRemove)   //удаление
            {
                removePerson(index);
            }
            indexForRemove.Clear();
        }

        public override void addExplanatory(int student)
        {
            Console.WriteLine("Студент {0} принес(ла) объяснительную за пропуск пары", StudentsGroup[student].name);
            StudentsGroup[student].numberExplanatory += 1;
            Console.WriteLine("Кол-во объяснительных у студента: {0}", StudentsGroup[student].numberExplanatory);
        }   //объяснительная

        public override void removePerson(int number)   //отчисление студента
        {
            StudentsGroup.RemoveAt(number - 1); //удаляем из списка
            FileStream fileStream = File.Open(Group.textFileOfGroup, FileMode.Open);
            fileStream.SetLength(0);    //отчистка файла
            fileStream.Close();

            using (StreamWriter writer = new StreamWriter(Group.textFileOfGroup)) //переписываем файл
            {
                foreach (student student in StudentsGroup)
                {
                    writer.WriteLine($"{student.name},{student.group},{student.age},{student.idCard},{student.headgroup},{student.grade},{student.numberExplanatory}");
                }
            }
        }
        public void load()
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("...");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("...");
            System.Threading.Thread.Sleep(500);
        }   //имитация загрузки
        public void loadSucsess() 
        { 
            Console.WriteLine("Готово!"); 
        }
        public override void underachieversStudents()
        {
            Console.WriteLine("Список неуспевающих студентов:");

            int count = 1;
            foreach (student Student in StudentsGroup)
            {
                if (Student.grade < 3.0)
                {
                    Console.Write("{0}. ", count++);
                    Student.printStudent();
                    Console.WriteLine();
                }
            }
            if (count == 1) { Console.WriteLine("Неуспевающих нет"); Console.WriteLine(); } //если никого не вывели, то все хорошо учатся
        }   //неуспевающие студенты (србалл<3)
        public override void setMonitor(int index)
        {
            load();
            StudentsGroup[index].headgroup = true;  //отмечаем старосту
            Console.WriteLine("   Новый староста группы {0}", Group.name);

            Console.Write("{0}. ", 1);
            StudentsGroup[index].printStudent();
            Console.WriteLine();
        }   //назначить старосту (случайным образом)
        public void printStudents()
        {
            Group.printMembers();
        }    //вывод всех студентов в группе
        public void lengthGroup()
        {
            Group.lengthGroup();
        }    //кол-во студентов
        public int lengthGroupInt()
        {
            return Group.lengthGroupInt();
        }    //кол-во студентов в инте

    }
}
