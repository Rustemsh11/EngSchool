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
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public UserService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUserAsync(int positionId, UserCreateDto userCreateDto, bool trackChanges)
        {
            await CheckExistPosition(positionId, trackChanges);

            var user = _mapper.Map<User>(userCreateDto);

            _repositoryManager.User.CreateUser(positionId,user);
            await _repositoryManager.SaveAsync();

            var userToReturn = _mapper.Map<UserDto>(user);
            return userToReturn;
        }

        public async Task DeleteUserAsync(int positionId, int userId, bool trackChanges)
        {
            await CheckExistPosition(positionId, trackChanges);

            var user = await GetUserAndCheckExist(positionId, userId, trackChanges);

            _repositoryManager.User.DeleteUser(user);
            await _repositoryManager.SaveAsync();

        }

        public async Task<(IEnumerable<UserDto> userDto, MetaData metaData)> GetAllUsersAsync(int positionId,UserParameters userParameters, bool trackChanges)
        {
            await CheckExistPosition(positionId, trackChanges);

            var usersWithMetaData =  await _repositoryManager.User.GetAllUsersAsync(positionId, userParameters, trackChanges);
            var res = _mapper.Map<IEnumerable<UserDto>>(usersWithMetaData);
            return (userDto: res, metaData: usersWithMetaData.MetaData);
        }

        public async Task<UserDto> GetUserByIdAsync(int positionId, int userId, bool trackChanges)
        {
            await CheckExistPosition(positionId, trackChanges);

            var user = await GetUserAndCheckExist(positionId, userId, trackChanges);

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<IEnumerable<CourseDto>> GetUserCoursesByIdAsync(int positionId,int userId, bool trackChages)
        {
            await CheckExistPosition(positionId, trackChages);

            await CheckExistUser(positionId, userId, trackChages);
            
            var courseOfUsers = await _repositoryManager.CourseOfUsers.GetCourseIdForConcreteUserAsync(userId, trackChages);
            List<Course> courses = new List<Course>();
            foreach (var course in courseOfUsers)
            {
                courses.Add(await _repositoryManager.Course.GetCourseAsync(course.Course.Service.ServiceId, course.CourseId,trackChages));
            }
            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<(UserUpdateDto userToPatch, User userEntity)> GetUserForPatch(int positionId, int userId, bool trackChangesForPosition, bool trackChangesForUser)
        {
            await CheckExistPosition(positionId, trackChangesForPosition);

            var userEntity = await GetUserAndCheckExist(positionId, userId, trackChangesForUser);
            var userToPatch = _mapper.Map<UserUpdateDto>(userEntity);
            return (userToPatch, userEntity);
        }

        public async Task SaveChangesForPatch(UserUpdateDto userToPatch, User userEntity)
        {
            _mapper.Map(userToPatch, userEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateUserAsync(int positionId, int userId, UserUpdateDto userUpdateDto, bool trackChangesForPosition, bool trackChangesForUser)
        {
            await CheckExistPosition(positionId, trackChangesForPosition);

            var user = await GetUserAndCheckExist(positionId, userId, trackChangesForUser);

            _mapper.Map(userUpdateDto, user);
            await _repositoryManager.SaveAsync();
        }

        /// <summary>
        /// проверяем наличие позиции в бд по айди, если нет то кидаем ошибку
        /// </summary>
        private async Task CheckExistPosition(int positionId, bool trackChanges)
        {
            var position = await _repositoryManager.Position.GetPositionAsync(positionId, trackChanges);
            if (position is null)
            {
                throw new PositionNotFoundException(positionId);
            }
        }

        /// <summary>
        /// проверяем наличие пользователя в бд по айди, если нет то кидаем ошибку
        /// </summary>
        private async Task CheckExistUser(int positionId, int userId, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserByIdAsync(positionId, userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
        }

        /// <summary>
        /// Пробуем достать из бд пользователя, если его нет то кидаем ошибку, если есть возвращаем его
        /// </summary>
        public async Task<User> GetUserAndCheckExist(int positionId, int userId, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserByIdAsync(positionId, userId, trackChanges);
            if (user is null)
            {
                throw new UserNotFoundException(userId);
            }
            return user;
        }
    }
}
