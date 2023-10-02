namespace EngSchool.Service.Contracts
{
    public interface IServiceManager
    {
        ICourseService CourseService { get; }
        IPriceService PriceService { get; }
        IUserService UserService { get; }
        IServiceService ServiceService { get; }
        IPositionService PositionService { get; }
        ICourseOfUsersService CourseOfUsersService { get; }
    }
}
