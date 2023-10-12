namespace DesafioTecnicoAlunoTurma.Pagination
{
    public class PaginationParameters
    {
        const int maxPageSize = 100;
        public int PageNumber { get; set; } = 0;
        private int _pageSize { get; set; } = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
