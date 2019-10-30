The purpose of this little project is to offer very simple way of interacting - validating, reading & writing - fixed-width format files.


Given a type like

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
