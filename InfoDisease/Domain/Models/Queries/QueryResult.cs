namespace InfoDisease.Domain.Models.Queries
{
    public class QueryResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalItems { get; set; } = 0;
    }
}
