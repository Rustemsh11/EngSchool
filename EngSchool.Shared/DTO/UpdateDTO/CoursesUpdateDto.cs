namespace EngSchool.Shared.DTO.UpdateDTO
{
    public record CoursesUpdateDto
    {
        public string? CourseName { get; init; }
        public string? Period { get; init; }
        public string? Level { get; init; }
    }
}
