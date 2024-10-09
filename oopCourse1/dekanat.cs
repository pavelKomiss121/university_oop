using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopCourse
{
    public abstract class Dekanat 
    {
        abstract public void setMonitor(int index); //назначить старосту
        abstract public void removePerson(int index);//отчислить студента
        abstract public void underachieversStudents();//список неуспевающих
        abstract public void addExplanatory(int index);//заставить писать объяснительную
    }
}
