using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
	public class Group
	{
		[Key]
		[Display(Name ="ID группы")]
		public int group_id { get; set; }

		[Required]
		[StringLength(10)]
		[Display(Name = "Название группы")]
		public string? group_name { get; set; }

		[Display(Name = "Направление")]
		[Column("direction")]
		public byte direction { get; set; }

		[Display(Name = "Дни недели")]
		public byte? weekdays { get; set; }

		[DataType(DataType.Time)]
		[Display(Name = "Время начала")]
		public TimeSpan? start_time { get; set; }

		//Nav prop:
		public Direction Direction { get; set; }
		public ICollection<Student> Students { get; set; }

	}
}
