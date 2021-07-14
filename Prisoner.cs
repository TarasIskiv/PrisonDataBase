using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrisonDataBaseWpfApp
{
    public class Prisoner
    {
        private int age;
        private string fullName;
        private string imagePath;

        public int Age { get => age; set => age = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }

        public int prisonerId { get; set;}

        public Prisoner(int age, string fullName, string path)
        {
            this.age = age;
            this.fullName = fullName;
            this.imagePath = path;
        }

        public Prisoner() { }

        public override string ToString()
        {
            return $"Id : {prisonerId}\tFull Name : {FullName}\tAge : {Age}";
        }
    }
}
