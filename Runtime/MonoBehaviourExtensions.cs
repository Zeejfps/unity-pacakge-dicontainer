using System.Reflection;
using UnityEngine;

namespace Vas.DependencyInjection
{
    public static class MonoBehaviourExtensions
    {
        public static void Inject(this MonoBehaviour monoBehaviour)
        {
            var properties = monoBehaviour
                .GetType()
                .GetProperties();

            foreach (var property in properties)
            {
                var injected = property.GetCustomAttribute<InjectedAttribute>();
                if (injected != null)
                {
                    var propertyType = property.PropertyType;
                    if (DiContainer.Global.TryGet(propertyType, out var obj))
                    {
                        property.SetValue(monoBehaviour, obj);
                    }
                    else
                    {
                        Debug.LogWarning($"Failed to inject {property.Name}", monoBehaviour);
                    }
                }
            }
        }
    }
}