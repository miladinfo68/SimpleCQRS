using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MediatR.Models
{
    public class Person
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
