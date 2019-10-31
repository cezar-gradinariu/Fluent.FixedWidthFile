# 

The purpose of this little project is to offer very simple way of interacting - validating, reading & writing - fixed-width format files.

Let's take for example a type like **Ship**

```csharp
        class Ship
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
``` 

which represents a line in a fixed-width file like

```text
ElizabethII   120000     02000      01.05.1950          50        
```

## Reading

I would like to see if the line is valid and, if it is valid I would like to deserialize it into an object of type **Ship**

```csharp
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
```


## Writing


