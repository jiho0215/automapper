using AutoMapper;
using AutoMapper_Training.ClassWithConstructor;

namespace AutoMapper_Training;

public class ForMemberWithMethodProfile : Profile
{
    public ForMemberWithMethodProfile()
    {
        InitializeGlobalConfiguration();
        MapperProfile();
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


    private void MapperProfile()
    {
        CreateMap<CostCenterDto, CostCenter>()
            .ConstructUsing((src, ctx) =>
            {
                return new CostCenter(name: src.Name);
            })
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => CheckForNullCostCenterUrl(src.Url)))
            .ReverseMap()
            .ForMember(dest => dest.IsInactive, opt => opt.Ignore());
    }

    private static string CheckForNullCostCenterUrl(string url)
    {
        var EmptyGreenhouseApplicationUrl = "{\"Url\":\"\",\"LinkText\":\"\"}";
        return string.Equals(url, EmptyGreenhouseApplicationUrl, StringComparison.OrdinalIgnoreCase) ? null : url;
    }
}
