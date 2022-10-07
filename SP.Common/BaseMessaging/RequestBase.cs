namespace SP.Common.BaseMessaging
{
    public abstract class RequestBase
    {
    }

    public abstract class RequestBase<TEntity> : RequestBase
    {
        public TEntity Entity { get; set; }
    }

    public abstract class RequestPagedBase
    {
        public string Search { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }

    public abstract class RequestPagedBase<TEntity> : RequestPagedBase
    {
        public TEntity Entity { get; set; }
    }
}
