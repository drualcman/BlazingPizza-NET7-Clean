using BlazorDemo.Models;

namespace BlazorDemo.Pages;

public partial class TextTransformer
{
    void TransfromText(KeyTransfromation k)
    {
        k.TransformedKey = k.Key.ToUpper();
    }
}