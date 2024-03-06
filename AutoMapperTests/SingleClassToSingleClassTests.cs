using AutoMapper;
using AutoMapper_Training;
using AutoMapper_Training.SingleClassToSingleClass;
using System.Diagnostics.CodeAnalysis;

namespace AutoMapperTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class SingleClassToSingleClassTests
{
    private Mapper mapper;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<SingleDepthClassProfile>();
        });
        mapper = new Mapper(config);
    }

    [Test]
    public void SingleClassToSingleClass()
    {
        //Arrange:
        var appSheetRowDto = GetAppSheetRowDto();

        //Act:
        var application = mapper.Map<Application>(appSheetRowDto);

        //Assert:
        Assert.That(application.UniqueId, Is.EqualTo(appSheetRowDto.UniqueId));
    }

    [Test]
    public void SingleClassToSingleClass_List()
    {
        //Arrange:
        var appSheetRowDtos = GetAppSheetRowDtos();

        //Act:
        var applications = mapper.Map<IEnumerable<Application>>(appSheetRowDtos);

        //Assert:
        Assert.Multiple(() =>
        {
            Assert.That(applications.Count, Is.EqualTo(2));
            Assert.That(applications.First().UniqueId, Is.EqualTo(appSheetRowDtos.First().UniqueId));
            Assert.That(applications.Last().UniqueId, Is.EqualTo(appSheetRowDtos.Last().UniqueId));
            Assert.That(applications.First().FirstName, Is.EqualTo(appSheetRowDtos.First().FirstName));
            Assert.That(applications.Last().FirstName, Is.EqualTo(appSheetRowDtos.Last().FirstName));
            Assert.That(applications.First().LastName, Is.EqualTo(appSheetRowDtos.First().LastName));
            Assert.That(applications.Last().LastName, Is.EqualTo(appSheetRowDtos.Last().LastName));
            Assert.That(applications.First().EmailAddress, Is.EqualTo(appSheetRowDtos.First().EmailAddress));
            Assert.That(applications.Last().JobApplicationId.ToString(), Is.EqualTo(appSheetRowDtos.Last().JobApplicationId));
            Assert.That(applications.Last().PhoneNumber.ToString(), Is.EqualTo(appSheetRowDtos.Last().PhoneNumber));
            Assert.That(((DateTime)applications.Last().StartDate!).ToString("MM/dd/yyyy"), Is.EqualTo(appSheetRowDtos.Last().StartDate));
        });
    }

    private AppSheetRowDto GetAppSheetRowDto()
    {
        return new()
        {
            UniqueId = "uniqueId",
            FirstName = "firstName",
            LastName = "lastName",
            EmailAddress = "test@gmail.com",
            JobApplicationId = "123456",
            PhoneNumber = "4441231234",
            StartDate = "02/15/2024"
        };
    }

    private IEnumerable<AppSheetRowDto> GetAppSheetRowDtos()
    {
        var rows = new List<AppSheetRowDto>(){
            new()
            {
                UniqueId = "uniqueId1",
                FirstName = "firstName",
                LastName = "lastName",
                EmailAddress = "test@gmail.com",
                JobApplicationId = "111111",
                PhoneNumber = "1111111111",
                StartDate = "02/15/2024"
            },
            new()
            {
                UniqueId = "uniqueId2",
                FirstName = "firstName2",
                LastName = "lastName2",
                EmailAddress = "test2@gmail.com",
                JobApplicationId = "222222",
                PhoneNumber = "2222222222",
                StartDate = "02/15/2024"
            }
        };
        return rows;
    }
}
