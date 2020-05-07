using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WinnipegSNS.Data;
using WinnipegSNS.Models;

namespace WinnipegSNS.Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Descr { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _db;
            public Handler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = new Activity
                {
                    Id = request.Id,
                    Title = request.Title,
                    Descr = request.Descr,
                    Category = request.Category,
                    Date = request.Date,
                    City = request.City,
                    Street = request.Street
                };
                _db.Activities.Add(activity);
                var success = await _db.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
