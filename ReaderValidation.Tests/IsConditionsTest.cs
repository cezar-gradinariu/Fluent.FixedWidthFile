using NUnit.Framework;

namespace ReaderValidation.Tests
{
    [TestFixture]
    public class IsConditionsTest
    {
        [TestCase("100", true)]
        [TestCase("1 00f", false)]
        public void ShouldValidateIntegger(string sampleValue, bool shouldPass)
        {
            var result = Is.Integer(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase("-100", true)]
        [TestCase("100000000000", true)]
        [TestCase("not a long number", false)]
        public void ShouldValidateLong(string sampleValue, bool shouldPass)
        {
            var result = Is.Long(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase("-100", true)]
        [TestCase("100000000000", true)]
        [TestCase("1000000.1300002", true)]
        [TestCase("not a decimal number", false)]
        public void ShouldValidateDecimal(string sampleValue, bool shouldPass)
        {
            var result = Is.Decimal(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase(null, false)]
        [TestCase("not null", true)]
        [TestCase("", true)]
        public void ShouldValidateNotNull(string sampleValue, bool shouldPass)
        {
            var result = Is.NotNull(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase(null, false)]
        [TestCase("not null", true)]
        [TestCase("", false)]
        [TestCase("  ", false)]
        public void ShouldValidateValued(string sampleValue, bool shouldPass)
        {
            var result = Is.Valued(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }


        [TestCase(null, null, false)]
        [TestCase("", null, false)]
        [TestCase("a", "ab", false)]
        [TestCase("a", "A", false)]
        [TestCase("", "", true)]
        [TestCase("a", "a", true)]
        public void ShouldValidateEqualTo(string sampleValue, string equalTo, bool shouldPass)
        {
            var result = Is.EqualTo(equalTo)(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase(null, null, false)]
        [TestCase("", null, false)]
        [TestCase("12.15.2000", "dd.MM.yyyy", false)]
        [TestCase("15.15.2000", "MM.dd.yyyy", false)]
        [TestCase("12.15.2000", "MM.dd.yyyy", true)]
        [TestCase("12.01.2200", "dd.MM.yyyy", true)]
        public void ShouldValidateDateTime(string sampleValue, string exactFormat, bool shouldPass)
        {
            var result = Is.DateTime(exactFormat)(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase(null, false)]
        [TestCase("a", true)]
        [TestCase("test", true)]
        [TestCase("", true)]
        [TestCase("not in list", false)]
        public void ShouldValidateOneOf(string sampleValue, bool shouldPass)
        {
            var result = Is.OneOf(null, "test", "a", string.Empty)(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }

        [TestCase(null, null, false)]
        [TestCase("", null, false)]
        [TestCase("   ", null, false)]
        [TestCase("a", "\\w*", true)]
        [TestCase("test", "test", true)]
        [TestCase("1234", "\\d{3}", true)]
        [TestCase("1234", "\\d{4}", true)]
        public void ShouldValidateRegex(string sampleValue, string regex, bool shouldPass)
        {
            var result = Is.Matching(regex)(new Is(sampleValue, "sample"));
            PerformAssertions(sampleValue, shouldPass, result);
        }


        private static void PerformAssertions(string sampleValue, bool shouldPass, SegmentError result)
        {
            if (shouldPass)
            {
                Assert.IsNull(result);
                return;
            }

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Message);
            Assert.AreEqual(sampleValue, result.Source);
            Assert.AreEqual(result.SegmentName, "sample");
        }
    }
}