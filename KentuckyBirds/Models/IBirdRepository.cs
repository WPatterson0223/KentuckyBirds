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

        public IEnumerable<Checklist> GetAllBirdsChecklist();
        public Checklist GetBirdChecklist(int id);
        public void UpdateBird(Checklist bird);
        public void InsertBird(Checklist birdToInsert);
        public void DeleteBird(Checklist bird);
        public void InsertChecklistFromStats(Stats birdToInsert);

        public IEnumerable<Traits> GetAllBirdsTraits();
        public Traits GetBirdTraits(int id);
        public void UpdateBird(Traits bird);
        public void InsertBird(Traits birdToInsert);
        public void DeleteBird(Traits bird);
        public void InsertChecklistFromTraits(Traits birdToInsert);
    }
}

