using NUnit.Framework;

namespace Application.IntegrationTests;

[TestFixture]
public abstract class BaseTestFixture
{
    public Testing testing;
    public BaseTestFixture()
    {
        testing = new Testing();
    }
    [SetUp]
    public async Task TestSetUp()
    {
        await testing.ResetState();
    }
}
