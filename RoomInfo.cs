using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSANamePlate
{
    public class RoomInfo
    {
        public readonly Student Std1;
        public readonly Student Std2;

        public RoomInfo(Student std1, Student std2)
        {
            Std1 = std1; Std2 = std2;
        }

        public static List<RoomInfo> ParseFile(string path)
        {
            List<RoomInfo> list = new List<RoomInfo>();
            string[] data = File.ReadAllLines(path, Encoding.UTF8);
            foreach (string s in data)
            {
                string[] dt = s.Trim().Split(',');
                if (dt.Length != 2) return null;

                Student std1 = new Student(dt[0]), std2 = new Student(dt[1]);
                if (std1 == null || std2 == null) return null;
                list.Add(new RoomInfo(std1, std2));
            }
            return list;
        }
    }
}
