using CQRS_MediatR.Cqrs.Queries;
using CQRS_MediatR.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatR.Cqrs.Handlers.QueryHandlers
{
    public class GetAllPeopleHandler : RequestHandler<GetAllPeopleQuery, IEnumerable<Person>>
    {
        private readonly FakeDataStore _db;
        public GetAllPeopleHandler(FakeDataStore db)
        {
            _db = db;
        }
        protected override IEnumerable<Person> Handle(GetAllPeopleQuery request)
        {
            return _db.GetAllPeople();
        }
    }

    //@@@@@@@@@@@@@@@@@@@@@@@@
    public class GetPersonHandler : RequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly FakeDataStore _db;
        public GetPersonHandler(FakeDataStore db)
        {
            _db = db;
        }

        protected override Person Handle(GetPersonByIdQuery request)
        {
            return _db.GetPersonById(request.id);
        }
    }

}
