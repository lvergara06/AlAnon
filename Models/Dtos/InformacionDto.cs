﻿using System.ComponentModel.DataAnnotations;

namespace AlAnonFront.Models.Dtos
{
	public class InformacionDto
	{
		public int InfoId { get; set; }
		[Required]
		[DataType(DataType.PhoneNumber)]
		public string NumeroIntegrupal { get; set; } = "(000) 000-0000";
		[DataType(DataType.PhoneNumber)]
		public string IntergroupPhoneNumber { get; set; }  = "(000) 000-0000";
		public bool EsValida { get; set; }
		public DateTime DiaInsertada { get; set; }
		public DateTime DiaCerrada { get; set; }
		public string UsuarioId { get; set; } = string.Empty;
	}
}
