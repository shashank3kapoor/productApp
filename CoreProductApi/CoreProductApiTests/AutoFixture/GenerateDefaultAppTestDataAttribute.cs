using AutoFixture;
using AutoFixture.Xunit2;

namespace CoreProductApiTests.AutoFixture
{
    public class GenerateDefaultAppTestDataAttribute : AutoDataAttribute
    {
        public GenerateDefaultAppTestDataAttribute() : base(GetDefaultFixture)
        {
        }

        public static IFixture GetDefaultFixture()
        {
            return new Fixture()
                .Customize(new AppTestCustomization());
        }
    }
}
