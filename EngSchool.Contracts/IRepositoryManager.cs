namespace EngSchool.Contracts
{
    public interface IRepositoryManager
    {
        ICourseRepository Course { get; }
        IPriceRepository Price { get; }
        IServiceRepository Service { get; }
        IUserRepository User { get; }
        IPositionRepository Position { get; }
        ICourseOfUsersRepository CourseOfUsers { get; }
        Task SaveAsync();
    }
}
