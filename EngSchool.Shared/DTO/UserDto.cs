namespace EngSchool.Shared.DTO
{
    public record UserDto
    { 
        public int UserId { get; init; }
        public string? Name { get; init; }
        public int Age { get; init; }
        public string? Email { get; init; }
        public string? Adress { get; init; }
        public string? Phone { get; init; }
        //public int PositionId { get; init; }
    }
}
