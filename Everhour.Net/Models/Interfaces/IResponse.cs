namespace Everhour.Net.Models
{
    public interface IResponse<T>
    {
        T FromJson(string json);
    }
}