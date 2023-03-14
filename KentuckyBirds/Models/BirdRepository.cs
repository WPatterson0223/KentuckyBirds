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
    }
}

