using NUnit.Framework;
using AutoMapper;
using Should;
namespace AutoMapper.UnitTests
{

    namespace AssertToIgnorePrivateDestSettersFeatureRequest
    {
        public class Foo { public int x { get; set; } }
        public class Bar { public int x { get; private set; } }

        [TestFixture]
        public class WhenMappingToPropertyWithPrivateSetter
        {
            [SetUp]
            public void Setup()
            {
                Mapper.CreateMap<Foo, Bar>();
            }

            [Test]
            public void ShouldIgnoreProperty()
            {
                typeof(AutoMapperConfigurationException).ShouldNotBeThrownBy(Mapper.AssertConfigurationIsValid);
            }
        }
    }
}