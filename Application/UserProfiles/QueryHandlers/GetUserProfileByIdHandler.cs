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
    internal class GetUserProfileByIdHandler : IRequestHandler<GetUserProfileById, UserProfile>
    {
        private readonly DataContext _ctx;

        public GetUserProfileByIdHandler(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<UserProfile> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);
        }
    }
}
