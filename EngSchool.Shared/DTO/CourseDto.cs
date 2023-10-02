namespace EngSchool.Shared.DTO
{
    [Serializable]
    public record CourseDto 
    {
        public int CourseId { get; init; }
        public string? CourseName { get; init; }
        public string? Period { get; init; }
        public string? Level { get; init; }
        public int? ServiceId { get; init;}
    }
}
