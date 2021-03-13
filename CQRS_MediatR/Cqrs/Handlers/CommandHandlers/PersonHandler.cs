
using CQRS_MediatR.Cqrs.Commands;
using CQRS_MediatR.Models;

using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatR.Cqrs.Handlers.CommandHandlers
{
    public class AddPersonHandler : RequestHandler<AddPersonCommand,int>
    {
        private readonly FakeDataStore _db;
        public AddPersonHandler(FakeDataStore db)
        {
            _db = db;
        }

        protected override int Handle(AddPersonCommand request)
        {
            return _db.AddPerson(request);
        }

    }

    //####################
    public class UpdatePersonHandler : RequestHandler<UpdatePersonCommand, Person>
    {
        private readonly FakeDataStore _db;
        public UpdatePersonHandler(FakeDataStore db)
        {
            _db = db;
        }

        protected override  Person Handle(UpdatePersonCommand request)
        {
            return _db.Update(request);
        }

    }
    //####################

    public class DeletePersonHandler : RequestHandler<DeletePersonCommand,IEnumerable<Person>>
    {
        private readonly FakeDataStore _db;
        public DeletePersonHandler(FakeDataStore db)
        {
            _db = db;
        }

        protected override IEnumerable<Person> Handle(DeletePersonCommand request)
        {
            return _db.DeletPersonById(request.Id);
        }

    }
    //####################
}
