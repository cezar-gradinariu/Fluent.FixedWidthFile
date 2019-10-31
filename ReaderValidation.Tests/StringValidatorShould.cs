using NUnit.Framework;

namespace ReaderValidation.Tests
{
    [TestFixture]
    public class StringValidatorShould
    {
        [Test]
        public void ValidateEmptyInputAgainstRequirements()
        {
            const string detail = "";
            var validatorResult = new StringValidator(detail)
                .CheckLengthRange(35, 44)
                .ForNext(2, "Street number").ExpectThat(Is.Valued, Is.Long)
                .ForNext(12, "Surname").ExpectThat(Is.Valued)
                .ForNext(11, "First Name/Initial").ExpectThat(Is.Optional)
                .ForNext(8, "Birthday").ExpectThat(Is.Valued, Is.DateTime("dd/MM/yy"))
                .ForNext(2, "Filler").ExpectThat(Is.EqualTo(new string(' ', 2)))
                .ForNext(9, "Monthly income").ExpectThat(Is.Valued, Is.Decimal)
                .Read();

            Assert.AreEqual(validatorResult.SegmentErrors.Count, 7);
            Assert.IsTrue(validatorResult.HasErrors);
        }

        [Test]
        public void ValidateWithNoErrors()
        {
            const string detail = " 2Einstein    Albert     01/01/78  25000.50";
            var validatorResult = new StringValidator(detail)
                .CheckLengthRange(35, 44)
                .ForNext(2, "Street number").ExpectThat(Is.Valued, Is.Long)
                .ForNext(12, "Surname").ExpectThat(Is.Valued)
                .ForNext(11, "First Name/Initial").ExpectThat(Is.Optional)
                .ForNext(8, "Birthday").ExpectThat(Is.Valued, Is.DateTime("dd/MM/yy"))
                .ForNext(2, "Filler").ExpectThat(Is.EqualTo(new string(' ', 2)))
                .ForNext(9, "Monthly income").ExpectThat(Is.Valued, Is.Decimal)
                .Read();

            Assert.IsFalse(validatorResult.HasErrors);
        }
    }
}