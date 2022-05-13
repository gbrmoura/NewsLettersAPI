using Microsoft.Extensions.Logging;
using NewsLetters.Infrastructure.CrossCutting.Mapper.Interface;

namespace NewsLetters.Infrastructure.CrossCutting.Mapper.Mappers;

public class BaseMapper<TMapper, TMapped> : IMapper<TMapper, TMapped> where TMapper : class, new() where TMapped : class, new()
{
    private readonly ILogger<BaseMapper<TMapper, TMapped>> _logger;
    public BaseMapper(ILogger<BaseMapper<TMapper, TMapped>> logger)
    {
        _logger = logger;
    }

    public TMapped Map(TMapper source)
    {
        _logger.LogInformation("Mapping {Mapper} to {Mapped}", source.GetType().Name, typeof(TMapped).Name);
        var destination = new TMapped();
        var sourceProperties = source.GetType().GetProperties();
        var destinationProperties = destination.GetType().GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
            if (destinationProperty != null)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }

    public TMapper Map(TMapped source)
    {
        _logger.LogInformation("Mapping {Mapped} to {Mapper}", source.GetType().Name, typeof(TMapper).Name);
        var destination = new TMapper();
        var sourceProperties = source.GetType().GetProperties();
        var destinationProperties = destination.GetType().GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = destinationProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
            if (destinationProperty != null)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }

        return destination;
    }
    
    public IEnumerable<TMapped> Map(IEnumerable<TMapper> source)
    {
        _logger.LogInformation("Mapping Enumerable {Mapper} to {Mapped}", source.GetType().Name, typeof(TMapped).Name);
        var destination = new List<TMapped>();
        foreach (var item in source)
        {
            destination.Add(Map(item));
        }

        return destination;
    }
}