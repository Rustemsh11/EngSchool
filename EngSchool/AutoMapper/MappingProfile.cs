using AutoMapper;
using EngSchool.Entities.Models;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;

namespace EngSchool.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<Position, PositionDto>();
            CreateMap<Entities.Models.Service, ServiceDto>();
            CreateMap<ServiceCreateDto,Entities.Models.Service>();
            CreateMap<UserCreateDto, User>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<PositionCreateDto, Position>();
            CreateMap<CreateCourseOfUsersDto, CourseOfUsersDto>();
            CreateMap<CourseOfUsersDto, CourseOfUsers>();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<CoursesUpdateDto, Course>().ReverseMap();
            
        }
    }
}
