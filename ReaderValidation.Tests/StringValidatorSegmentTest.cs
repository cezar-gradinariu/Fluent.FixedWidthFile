using NUnit.Framework;

namespace ReaderValidation.Tests
{
    [TestFixture]
    public class StringValidatorSegmentTest
    {
        private StringValidator.Segment _segment;

        [Test]
        public void ShouldValidateAllConditions()
        {
            //Reads multiple validation conditions and checks them all.
            _segment = new StringValidator.Segment(new StringValidator(""), "1500", "integger");
            var result = _segment.ExpectThat(Is.Valued, Is.Integer).Read();
            Assert.IsFalse(result.HasErrors);
            CollectionAssert.IsEmpty(result.SegmentErrors);
        }

        [Test]
        public void ShouldValidateWhenOnlyErrors()
        {
            //Reads multiple validations , all supposed to fail and returns a list of exactly the same number of errors.
            _segment = new StringValidator.Segment(new StringValidator(""), "1500", "integger");
            var result =
                _segment.ExpectThat(Is.DateTime("ddMMyyyy"), Is.Matching(@"\dr"), Is.OneOf("a", "b", "c")).Read();
            Assert.IsTrue(result.HasErrors);
            Assert.AreEqual(3, result.SegmentErrors.Count);
            CollectionAssert.AllItemsAreUnique(result.SegmentErrors);
            for (var i = 0; i < 3; i++)
            {
                var segmentError = result.SegmentErrors[i];
                Assert.AreEqual("integger", segmentError.SegmentName);
            }
        }
    }
}