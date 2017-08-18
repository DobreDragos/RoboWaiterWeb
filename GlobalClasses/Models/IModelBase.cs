namespace GlobalClasses.Models
{
    public interface IModelBase
    {
        string IdFieldName { get; }
        long Id { get; set; }
        bool IsNew { get; }
    }
}