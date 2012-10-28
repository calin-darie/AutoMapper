using NUnit.Framework;
using Should;
using NUnit.Framework.SyntaxHelpers;
namespace AutoMapper.UnitTests
{
    namespace MappingToPropertyWithoutGetter
    {
        [TestFixture]
        public class MappingToPropertyWithoutGetter
        {
            [TestFixtureSetUp]
            public void SetUp()
            {
                Mapper.CreateMap<Source, Target>();
            }

            [Test]
            public void Should_Not_Throw()
            {
                var source = new Source { Property = "foo bar" };
                var target = Mapper.Map<Source, Target>(source);
                Assert.That(target.GetProperty(), Is.EqualTo(source.Property));
            }
        }

        public class Source
        {
            public string Property { get; set; }
        }

        public class Target
        {
            private string property;
            public string Property
            {
                set { property = value; }
            }

            public string GetProperty()
            {
                return property;
            }
        }

    }
}