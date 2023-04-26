namespace Dialog.Blazor;
public partial class DialogModal
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter, EditorRequired] public bool IsVisible { get; set; }

}
