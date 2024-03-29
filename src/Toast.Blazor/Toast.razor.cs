﻿namespace Toast.Blazor;
public sealed partial class Toast : ComponentBase, IDisposable
{
    [Inject] IToastService ToastService { get; set; }

    string Heading;
    string Message;
    bool IsVisible;
    string ColorsCssClass;
    string IconCssClass;
    bool IsCloseIconVisible;

    protected override void OnInitialized()
    {
        ToastService.OnShow += ShowToast;
        ToastService.OnHide += HideToast;
    }

    void ShowToast(object sender, ShowToastEventArgs e)
    {
        BuildToastSettings(e.Heading, e.Message, e.Level);
        IsVisible = true;
        IsCloseIconVisible = e.ShowCloseIcon;
        InvokeAsync(StateHasChanged);
    }

    void BuildToastSettings(string heading, string message, ToastLevel level)
    {
        Heading = heading;
        Message = message;
        switch(level)
        {
            case ToastLevel.Info:
                ColorsCssClass = "has-background-info";
                IconCssClass = "fas fa-info-circle";
                break;
            case ToastLevel.Success:
                ColorsCssClass = "has-background-success";
                IconCssClass = "fas fa-check-circle";
                break;
            case ToastLevel.Warning:
                ColorsCssClass = "has-background-warning";
                IconCssClass = "fas fa-exclamation-triangle";
                break;
            case ToastLevel.Error:
                ColorsCssClass = "has-background-danger";
                IconCssClass = "fas fa-times";
                break;
        }
    }

    void HideToast(object sender, EventArgs e)
    {
        IsVisible = false;
        InvokeAsync(StateHasChanged);
    }

    void HideToast() => HideToast(null, null);
    void IDisposable.Dispose()
    {
        ToastService.OnShow -= ShowToast;
        ToastService.OnHide -= HideToast;
    }
}
