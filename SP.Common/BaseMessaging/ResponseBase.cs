using SP.Common.Enums;

namespace SP.Common.BaseMessaging
{
    public abstract class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ResultType Result { get; set; }
    }

    public abstract class ResponseBase<TEntity> : ResponseBase
    {
        public TEntity Entity { get; set; }
    }

    public abstract class ResponsePagedBase<TEntity> : ResponseBase
    {
        public int RowCount { get; set; }
        public TEntity Entity { get; set; }
    }
}
