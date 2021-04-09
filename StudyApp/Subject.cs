using System;
using System.Collections.Generic;
using System.Text;

namespace StudyApp
{
    class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int count = 0;
        public Subject(string name)
        {
            Subject.count++;
            Id = Subject.count;
            Name = name;
        }
    }
}
