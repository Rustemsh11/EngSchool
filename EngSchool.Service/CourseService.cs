using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Entities.Exception;
using EngSchool.Entities.Models;
using EngSchool.Service.Contracts;
using EngSchool.Shared.DTO;
using EngSchool.Shared.DTO.UpdateDTO;
using EngSchool.Shared.RequestFeatures;
using System.Collections.Generic;

namespace EngSchool.Service
{
    public class CourseService : ICourseService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public CourseService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;            
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateCourseAsync(int serviceId, CourseCreateDto courseDto, bool trackChanges)
        {
            await CheckServiceExist(serviceId, trackChanges);

            var course = _mapper.Map<Course>(courseDto);
            _repositoryManager.Course.CreateCourse(serviceId, course);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<CourseDto>(course);
        }

        public async Task DeleteCourse(int serviceId, int courseId, bool trackChanges)
        {
            await CheckServiceExist(serviceId, trackChanges);

            var course = await GetCousreAndCheckExist(serviceId, courseId, trackChanges);

            _repositoryManager.Course.DeleteCourse(course); 
            await _repositoryManager.SaveAsync();
        }

        public async Task<(IEnumerable<CourseDto> courseDto, MetaData metaData)> GetAllCoursesAsync(int serviceId,CourseParameters courseParameters, bool trackChanges)
        {
            if (!courseParameters.IsValidLevel())
            {
                throw new LevelNotValidBadRequestException();
            }
            await CheckServiceExist(serviceId, trackChanges);
            var coursesWithMetadata = await  _repositoryManager.Course.GetAllCoursesAsync(serviceId, courseParameters, trackChanges);
            var coursesDto =  _mapper.Map<IEnumerable<CourseDto>>(coursesWithMetadata); 
            return (courseDto: coursesDto, metaData: coursesWithMetadata.MetaData);
           
        }

        public async Task<CourseDto> GetCourseAsync(int serviceId, int courseId, bool trackChanges)
        {
            await CheckServiceExist(serviceId, trackChanges);
            var course = await GetCousreAndCheckExist(serviceId, courseId, trackChanges);
            var courseDto = _mapper.Map<CourseDto>(course);
            return courseDto;
        }

        public async Task<(CoursesUpdateDto courseToPatch, Course courseEntity)> GetCourseForPatchAsync(int serviceId, int courseId, bool trackChangesForService, bool trackChangesForCourse)
        {
            await CheckServiceExist(serviceId, trackChangesForService);

            var course = await GetCousreAndCheckExist(serviceId, courseId, trackChangesForCourse);

            var courseToPatch = _mapper.Map<CoursesUpdateDto>(course);
            return (courseToPatch, course);
        }
        public async Task SaveChangesForPatchAsync(CoursesUpdateDto courseToPatch, Course courseEntity)
        {
            _mapper.Map(courseToPatch, courseEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<UserDto>> GetUsersForCourseByIdAsync(int serviceId, int courseId, bool trackChanges)
        {
            await CheckServiceExist(serviceId, trackChanges);

            var courseOfUsers = await _repositoryManager.CourseOfUsers.GetUsersForConcreteCourseAsync(serviceId, courseId, trackChanges);
            var users = new List<User>();
            foreach (var user in courseOfUsers)
            {
                users.Add(await _repositoryManager.User.GetUserByIdAsync(user.User.PositionId,user.UserId, trackChanges));
            }
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }


        public async Task UpdateCourseAsync(int serviceId, int courseId, CoursesUpdateDto coursesUpdate, bool trackChangesForService, bool trackChangesForCourse)
        {
            await CheckServiceExist(serviceId, trackChangesForService);

            var course = await GetCousreAndCheckExist(serviceId, courseId, trackChangesForCourse);

            _mapper.Map(coursesUpdate, course);
            await _repositoryManager.SaveAsync();
        }

        /// <summary>
        /// проверяем есть ли такой курс в бд, если нет то кидаем ошибку, если есть то возвращаем этот курс
        /// </summary>
        private async Task<Course> GetCousreAndCheckExist(int serviceId, int courseId, bool trackChanges)
        {
            var course = await _repositoryManager.Course.GetCourseAsync(serviceId, courseId, trackChanges);
            if (course is null)
            {
                throw new CourseNotFoundException(courseId);
            }
            return course;
        }

        /// <summary>
        /// проверяем есть ли в бд такой сервис, если нет то кидаем эксепшн
        /// </summary>
        private async  Task CheckServiceExist(int serviceId, bool trackChanges)
        {
            var service = await _repositoryManager.Service.GetServiceAsync(serviceId, trackChanges);
            if (service is null)
            {
                throw new ServiceNotFoundException(serviceId);
            }
            
        }
    }
}
