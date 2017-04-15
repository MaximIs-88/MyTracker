using AutoMapper;
using MyTracker.Models;

namespace MyTracker.ViewModels
{
    public class MapperConfig : IMapperConfig
    {
        public MapperConfig()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MyTask, TasksViewModel>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Author.UserName));
            });
        }

        public T2 Map<T1, T2>(object obj)
        {
            return Mapper.Map<T1, T2>((T1) obj);
        }
    }

    public interface IMapperConfig
    {
        T2 Map<T1, T2>(object obj);
    }
}
