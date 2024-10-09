using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopCourse
{
    abstract class studentAb : IPerson
    {
       abstract public string name { get; set; }
       abstract public int idCard { get; set; }     //студак
       abstract public int age { get; set; }
       abstract public int group { get; set; }
       public double grade { get; set; }   //успеапемость
       public bool headgroup { get; set; }          //является ли старостой
        public void printPerson()       //вывод информации о человеке
        {
            Console.WriteLine("   ФИО: {0}", name);
            Console.WriteLine("   Возраст: {0}", age);
        }

        abstract public void printStudent();
    }
}
