namespace ExamPre5.PaginatedHelper
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> datas, int count, int page, int pagesize)
        {
            this.AddRange(datas);
            ActivePage = page;
            TotalCount = (int)Math.Ceiling(count / (double)pagesize);
        }

        public int ActivePage { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrev
        {
            get
            {
                return ActivePage >1;
            }
        }
                
        public bool HasNext
        {
            get
            {
                return ActivePage < TotalCount;
            }
        }
    }
}
