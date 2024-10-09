using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace oopCourse
{
    interface IPerson   //интерфейс человек
    {
        string name { get; set; }   
        int age { get; set; }       
        void printPerson();

    }
}
  