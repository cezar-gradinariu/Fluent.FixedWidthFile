using System;
using NUnit.Framework;

namespace FluentReader.Tests
{
    [TestFixture]
    public class FluentReaderTests
    {
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
        public void ShouldFailWithConversionErrors()
        {
            const string line = "  ElizabethII tst0000a5  0b000002r0001/05/195001/01/2050ab-1";
            var reader = new FluentReader<Ship>(line);
            var readerResult = reader
                .Set(p => p.Name, p => p.Take(14).Trim().ToLowerCase())
                .Set(p => p.RegistrationNumber, p => p.Take(6))
                .Set(p => p.CrewSize, p => p.Take(3))
                .Skip(2)
                .Set(p => p.DeadWeight, p => p.Skip(1).Take(4))
                .Set(p => p.CargoWeight, p => p.Take(6))
                .Set(p => p.FirstVoyage, p => p.Take(10), "dd.MM.yyyy")
                .Set(p => p.RecyclingDate, p => p.Take(10), "dd.MM.yyyy")
                .Set(p => p.Age, p => p.Take(2))
                .Set(p => p.Speed, p => p.Take(2))
                .Read();

            Assert.IsTrue(readerResult.LineError.HasErrors);
            Assert.IsNull(readerResult.Result);
            var errors = readerResult.LineError.SegmentErrors;
            Assert.AreEqual(8, errors.Count);
            Assert.AreEqual(line, readerResult.LineError.SourceLine);
        }

        [Test]
        public void ShouldReadGivenLine1()
        {
            const string line = "ElizabethII   120000     02000      01.05.1950          50        ";
            var reader = new FluentReader<Ship>(line);
            var readerResult = reader
                .Set(p => p.Name, p => p.Take(14).TrimEnd())
                .Set(p => p.RegistrationNumber, p => p.Take(6))
                .Set(p => p.CrewSize, p => p.Take(3))
                .Skip(2)
                .Set(p => p.DeadWeight, p => p.Take(5))
                .Set(p => p.CargoWeight, p => p.Take(6))
                .Set(p => p.FirstVoyage, p => p.Take(10), "dd.MM.yyyy")
                .Set(p => p.RecyclingDate, p => p.Take(10), "dd.MM.yyyy")
                .Set(p => p.Age, p => p.Take(2))
                .Set(p => p.Speed, p => p.Take(2))
                .Read();
            Assert.IsNull(readerResult.LineError);
            var ship = readerResult.Result;
            Assert.IsNotNull(ship);
            Assert.IsNull(ship.CrewSize);
            Assert.IsNull(ship.CargoWeight);
            Assert.IsNull(ship.RecyclingDate);
            Assert.AreEqual("ElizabethII", ship.Name);
            Assert.AreEqual(2000, ship.DeadWeight);
            Assert.AreEqual(120000, ship.RegistrationNumber);
            Assert.AreEqual(new DateTime(1950, 5, 1), ship.FirstVoyage);
            Assert.AreEqual(50, ship.Age);
            Assert.IsNull(ship.Speed);
        }

        [Test]
        public void ShouldReadGivenLine2()
        {
            const string line = "  ElizabethII 120000015  0200000250001.05.195001.01.205050031        ";
            var reader = new FluentReader<Ship>(line);
            var readerResult = reader
                .Set(p => p.Name, p => p.Take(14).Trim().ToLowerCase())
                .Set(p => p.RegistrationNumber, p => p.Take(6))
                .Set(p => p.CrewSize, p => p.Take(3))
                .Skip(2)
                .Set(p => p.DeadWeight, p => p.Skip(1).Take(4))
                .Set(p => p.CargoWeight, p => p.Take(6))
                .Set(p => p.FirstVoyage, p => p.Take(10), "dd.MM.yyyy")
                .Set(p => p.RecyclingDate, p => p.Take(10), "dd.MM.yyyy")
                .Set(p => p.Age, p => p.Take(2))
                .Set(p => p.Speed, p => p.Take(3))
                .Read();

            Assert.IsNull(readerResult.LineError);
            var ship = readerResult.Result;
            Assert.IsNotNull(ship);
            Assert.AreEqual(15, ship.CrewSize);
            Assert.AreEqual(2500, ship.CargoWeight);
            Assert.AreEqual(new DateTime(2050, 1, 1), ship.RecyclingDate);
            Assert.AreEqual("elizabethii", ship.Name);
            Assert.AreEqual(2000, ship.DeadWeight);
            Assert.AreEqual(120000, ship.RegistrationNumber);
            Assert.AreEqual(new DateTime(1950, 5, 1), ship.FirstVoyage);
            Assert.AreEqual(50, ship.Age);
            Assert.AreEqual(31, ship.Speed);
        }
    }
}