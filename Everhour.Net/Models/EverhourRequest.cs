namespace Everhour.Net.Models
{
    public abstract class EverhourRequest: IRequest
    {
        public virtual string ToQuery() { return string.Empty; }
    }
}