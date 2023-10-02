using AutoMapper;
using EngSchool.Contracts;
using EngSchool.Service.Contracts;

namespace EngSchool.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICourseService> courseService;
        private readonly Lazy<IPriceService> priceService;
        private readonly Lazy<IUserService> userService;
        private readonly Lazy<IServiceService> serviceService;
        private readonly Lazy<IPositionService> positionService;
        private readonly Lazy<ICourseOfUsersService> courseOfUsersService; 

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            courseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager, loggerManager, mapper));
            priceService = new Lazy<IPriceService>(() => new PriceService(repositoryManager, loggerManager, mapper));
            userService = new Lazy<IUserService>(() => new UserService(repositoryManager, loggerManager, mapper));
            serviceService = new Lazy<IServiceService>(() => new ServiceService(repositoryManager, loggerManager, mapper));
            positionService = new Lazy<IPositionService>(() => new PositionService(repositoryManager, loggerManager, mapper));
            courseOfUsersService = new Lazy<ICourseOfUsersService>(() => new CourseOfUserService(repositoryManager, mapper, loggerManager));
        }

        public ICourseService CourseService => courseService.Value;

        public IPriceService PriceService => priceService.Value;

        public IUserService UserService => userService.Value;

        public IServiceService ServiceService => serviceService.Value;
        public IPositionService PositionService => positionService.Value;
        public ICourseOfUsersService CourseOfUsersService=> courseOfUsersService.Value;
    }
}
