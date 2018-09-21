namespace Everhour.Net.Models
{
    public enum ListAllProjectsPlatform
    {
        AS,
        EV,
        B3,
        B2,
        PV,
        GH,
        IN,
        TR,
        JR
    }

    static internal class ListAllProjectsPlatformExtensions
    {
        public static string ToLower(this ListAllProjectsPlatform field)
        {
            return field.ToString().ToLower();
        }
    }
}