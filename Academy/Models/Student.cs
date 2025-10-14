using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Academy.Models
{
	public class Student
	{
		[Key]
		[Display(Name = "ID студента")]
		public int stud_id { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Фамилия")]
		public string last_name { get; set; }

		[Required]
		[StringLength(50)]
		[Display(Name = "Имя")]
		public string first_name { get; set; }

		
		[StringLength(50)]
		[Display(Name = "Отчество")]
		public string? middle_name { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Дата рождения")]
		public DateTime birth_date { get; set; }

		[EmailAddress]
		[StringLength (50)]
		[Display(Name = "Email")]
		public string? email { get; set; }

		[StringLength(16)]
		[Display(Name = "Телефон")]
		public string? phone {  get; set; }

		[Display(Name ="Фото")]
		public byte[]? photo { get; set; }

		[Display(Name = "Группа")]
		
		public int group_id {  get; set; }

		//Nav prop:
		[ForeignKey("GroupID")]
		public Group Groups {  get; set; }

		//Calc prop:
		[Display(Name ="Полное имя")]
		public string FullName => $"{last_name} {first_name}".Trim();
		[Display(Name = "ФИО")]
		public string ShortName => $"{last_name} {first_name?.Substring(0, 1)}.{middle_name?.Substring(0, 1)}.";
	}
}
