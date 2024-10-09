using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopCourse
{
    interface IGroup
    {
        void printMembers();        //вывести участников группы
        void lengthGroup();         //длина группы
        void printGroupName();      //вывод названия группы
        int name { get; set; }      //имя группы
    }
}
