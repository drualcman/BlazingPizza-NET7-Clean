namespace SpecificationValidation.Abstractions;
public abstract class Specification<T> : ISpecification<T>
{
    protected PropertyRule<T> AddRule(string propertyName, Func<T, bool> predicate, string errorMessage,
        OnFirstErrorAction onFirstErrorAction = OnFirstErrorAction.StopValidation)
    {
        PropertyRule<T> propertyRule = new PropertyRule<T>(propertyName, predicate, errorMessage, onFirstErrorAction);
        PropertyRules.Add(propertyRule);
        return propertyRule;
    }

    protected PropertyRule<T> Property(Expression<Func<T, object>> property)
    {
        PropertyRule<T> propertyRule = new PropertyRule<T>(ExpressionHelper.GetPropertyName(property));
        PropertyRules.Add(propertyRule);
        return propertyRule;
    }

    readonly List<ValidationError> ErrorsFields = new();
    readonly List<PropertyRule<T>> PropertyRules = new();

    bool ValidateRule(T entity, List<PropertyRule<T>> propertyRules)
    {
        ErrorsFields.Clear();
        foreach(PropertyRule<T> property in propertyRules)
        {
            foreach(Rule<T> rule in property.Rules)
            {
                if(!rule.Predicate(entity))
                {
                    ErrorsFields.Add(new ValidationError(rule.ErrorMessage, property.PropertyName));
                    if(property.OnFirstErrorAction == OnFirstErrorAction.StopValidation)
                        break;
                }
            }
        }
        return !ErrorsFields.Any();
    }

    public IEnumerable<IValidationError> Errors => ErrorsFields;

    public bool IsSatisfiedBy(T entity) => ValidateRule(entity, PropertyRules);
    public bool IsSatisfiedBy(T entity, string propertyName) => ValidateRule(entity, PropertyRules.Where(p => p.PropertyName == propertyName).ToList());
}
