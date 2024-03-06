using AutoMapper;
using AutoMapper_Training.SingleClassToSingleClass;

namespace AutoMapper_Training;

public class SingleDepthClassProfile : Profile
{
    public SingleDepthClassProfile()
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
        CreateMap<AppSheetRowDto, Application>();
        CreateMap<AppSheetRowDto, Application>();
    }
}
