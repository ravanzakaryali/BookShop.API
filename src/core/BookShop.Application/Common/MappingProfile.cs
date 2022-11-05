using BookShop.Application.Asbtarcts.Common;
using System.Reflection;
using S = System;

namespace BookShop.Application.Common;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
}
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        S.Type mapFromType = typeof(IMapFrom<>);

        string mappingMethodName = nameof(IMapFrom<object>.Mapping);

        bool HasInterface(S.Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == mapFromType;

        List<S.Type> types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface)).ToList();

        S.Type[] argumentTypes = new S.Type[] { typeof(Profile) };

        foreach (S.Type type in types)
        {
            object? instance = Activator.CreateInstance(type);

            MethodInfo? methodInfo = type.GetMethod(mappingMethodName);

            if (methodInfo != null)
            {
                methodInfo.Invoke(instance, new object[] { this });
            }
            else
            {
                List<S.Type> interfaces = type.GetInterfaces().Where(HasInterface).ToList();

                if (interfaces.Count > 0)
                {
                    foreach (var @interface in interfaces)
                    {
                        MethodInfo? interfaceMethodInfo = @interface.GetMethod(mappingMethodName, argumentTypes);

                        interfaceMethodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}
