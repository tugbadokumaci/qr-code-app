using System;
using System.ComponentModel.DataAnnotations;

namespace QrCodeApp.Shared.Models
{
	public class CardModel
	{
		[Key]
		public int CardId { get; set; }
		public int CreatorId { get; set; }
        public String CardTitle{ get; set; }
		public String CardDescription{ get; set; }


    }
}

