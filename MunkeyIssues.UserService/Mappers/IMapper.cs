namespace MunkeyIssues.UserService.Mappers
{
    public interface IMapper<in TFrom, out TTo>
    {
        TTo Map(TFrom request);
    }
}
