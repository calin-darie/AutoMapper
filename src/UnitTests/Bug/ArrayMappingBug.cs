using NUnit.Framework;
using AutoMapper;
using Should;
namespace AutoMapper.UnitTests.Bug
{
    namespace ArrayMappingBug
    {
        public class typeArrayClass1 { public object[] arr { get; set; } }
        public class typeArrayClass2 { public object[] arr { get; set; } }
        [TestFixture]
        public class WhenMappingObjectsHavingArrayProperties
        {
            [SetUp]
            public void SetUp()
            {
                Mapper.CreateMap<typeArrayClass1, typeArrayClass2>();
            }

            [Test]
            public void TestMapperLargerToSmaller()
            {
                var source = new typeArrayClass1 { arr = new object[12] };
                var destination = new typeArrayClass2 { arr = new object[10] };

                Mapper.Map(source, destination);
            }

            [Test]
            public void TestMapperSmallerToLarger()
            {
                const int srcLength = 10;
                var source = new typeArrayClass1 { arr = new object[srcLength] };
                var destination = new typeArrayClass2 { arr = new object[12] };

                Mapper.Map(source, destination);

                destination.arr.Length.ShouldEqual(srcLength);
            }
        }
    }
}