﻿using System.Collections.Generic;

namespace WebStore.Models
{
    public class Employee
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public List<string> Hobbies { get; set; }
    }
}
