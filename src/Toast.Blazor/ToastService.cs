namespace Toast.Blazor;
internal class ToastService : IToastService
{

    public event OnShowEventHandler OnShow;

    public event EventHandler OnHide;

    public void Hide() => OnHide?.Invoke(this, EventArgs.Empty);
    public void ShowError(string heading, string message, byte timeToShowInSeconds) => ShowToast(heading, message, ToastLevel.Error, timeToShowInSeconds);
    public void ShowInfo(string heading, string message, byte timeToShowInSeconds) => ShowToast(heading, message, ToastLevel.Info, timeToShowInSeconds);
    public void ShowWarning(string heading, string message, byte timeToShowInSeconds) => ShowToast(heading, message, ToastLevel.Warning, timeToShowInSeconds);
    public void ShowSuccess(string heading, string message, byte timeToShowInSeconds) => ShowToast(heading, message, ToastLevel.Success, timeToShowInSeconds);

    private void ShowToast(string heading, string message, ToastLevel level, byte timeToShowInSeconds)
    {
        OnShow?.Invoke(this, new ShowToastEventArgs(heading, message, level, timeToShowInSeconds <= 0));
        SetTimer(timeToShowInSeconds);
    }

    System.Timers.Timer ToastTimer;    
    private void SetTimer(byte timeToShowInSeconds)
    {
        if(ToastTimer == null)
        {
            ToastTimer = new System.Timers.Timer();
            ToastTimer.Elapsed += (sender, e) => Hide();
            ToastTimer.AutoReset = false;
        }
        else
        {
            ToastTimer.Stop();
        }
        
        if(timeToShowInSeconds > 0)
        {
            ToastTimer.Interval = timeToShowInSeconds * 1000;
            ToastTimer.Start();
        }
    }

    public void Dispose() => ToastTimer?.Dispose();
}
