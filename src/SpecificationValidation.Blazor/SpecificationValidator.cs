namespace SpecificationValidation.Blazor;
public class SpecificationValidator<T> : ComponentBase
{
    [CascadingParameter] EditContext Context { get; set; }
    [Parameter] public IValidator<T> Validator { get; set; }

    ValidationMessageStore ValidationMessageStore;

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        EditContext previousContext = Context;
        await base.SetParametersAsync(parameters);
        if(Context != previousContext)
        {
            ValidationMessageStore = new ValidationMessageStore(Context);
            Context.OnValidationRequested += ValidationRequested;
            Context.OnFieldChanged += FieldChanged;
        }
    }
    private void ValidationRequested(object sender, ValidationRequestedEventArgs e)
    {
        ValidationMessageStore.Clear();
        IValidationResult result = Validator.Validate((T)Context.Model);
        HandleErrors(Context.Model, result);
    }

    private void FieldChanged(object sender, FieldChangedEventArgs e)
    {
        FieldIdentifier fieldIdentifier = e.FieldIdentifier;
        ValidationMessageStore.Clear(fieldIdentifier);  
        IValidationResult result = Validator.ValidateProperty((T)fieldIdentifier.Model, fieldIdentifier.FieldName);
        HandleErrors(Context.Model, result);
    }

    private void HandleErrors(object model, IValidationResult result)
    {
        if(!result.IsValid)
        {
            foreach(IValidationError error in result.Errors)
            {
                ValidationMessageStore.Add(new FieldIdentifier(model, error.PropertyName), error.Message);
            }
        }
    }

}
