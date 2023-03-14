using System;
namespace KentuckyBirds.Models
{
	public interface IBirdRepository
	{
		public IEnumerable<Stats> GetAllBirds();
		public Stats GetBird(int id);
		public void UpdateBird(Stats bird);
        public void InsertBird(Stats birdToInsert);
        public void DeleteBird(Stats bird);

    }
}

