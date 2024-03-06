using AutoMapper;
using AutoMapper_Training.SingleClassToSingleClass;

namespace AutoMapper_Training;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        InitializeGlobalConfiguration();
        AtoB_Profile();
    }
    private void InitializeGlobalConfiguration()
    {
        CreateMap<string, long?>().ConvertUsing(s => LongTryParse(s));
        CreateMap<string, int?>().ConvertUsing(s => IntTryParse(s));
        CreateMap<string, bool?>().ConvertUsing(s => boolTryParse(s));
    }

    private static long? LongTryParse(string s)
    {
        if (long.TryParse(s, out long l))
        {
            return l;
        }
        return null;
    }

    private static int? IntTryParse(string s)
    {
        if (int.TryParse(s, out int i))
        {
            return i;
        }
        return null;
    }

    private static bool? boolTryParse(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return null;
        }

        switch (s.ToLower().Trim())
        {
            case "true":
            case "yes":
            case "y":
            case "1":
                return true;
            case "false":
            case "no":
            case "n":
            case "0":
                return false;
            default:
                return null;
        }
    }

    private void AtoB_Profile()
    {
        CreateMap<AppSheetRowDto, Application>();
        //CreateMap<WorkdayProgressUpdateRequest, Database.Models.Application>()
        //    .ForMember(dest => dest.Candidate, opt => opt.MapFrom(src => src))
        //    .ForMember(dest => dest.WorkdayProgress, opt => opt.MapFrom(src => src));
    }
}
