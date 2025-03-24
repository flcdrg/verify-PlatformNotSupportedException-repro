using System.Threading.Tasks;
using Moq;

namespace Tests;

public class ReproduceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        var mock = new Mock<ISomething>();
        var sut = new Query(mock.Object, new OtherThing());
        var query = sut.BuildQuery("stuff");

        await Verify(query);
    }
}

public interface ISomething
{
}

public class OtherThing
{
}

public class Query
{
    private readonly ISomething _something;
    private readonly OtherThing _otherThing;

    public Query(ISomething something, OtherThing otherThing)
    {
        _something = something;
        _otherThing = otherThing;
    }

    public string BuildQuery(string parameters)
    {
        return "query";
    }
} 
