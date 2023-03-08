namespace SpecificationValidation;
internal static class ExpressionHelper
{
    // a => a.Name
    internal static string GetPropertyName<T>(Expression<Func<T, object>> propertyExpression)
    {
        MemberExpression memberExpression = propertyExpression.Body as MemberExpression;
        if(memberExpression == null)
        {
            throw new ArgumentException("Invalid body expression.");
        }
        PropertyInfo propertyInfo = memberExpression.Member as PropertyInfo;
         if(propertyInfo == null)
        {
            throw new ArgumentException("The expression must contenin the property name.");
        }
        return propertyInfo.Name;
    }
}
