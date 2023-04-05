namespace Leaflet.Blazor.Helpers;
internal class ContentHelper
{
    public static string ContentPath => $"_content/{typeof(ContentHelper).Assembly.GetName()}";
}
