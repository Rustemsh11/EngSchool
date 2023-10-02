namespace EngSchool.Entities.Exception
{
    public class PositionNotFoundException : NotFoundException
    {
        public PositionNotFoundException(int id) : base($"The position with id: {id} doesnt exist in the database")
        {
        }
    }
}
