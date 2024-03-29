﻿namespace BlazingPizza.ValidationWithSpecificationApi;
public class ValidationError
{
    public string Message { get; set; }
    public string PropertyName { get; set; }

    public ValidationError(string message, string propertyName)
    {
        Message = message;
        PropertyName = propertyName;
    }
}
