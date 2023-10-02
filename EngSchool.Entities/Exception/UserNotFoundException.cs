namespace EngSchool.Entities.Exception
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int id) : base($"The user with id: {id} doesnt exist in the database")
        {
        }
    }
}
