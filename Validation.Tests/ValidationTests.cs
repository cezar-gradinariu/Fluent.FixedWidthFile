using NUnit.Framework;

namespace Validation.Tests
{
    [TestFixture]
    public class ValidationTests
    {
        public class TestData
        {
            public string AString { get; set; }
            public int AnInt { get; set; }
            public int? ANullableInt { get; set; }
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void StringIsRequiredShouldFailFor(string source)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.IsRequired(p => p.AString).ReadResults();
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.ValidationResults.Count);
            Assert.AreEqual(result.ValidationResults[0].PropertyName, "AString");
            Assert.IsNotNull(result.ValidationResults[0].ErrorMessage);
        }

        [TestCase("not null")]
        public void StringIsRequiredShouldbeValidFor(string source)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.IsRequired(p => p.AString).ReadResults();
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.ValidationResults.Count);
        }

        [TestCase("ok", 3)]
        [TestCase("ok", 2)]
        [TestCase(null, 4)]
        public void StringMaxLengthShouldValidateFor(string source, int max)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.HasMaxLength(p => p.AString, (uint) max).ReadResults();
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.ValidationResults.Count);
        }

        [TestCase("ok1", "ok1")]
        [TestCase("ok2", "ok2")]
        public void IsEqualToShouldValidateFor(string source, string compareTo)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.IsEqualTo(p => p.AString, compareTo).ReadResults();
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.ValidationResults.Count);
        }

        [TestCase("ok1", "ok2")]
        [TestCase("ok2", "")]
        [TestCase(null, null)]
        [TestCase(null, "anything")]
        public void IsEqualToShouldFailToValidateFor(string source, string compareTo)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.IsEqualTo(p => p.AString, compareTo).ReadResults();
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.ValidationResults.Count);
        }


        [TestCase("ok1", "ok1")]
        [TestCase("ok2", "ok")]
        public void StartsWithShouldValidateFor(string source, string startsWith)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.StartsWith(p => p.AString, startsWith).ReadResults();
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.ValidationResults.Count);
        }

        [TestCase("ok1", "ok2")]
        [TestCase("ok2", "")]
        [TestCase(null, null)]
        [TestCase(null, "anything")]
        [TestCase("anything", "")]
        [TestCase("test", "1test")]
        [TestCase("test", "TE")]
        public void StartsWithShouldFailToValidateFor(string source, string startsWith)
        {
            var data = new TestData {AString = source};
            var validator = new Validation<TestData>(data);
            var result = validator.IsEqualTo(p => p.AString, startsWith).ReadResults();
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.ValidationResults.Count);
        }


        [Test]
        public void CustomRuleShouldFail()
        {
            var data = new TestData {AString = "any would do"};
            var validator = new Validation<TestData>(data);
            var result =
                validator.CustomRule(p => p.AString, p => p.Contains("not here"), "Failed").ReadResults();
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.ValidationResults.Count);
            Assert.AreEqual(result.ValidationResults[0].PropertyName, "AString");
            Assert.AreEqual("Failed", result.ValidationResults[0].ErrorMessage);
        }

        [Test]
        public void CustomRuleShouldValidates()
        {
            var data = new TestData {AString = "any would do"};
            var validator = new Validation<TestData>(data);
            var result =
                validator.CustomRule(p => p.AString, p => p.Contains("would"), "Failed").ReadResults();
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.ValidationResults.Count);
        }

        [Test]
        public void ObjectIsRequiredShouldBeValid()
        {
            var data = new TestData {ANullableInt = 10};
            var validator = new Validation<TestData>(data);
            var result = validator.IsRequired(p => p.ANullableInt).ReadResults();
            Assert.IsTrue(result.IsValid);
            Assert.AreEqual(0, result.ValidationResults.Count);
        }

        [Test]
        public void ObjectIsRequiredShouldFailOnNull()
        {
            var data = new TestData {ANullableInt = null};
            var validator = new Validation<TestData>(data);
            var result = validator.IsRequired(p => p.ANullableInt).ReadResults();
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.ValidationResults.Count);
            Assert.AreEqual(result.ValidationResults[0].PropertyName, "ANullableInt");
            Assert.IsNotNull(result.ValidationResults[0].ErrorMessage);
        }

        [Test]
        public void StringMaxLengthShouldFailFor()
        {
            var data = new TestData {AString = "too much"};
            var validator = new Validation<TestData>(data);
            var result = validator.HasMaxLength(p => p.AString, 3).ReadResults();
            Assert.IsFalse(result.IsValid);
            Assert.AreEqual(1, result.ValidationResults.Count);
            Assert.AreEqual(result.ValidationResults[0].PropertyName, "AString");
            Assert.IsNotNull(result.ValidationResults[0].ErrorMessage);
        }
    }
}