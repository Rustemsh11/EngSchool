namespace EngSchool.Shared.RequestFeatures
{
    /// <summary>
    /// класс для возвращения списка объектов и метаданные для заголовка после пагинации
    /// </summary>
    public class PageList<T>: List<T>
    {
        public MetaData MetaData { get; set; }
        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData()
            {
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize),
            };
            AddRange(items);
        }
        public static PageList<T> ToPageList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize).ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
