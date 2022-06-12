using Api.Contracts.UserProfile.Requests;
using Api.Contracts.UserProfile.Responses;
using Application.UserProfiles.Commands;
using AutoMapper;
using Domain.Aggregates.UserProfileAggregate;

namespace Api.MappingProfiles
{
    public class UserProfileMappings : Profile
    {
        public UserProfileMappings()
        {
            CreateMap<UserProfileCreateUpdate, CreateUserCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInfoResponse>();
            CreateMap<UserProfileCreateUpdate, UpdateUserProfileBasicInfoCommand>();
        }
    }
}
