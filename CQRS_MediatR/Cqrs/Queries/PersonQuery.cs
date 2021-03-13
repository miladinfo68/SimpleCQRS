using CQRS_MediatR.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatR.Cqrs.Queries
{
    public class GetAllPeopleQuery : IRequest<IEnumerable<Person>> 
    {

    }
    public class GetPersonByIdQuery : IRequest<Person>
    {
        internal int id { get; set; } 
        public GetPersonByIdQuery(int _id) => id = _id;        
    }

    public class DeltePersonByIdQuery : IRequest<IEnumerable<Person>>
    {
        internal int id { get; set; }
        public DeltePersonByIdQuery(int _id) => id = _id;
    }
}
