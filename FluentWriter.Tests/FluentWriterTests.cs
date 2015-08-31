using System;
using NUnit.Framework;

namespace FluentWriter.Tests
{
    [TestFixture]
    public class FluentWriterTests
    {
        [SetUp]
        public void Setup()
        {
            _writer = new FluentWriter();
        }

        private FluentWriter _writer;

        [Test]
        public void ShouldAdd10Characters()
        {
            var x = _writer.FillWith('a', 10).Read();
            Assert.AreEqual(new String('a', 10), x);
        }

        [Test]
        public void ShouldAddNewField()
        {
            var field = _writer.NewField();
            Assert.IsInstanceOf<FluentWriter.FieldWriter>(field);
        }

        [Test]
        public void ShouldAddNewLine()
        {
            var x = _writer.NewLine().Read();
            Assert.AreEqual(Environment.NewLine, x);
        }

        [Test]
        public void ShouldReset()
        {
            var x = _writer.NewField("test").Read();
            Assert.AreEqual(x, "test");
            x = _writer.Reset().Read();
            Assert.AreEqual(x, string.Empty);
        }

        [Test]
        public void ShouldReturnEmptyOnNullInput()
        {
            var x = _writer.NewField(null).Read();
            Assert.AreEqual(x, string.Empty);
        }

        [Test]
        public void ShouldWriteDates()
        {
            var x = _writer.NewField(DateTime.Today, "ddMMyyyy").Read();
            Assert.AreEqual(DateTime.Today.ToString("ddMMyyyy"), x);
        }

        [Test]
        public void ShouldWriteDatesWithFunc()
        {
            var x = _writer.NewField(DateTime.Today, p => p.TakeFirst(2), "ddMMMyyyy").Read();
            Assert.AreEqual(DateTime.Today.ToString("ddMMMyyyy").Substring(0, 2), x);
        }

        [Test]
        public void ShouldWriteDatesWithFuncWhenDateNull()
        {
            var x = _writer.NewField((DateTime?) null, p => p.TakeFirst(2), "ddMMMyyyy").Read();
            Assert.AreEqual(string.Empty, x);
        }

        [Test]
        public void ShouldWriteDecimals()
        {
            var x = _writer.NewField(0.987m).Read();
            Assert.AreEqual("0.99", x);
        }

        [Test]
        public void ShouldWriteDecimalsWithFunc()
        {
            var x = _writer.NewField(0.987m, p => p.TakeLast(2)).Read();
            Assert.AreEqual("99", x);
        }

        [Test]
        public void ShouldWriteTest()
        {
            var x = _writer.NewField("test").Read();
            Assert.AreEqual(x, "test");
        }
    }
}