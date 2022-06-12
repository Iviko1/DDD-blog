using Application.UserProfiles.Queries;
using Dal;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.QueryHandlers
{
    internal class GetAllUserProfilesHandler : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _ctx;

        public GetAllUserProfilesHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.ToListAsync();
        }
    }
}
