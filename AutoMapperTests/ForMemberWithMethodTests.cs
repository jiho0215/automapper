using AutoMapper;
using AutoMapper_Training;
using AutoMapper_Training.ClassWithConstructor;
using System.Diagnostics.CodeAnalysis;

namespace AutoMapperTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class ForMemberWithMethodTests
{
    private Mapper mapper;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ForMemberWithMethodProfile>();
        });
        mapper = new Mapper(config);
    }

    [Test]
    public void ForMemberWithMethod()
    {
        //Arrange:
        var costCenterDto = GetCostCenterDto();

        //Act:
        var costCenter = mapper.Map<CostCenter>(costCenterDto);

        //Assert:
        Assert.Multiple(() =>
        {
            Assert.That(costCenter.CostCenterName, Is.EqualTo(costCenterDto.Name));
            Assert.That(costCenter.Description, Is.EqualTo(costCenterDto.Description));
            Assert.That(costCenter.Url, Is.EqualTo(costCenterDto.Url));
        });
    }

    [Test]
    public void ForMemberWithMethod_EmptyUrl()
    {
        //Arrange:
        var costCenterDto = GetCostCenterDto();
        costCenterDto.Url = "{\"Url\":\"\",\"LinkText\":\"\"}";

        //Act:
        var costCenter = mapper.Map<CostCenter>(costCenterDto);

        //Assert:
        Assert.Multiple(() =>
        {
            Assert.That(costCenter.CostCenterName, Is.EqualTo(costCenterDto.Name));
            Assert.That(costCenter.Description, Is.EqualTo(costCenterDto.Description));
            Assert.That(costCenter.Url, Is.EqualTo(null));
        });
    }

    private static CostCenterDto GetCostCenterDto()
    {
        return new()
        {
            Name = "Name",
            Description = "Description",
            IsInactive = false,
            Url = "google.com"
        };
    }
}
