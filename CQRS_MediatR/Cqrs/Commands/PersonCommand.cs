using CQRS_MediatR.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatR.Cqrs.Commands
{
    public class AddPersonCommand:IRequest<int>   
    {
        public string Name { get; set; }
        public int Age { get; set; }        
    }

    public class UpdatePersonCommand : IRequest<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Id { get; set; }
    }

    public class DeletePersonCommand : IRequest<IEnumerable<Person>>
    {
        public int Id { get; set; }
    }

}
