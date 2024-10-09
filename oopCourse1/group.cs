using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace oopCourse
{
    class group : IGroup
    {
        
        List<student> Group;
        public int name { get; set; }
        public string textFileOfGroup { get; set; } //файл со студентами
        public void groupList(List<student> GroupList)
        {
            Group = GroupList;
        }   //присваивание стписка студентов
        public List<student> setGroupList()
        {
            return Group;
        }   //передача студентов
        public int lengthGroupInt()
        {
            return Group.Count;
        }    //кол-во студентов в инте
        public void lengthGroup()
        {
            Console.WriteLine("Количество студентов в группе: {0}", lengthGroupInt());
        }    //кол-во студентов
        public void printGroupName() 
        {
            Console.WriteLine("Номер Группы: {0}", name);
        }  //номер группы
        public void printMembers()
        {
            int count = 1;
            Console.WriteLine("===========================================================================================================");
            foreach (student Student in Group)
            {
                Console.Write("{0}. ", count++);
                Student.printStudent();
                Console.WriteLine();

            }
            Console.WriteLine("===========================================================================================================");
        }    //вывод всех студентов в группе
        
    }
}
