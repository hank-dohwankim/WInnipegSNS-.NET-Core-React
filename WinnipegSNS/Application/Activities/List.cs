using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WinnipegSNS.Data;
using WinnipegSNS.Models;

namespace WinnipegSNS.Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly ApplicationDbContext _dbContext;

            public Handler(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _dbContext.Activities.ToListAsync();
                return activities;
            }
        }
    }
}
