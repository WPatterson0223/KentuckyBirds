using System;
using System.Data;
using Dapper;

namespace KentuckyBirds.Models
{
	public class BirdRepository : IBirdRepository
	{
        private readonly IDbConnection _connection;
		public BirdRepository(IDbConnection connection)
		{
            _connection = connection;
		}

        public IEnumerable<Stats> GetAllBirds()
        {
            return _connection.Query<Stats>("SELECT * FROM Stats;");
        }
        public Stats GetBird(int id)
        {
            return _connection.QuerySingleOrDefault<Stats>("SELECT * FROM Stats WHERE ID = @id",
                new { ID = id });
        }
        public void UpdateBird(Stats bird)
        {
            _connection.Execute("UPDATE Stats SET Name = @Name, LatinName = @LatinName, Length = @Length, Height = @Height, Wingspan = @Wingspan WHERE ID = @ID",
             new { name = bird.Name, LatinName = bird.LatinName, Length = bird.Length, Height = bird.Height, Wingspan = bird.Wingspan, ID = bird.ID });
        }
        public void InsertBird(Stats birdToInsert)
        {
            _connection.Execute("INSERT INTO Stats (Name, LatinName, Length, Height, Wingspan) VALUES (@Name, @LatinName, @Length, @Height, @Wingspan);",
                new { name = birdToInsert.Name, LatinName = birdToInsert.LatinName, Length = birdToInsert.Length, Height = birdToInsert.Height, Wingspan = birdToInsert.Wingspan});
        }
        public void DeleteBird(Stats bird)
        {
            _connection.Execute("DELETE FROM Stats WHERE ID = @ID;", new { ID = bird.ID });
            _connection.Execute("DELETE FROM Traits WHERE ID = @ID;", new { ID = bird.ID });
            _connection.Execute("DELETE FROM TimeOfYear WHERE ID = @ID;", new { ID = bird.ID });
        }



        public IEnumerable<Checklist> GetAllBirdsChecklist()
        {
            return _connection.Query<Checklist>("SELECT * FROM Checklist;");
        }
        public Checklist GetBirdChecklist(int id)
        {
            return _connection.QuerySingleOrDefault<Checklist>("SELECT * FROM Checklist WHERE ID = @id",
                new { ID = id });
        }
        public void UpdateBird(Checklist bird)
        {
            _connection.Execute("UPDATE Checklist SET Name = @Name, LatinName = @LatinName, Length = @Length, Height = @Height, Wingspan = @Wingspan, Comment = @Comment WHERE ID = @ID",
             new { name = bird.Name, LatinName = bird.LatinName, Length = bird.Length, Height = bird.Height, Wingspan = bird.Wingspan, Comment = bird.Comment, ID = bird.ID });
        }
        public void InsertBird(Checklist birdToInsert)
        {
            _connection.Execute("INSERT INTO Checklist (Name, LatinName, Length, Height, Wingspan, Comment) VALUES (@Name, @LatinName, @Length, @Height, @Wingspan, @Comment);",
                new { name = birdToInsert.Name, LatinName = birdToInsert.LatinName, Length = birdToInsert.Length, Height = birdToInsert.Height, Wingspan = birdToInsert.Wingspan, Comment = birdToInsert.Comment});
        }
        public void DeleteBird(Checklist bird)
        {
            _connection.Execute("DELETE FROM Checklist WHERE ID = @ID;", new { ID = bird.ID });
        }
        public void InsertChecklistFromStats(Stats birdToInsert)
        {
            _connection.Execute("INSERT INTO Checklist (Name, LatinName, Length, Height, Wingspan) VALUES (@Name, @LatinName, @Length, @Height, @Wingspan);",
                new { name = birdToInsert.Name, LatinName = birdToInsert.LatinName, Length = birdToInsert.Length, Height = birdToInsert.Height, Wingspan = birdToInsert.Wingspan});
        }



        public IEnumerable<Traits> GetAllBirdsTraits()
        {
            return _connection.Query<Traits>("SELECT * FROM Traits;");
        }
        public Traits GetBirdTraits(int id)
        {
            return _connection.QuerySingleOrDefault<Traits>("SELECT * FROM Traits WHERE ID = @id",
                new { ID = id });
        }
        public void UpdateBird(Traits bird)
        {
            _connection.Execute("UPDATE Traits SET Name = @Name, LatinName = @LatinName, Length = @Length, Height = @Height, Wingspan = @Wingspan WHERE ID = @ID",
             new { name = bird.Name, LatinName = bird.LatinName, Length = bird.Length, Height = bird.Height, Wingspan = bird.Wingspan, ID = bird.ID });
        }
        public void InsertBird(Traits birdToInsert)
        {
            _connection.Execute("INSERT INTO Traits (Name, LatinName, Length, Height, Wingspan) VALUES (@Name, @LatinName, @Length, @Height, @Wingspan);",
                new { name = birdToInsert.Name, LatinName = birdToInsert.LatinName, Length = birdToInsert.Length, Height = birdToInsert.Height, Wingspan = birdToInsert.Wingspan });
        }
        public void DeleteBird(Traits bird)
        {
            _connection.Execute("DELETE FROM Traits WHERE ID = @ID;", new { ID = bird.ID });
        }
        public void InsertChecklistFromTraits(Traits birdToInsert)
        {
            _connection.Execute("INSERT INTO Checklist (Name, LatinName, Length, Height, Wingspan) VALUES (@Name, @LatinName, @Length, @Height, @Wingspan);",
                new { name = birdToInsert.Name, LatinName = birdToInsert.LatinName, Length = birdToInsert.Length, Height = birdToInsert.Height, Wingspan = birdToInsert.Wingspan });
        }

    }
}

