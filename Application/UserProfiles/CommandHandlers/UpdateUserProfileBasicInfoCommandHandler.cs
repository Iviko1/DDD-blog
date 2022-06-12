using Application.UserProfiles.Commands;
using Dal;
using Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfileBasicInfoCommandHandler : IRequestHandler<UpdateUserProfileBasicInfoCommand>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfileBasicInfoCommandHandler(DataContext cxt)
        {
            _ctx = cxt;
        }

        public async Task<Unit> Handle(UpdateUserProfileBasicInfoCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _ctx.UserProfiles.FirstOrDefaultAsync(x => x.UserProfileId == request.UserProfileId);
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);
            userProfile.UpdateBasicInfo(basicInfo);

            _ctx.UserProfiles.Update(userProfile);
            
            await _ctx.SaveChangesAsync();

            return new Unit();
        }
    }
}
