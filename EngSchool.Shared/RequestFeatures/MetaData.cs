namespace EngSchool.Shared.RequestFeatures
{
    /// <summary>
    /// Метаданные для заголовка и для пагинации
    /// </summary>
    public class MetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevius()
        {
            return CurrentPage > 1;
        }
        public bool HasNext() 
        {
            return CurrentPage < TotalCount; 
        }
    }
}
