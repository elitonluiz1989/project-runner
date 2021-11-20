using AutoMapper;
using ProjectRunner.Common.Entities;
using ProjectRunner.WPF.Tools;
using ProjectRunner.WPF.ViewModels.Executables;

namespace ProjectRunner.WPF.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Executable, ExecutableViewModel>()
                .ConstructUsing(d => ServiceProviderAccessor.GetRequiredService<ExecutableViewModel>())
                .ForMember(d => d.ShowFormCommand, o => o.Ignore())
                .ReverseMap();
        }
    }
}
