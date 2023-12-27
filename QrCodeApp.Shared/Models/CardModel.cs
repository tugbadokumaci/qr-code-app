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
		public String JobTitle{ get; set; }
		public String Phone{ get; set; }
		public String Mail{ get; set; }
		public String WebsiteUrl{ get; set; }
		public String Address{ get; set; }
		public DateTime CreationDate { get; set; }
		public bool IsActive { get; set; }


    }
}

