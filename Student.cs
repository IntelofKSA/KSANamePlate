using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSANamePlate
{
    public class Student
    {
        public readonly string ID;
        public readonly string Name;

        public Student(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public Student(string str)
        {
            string[] data = str.Trim().Split(' ');
            if (data.Length != 2) return;
            ID = data[0];
            Name = data[1];
        }
    }
}
