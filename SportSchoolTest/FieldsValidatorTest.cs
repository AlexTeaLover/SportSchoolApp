using SportSchool._processing;
using System.Windows.Controls;

namespace SportSchoolTest
{
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class FieldsValidatorTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<TextBox> list = new()
            {
                new TextBox(), new TextBox(), new TextBox()
            };

            Assert.That(FieldsValidator.IsValid(list), Is.EqualTo(false));
        }

        [Test]
        public void Test2()
        {
            List<TextBox> list = new()
            {
                new TextBox(){Text = "Template" }, new TextBox(){Text = "Template" }, new TextBox(){Text = "Template" }
            };

            Assert.That(FieldsValidator.IsValid(list), Is.EqualTo(true));
        }

        [Test]
        public void Test3()
        {
            List<TextBox> list = new()
            {
                new TextBox(){Text = "" }, new TextBox(){Text = "" }, new TextBox(){Text = "Template" }
            };

            Assert.That(FieldsValidator.IsValid(list), Is.EqualTo(false));
        }
    }
}