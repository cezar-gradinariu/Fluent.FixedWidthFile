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

        private class Ship
        {
            public string Name { get; set; }
            public int RegistrationNumber { get; set; }
            public int? CrewSize { get; set; }
            public decimal DeadWeight { get; set; }
            public decimal? CargoWeight { get; set; }
            public DateTime FirstVoyage { get; set; }
            public DateTime? RecyclingDate { get; set; }

            public ulong Age { get; set; }
            public ulong? Speed { get; set; }
        }

        [Test]
        public void ShouldAdd10Characters()
        {
            var x = _writer.FillWith('a', 10).Read();
            Assert.AreEqual(new string('a', 10), x);
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
        public void ShouldCorrectlyWriteTheLine()
        {
            var ship = new Ship
            {
                Name = "ElizabethII",
                Age = 50,
                FirstVoyage = new DateTime(1950, 5, 1),
                CargoWeight = null,
                RegistrationNumber = 120000,
                Speed = null,
                CrewSize = null,
                RecyclingDate = null,
                DeadWeight = 2000
            };
            var line = _writer
                .NewField(ship.Name, writer => writer.TakeFirst(14).LeftJustify(14))
                .NewField(ship.RegistrationNumber, writer => writer.TakeFirst(6).RightJustify(6), "F0")
                .NewField(ship.CrewSize, writer => writer.TakeFirst(3).RightJustify(3), "F0")
                .FillWith(' ', 2)
                .NewField(ship.DeadWeight, writer => writer.TakeFirst(5).RightJustify(5, '0'), "F0")
                .NewField(ship.CargoWeight, writer => writer.TakeFirst(6).RightJustify(6), "D0")
                .NewField(ship.FirstVoyage, writer => writer.RightJustify(10), "dd.MM.yyyy")
                .NewField(ship.RecyclingDate, writer => writer.RightJustify(10), "dd.MM.yyyy")
                .NewField(ship.Age, writer => writer.TakeFirst(2).RightJustify(2), "F0")
                .NewField(ship.Speed, writer => writer.TakeFirst(2).RightJustify(2), "F0")
                .FillWith(' ', 6)
                .Read();

            const string expected = "ElizabethII   120000     02000      01.05.1950          50        ";
            Assert.AreEqual(expected, line);
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