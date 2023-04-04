namespace SweetAlert.Blazor;
public sealed class ConfirmArgs
{
    public string Title { get; }
    public string Text { get; }
    public string Icon { get; }
    public object Buttons { get; }
    public bool DangerMode { get; set; }

    public ConfirmArgs(string header, string content, string icon,
        string confirmText = "OK", string abortText = "Cencel", bool dangerMode = true)
    {
        Title = header;
        Text = content;
        Icon = icon;
        DangerMode = dangerMode;
        Buttons = new
        {
            confirm = new
            {
                text = confirmText,
                value = true
            },
            abort = new
            {
                text = abortText,
                value = false
            }
        };
    }
}
