﻿using Microsoft.JSInterop;

namespace SweetAlert.Blazor;
public sealed class SweetAlertService : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> JSObjectReference;

    public SweetAlertService(IJSRuntime jsRuntime)
    {
        JSObjectReference = new(() => GetJSObjectReference(jsRuntime));
    }

    private Task<IJSObjectReference> GetJSObjectReference(IJSRuntime jsRuntime) =>
        jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/SweetAlert.Blazor/sweetalert.min.js").AsTask();

    public async ValueTask DisposeAsync()
    {
        if(JSObjectReference.IsValueCreated)
        {
            IJSObjectReference module = await JSObjectReference.Value;
            await module.DisposeAsync();
        }
    }

    async ValueTask<T> InvokeAsync<T>(object args)
    {
        T result = default;
        try
        {
            IJSObjectReference module = await JSObjectReference.Value;
            result = await module.InvokeAsync<T>("sweetalert", args);
        }
        catch(Exception ex)
        {   
            await Console.Out.WriteLineAsync($"SweetAlertService: {ex.Message}");
        }
        return result;
    } 
    async ValueTask InvokeVoidAsync(object args)
    {
        try
        {
            IJSObjectReference module = await JSObjectReference.Value;
            await module.InvokeVoidAsync("sweetalert", args);
        }
        catch(Exception ex)
        {   
            await Console.Out.WriteLineAsync($"SweetAlertService: {ex.Message}");
        }
    }

    public ValueTask<T> FireAsync<T>(object args) => InvokeAsync<T>(args);
    public ValueTask FireVoidAsync(object args) => InvokeVoidAsync(args);
    public async Task<bool> ConfirmAsync(ConfirmArgs args) =>
        await InvokeAsync<bool>(args);
}
