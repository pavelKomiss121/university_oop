using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopCourse
{
    class student :studentAb
    {
        public override string name { get; set; }
        public override int idCard { get; set; }    //студенческий билет
        public override int age { get; set; }
        public override int group { get; set; }
        public int numberExplanatory { get; set; }  //кол-во объяснительных
        public override void printStudent()     //вывод информации о студенте
        {
            if (group != 0)
            {
                Console.WriteLine("Студент группы: {0}", group);
            }
            printPerson();
            Console.WriteLine("   Номер студ. билета: {0}", idCard);
            Console.WriteLine("   Средний балл за зачетную неделю: {0}", grade);
            Console.WriteLine("   Кол-во объяснительных: {0}", numberExplanatory);
            if (headgroup == true) Console.WriteLine("   Студент является старостой группы");


        }


    }
}
