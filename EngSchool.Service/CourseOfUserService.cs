using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Entities.Exception;
using EngSchool.Entities.Models;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;

namespace EngSchool.Service
{
    public class CourseOfUserService : ICourseOfUsersService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        public CourseOfUserService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _loggerManager = loggerManager;
        }
        public async Task<CreateCourseOfUsersDto> CreateCourseOfUsersAsync(CreateCourseOfUsersDto createcourseOfUsersDto, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserByIdAsync(createcourseOfUsersDto.PositionId, createcourseOfUsersDto.UserId, trackChanges);
            if(user is null)
            {
                throw new UserNotFoundException(createcourseOfUsersDto.UserId);
            }
            var course = await _repositoryManager.Course.GetCourseAsync(createcourseOfUsersDto.ServiceId, createcourseOfUsersDto.CourseId, trackChanges);
            if(course is null)
            {
                throw new CourseNotFoundException(createcourseOfUsersDto.CourseId);
            }
            var courseOfUsersDto = _mapper.Map<CourseOfUsersDto>(createcourseOfUsersDto);
            var courseOfUsers = _mapper.Map<CourseOfUsers>(courseOfUsersDto);
            _repositoryManager.CourseOfUsers.CreateCourseOfUsers(courseOfUsers);
            await _repositoryManager.SaveAsync();
            return createcourseOfUsersDto;
        }

        public async Task DeleteCourseOfUsersAsync(CourseOfUsersDto courseOfUsersDto, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserByIdAsync(courseOfUsersDto.PositionId, courseOfUsersDto.UserId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(courseOfUsersDto.UserId);
            }
            var course = await _repositoryManager.Course.GetCourseAsync(courseOfUsersDto.ServiceId, courseOfUsersDto.CourseId, trackChanges);
            if (course is null)
            {
                throw new CourseNotFoundException(courseOfUsersDto.CourseId);
            }
            var courseOfUsers = await _repositoryManager.CourseOfUsers.GetCourseOfUsers(courseOfUsersDto.UserId, courseOfUsersDto.CourseId, trackChanges);
            _repositoryManager.CourseOfUsers.DeleteCourseOfUsers(courseOfUsers);
            await _repositoryManager.SaveAsync();
        }
    }
}
