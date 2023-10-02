namespace EngSchool.Entities.Exception
{
    public class ServiceNotFoundException : NotFoundException
    {
        public ServiceNotFoundException(int id) : base($"Service with {id} not found in database")
        {
        }
    }
}
