using SportSchool._processing;

namespace SportSchoolTest
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class DateTimeToDateConverterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DateTimeToDateConverter converter = new();
            var convertedValue = converter.Convert(null, typeof(string), typeof(DateTime), null);
            Assert.That(convertedValue, Is.EqualTo("-"));
        }

        [Test]
        public void Test2()
        {
            DateTimeToDateConverter converter = new();
            var convertedValue = converter.Convert(Convert.ToDateTime("09.09.2004 12:00AM"), typeof(string), typeof(DateTime), null);
            Assert.That(convertedValue, Is.EqualTo("09.09.2004"));
        }
    }
}
