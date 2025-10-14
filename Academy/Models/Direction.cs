using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
	public class Direction
	{
		[Key]
		[Display(Name ="ID направления")]
		public byte direction_id { get; set; }

		[Required]
		[StringLength(100)]
		[Display(Name = "Название напрвления")]
		public string? direction_name { get; set; }

		//Nav prop
		public ICollection<Group> Groups { get; set; }
	}
}
