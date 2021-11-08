using AutoMapper;
using ProjectRunner.Common.Entities;
using ProjectRunner.WPF.ViewModels.Executables;

namespace ProjectRunner.WPF.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Executable, ExecutableViewModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.FileName, o => o.MapFrom(s => s.FileName))
                .ReverseMap();
        }
    }
}
