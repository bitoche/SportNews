namespace SportNews_pre_release_.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }


        public static Pager Create(int totalItems, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            return new Pager() { TotalPages = totalPages, CurrentPage = page, PageSize = pageSize, TotalItems = totalItems, StartPage = startPage, EndPage = endPage };

        }
    }

    public class PageModel<T> where T : class
    {
        public IEnumerable<T> Items { get; private set; }
        public Pager Pager { get; private set; }
        public int DisciplineId { get; private set; }
        public string? Query { get; private set; }
        public PageModel(IEnumerable<T> items, int page, int disciplineId, string query)
        {
            int skip = (page - 1) * 5;
            Pager = Pager.Create(items.Count(), page, 5);
            Items = items.Skip(skip).Take(Pager.PageSize).ToList();
            DisciplineId = disciplineId;
            Query = query;
        }
    }
}
