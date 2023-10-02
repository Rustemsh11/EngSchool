namespace EngSchool.Entities.Exception
{
    public class LevelNotValidBadRequestException : BadRequestException
    {
        public LevelNotValidBadRequestException() : base("Такого уровня знания не существует")
        {
        }
    }
}
