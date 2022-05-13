namespace NewsLetters.Infrastructure.CrossCutting.Mapper.Interface;

public interface IMapper<TMapper, TMapped> where TMapper : class where TMapped : class
{
    // TMapped MapEntityToDto(TMapper obj);
    // TMapper MapDtoToEntity(TMapped obj);
    // IEnumerable<TMapped> MapListEntityToDto(IEnumerable<TMapper> obj);
    // IEnumerable<TMapper> MapListDtoToEntity(IEnumerable<TMapped> obj);
    TMapped Map(TMapper source);
    TMapper Map(TMapped source);
    IEnumerable<TMapped> Map(IEnumerable<TMapper> source);
    
}