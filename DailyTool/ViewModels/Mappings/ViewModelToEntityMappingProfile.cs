
using DTValueObject;
using AutoMapper;

using DTModels.Database;
namespace DailyTool.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, Users>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
