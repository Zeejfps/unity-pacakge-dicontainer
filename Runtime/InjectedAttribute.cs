using System;

namespace Vas.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class InjectedAttribute : Attribute { }
}
