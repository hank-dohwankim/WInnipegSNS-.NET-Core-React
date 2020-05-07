using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
            private readonly Data.ApplicationDbContext _dbContext;
            private readonly ILogger<List> _logger;

            public Handler(Data.ApplicationDbContext dbContext, ILogger<List> logger)
            {
                _dbContext = dbContext;
                _logger = logger;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    for(var i=0; i<10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");
                    }
                }
                catch (Exception ex) when (ex is TaskCanceledException)
                {
                    _logger.LogInformation("Task was cancellled");
                }

                var activities = await _dbContext.Activities.ToListAsync();
                return activities;
            }
        }
    }
}
