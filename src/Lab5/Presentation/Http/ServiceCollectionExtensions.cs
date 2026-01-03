namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation;

public static class ServiceCollectionExtensions
{
     public static IServiceCollection AddPresentationHttp(this IServiceCollection collection)
    {
        collection.AddControllers();
        return collection;
    }
}
