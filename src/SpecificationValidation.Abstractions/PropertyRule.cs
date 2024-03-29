﻿namespace SpecificationValidation.Abstractions;
public class PropertyRule<T>
{
    internal string PropertyName { get; }
    internal List<Rule<T>> Rules { get; }
    internal OnFirstErrorAction OnFirstErrorAction { get; private set; }

    internal PropertyRule(string propertyName)
    {
        PropertyName = propertyName;
        Rules = new();
        OnFirstErrorAction = OnFirstErrorAction.StopValidation;
    }

    internal PropertyRule(string propertyName, Func<T, bool> predicate, string errorMessage, OnFirstErrorAction onFirstErrorAction)
    {
        PropertyName = propertyName;
        Rules = new();
        OnFirstErrorAction = onFirstErrorAction;
        AddRule(predicate, errorMessage);
    }

    public PropertyRule<T> ContinueOnError()
    {
        OnFirstErrorAction = OnFirstErrorAction.ContinueValidation;
        return this;
    }

    public PropertyRule<T> AddRule(Func<T, bool> predicate, string errorMessage)
    {
        Rules.Add(new Rule<T>(predicate, errorMessage));
        return this;
    }
}
