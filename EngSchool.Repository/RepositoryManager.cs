using EngSchool.Contracts;

namespace EngSchool.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly EngSchoolRepositoryContext _context;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<ICourseRepository> _courseRepository;
        private readonly Lazy<IServiceRepository> _serviceRepository;
        private readonly Lazy<IPriceRepository> _priceRepository;
        private readonly Lazy<IPositionRepository> _positionRepository;
        private readonly Lazy<ICourseOfUsersRepository> _courseOfUsersRepository;

        public RepositoryManager(EngSchoolRepositoryContext context)
        {
            _context = context;
            _userRepository = new Lazy<IUserRepository> (()=>new UserRepository(context));
            _courseRepository = new Lazy<ICourseRepository> (()=>new CourseRepository(context));
            _serviceRepository = new Lazy<IServiceRepository> (()=>new ServiceRepository(context));
            _priceRepository = new Lazy<IPriceRepository> (()=>new PriceRepository(context));
            _positionRepository = new Lazy<IPositionRepository>(() => new PositonRepository(context));
            _courseOfUsersRepository = new Lazy<ICourseOfUsersRepository> (()=> new CourseOfUsersRepository(context));
                
        }

        public IUserRepository User => _userRepository.Value;
        public ICourseRepository Course => _courseRepository.Value;
        public IServiceRepository Service => _serviceRepository.Value;
        public IPriceRepository Price => _priceRepository.Value;
        public IPositionRepository Position => _positionRepository.Value;
        public ICourseOfUsersRepository CourseOfUsers => _courseOfUsersRepository.Value;
        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
