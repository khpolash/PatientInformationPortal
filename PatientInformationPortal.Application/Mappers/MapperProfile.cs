using AutoMapper;
using PatientInformationPortal.Application.ViewModels.VmEntities;
using PatientInformationPortal.SharedKernel.Entities;


namespace PatientInformationPortal.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {

        CreateMap<AllergiesDetailVm, AllergiesDetail>().ReverseMap();
        CreateMap<AllergyVm, Allergy>().ReverseMap();
        CreateMap<DiseaseVm, Disease>().ReverseMap();
        CreateMap<NCDDetailVm, NCDDetail>().ReverseMap();

        CreateMap<PatientVm, Patient>()
            .ForMember(dest => dest.NCDDetails, opt => opt.Ignore())
            .ForMember(dest => dest.AllergiesDetails, opt => opt.Ignore());

        CreateMap<Patient, PatientVm>()
            .ForMember(dest => dest.NCDDetails, opt => opt.MapFrom(src => src.NCDDetails.Select(detail => detail.Id).ToList()))
            .ForMember(dest => dest.AllergiesDetails, opt => opt.MapFrom(src => src.AllergiesDetails.Select(detail => detail.Id).ToList()));

        AllowNullCollections = true;
    }
}
