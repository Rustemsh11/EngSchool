namespace EngSchool.Shared.RequestFeatures
{
    public class CourseParameters: RequestParameters
    {
        public string? CourseLevel { get; set; }
        public string? CourseNameForSearch { get; set; }

        public bool IsValidLevel() 
        { 
            if(CourseLevel == "Beginner" || CourseLevel == "Pre-Intermediate" || CourseLevel == "All" || CourseLevel is null)
            {
                return true;
            }
            return false;
        }
    }
}
