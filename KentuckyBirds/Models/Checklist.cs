using System;
namespace KentuckyBirds.Models
{
	public class Checklist
	{
		public Checklist()
		{
		}
        public int ID { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Wingspan { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
    }
}

