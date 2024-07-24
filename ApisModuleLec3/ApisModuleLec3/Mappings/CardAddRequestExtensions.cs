using ApisModuleLec3.DTOs.Card;
using ApisModuleLec3.Models;

namespace ApisModuleLec3.Mappings
{
	public static class CardAddRequestExtensions
	{
		public static Card ToCard(this CardAddRequest cardAddRequest, string userId)
		{
			return new Card
			{
				UserId = userId,
				Title = cardAddRequest.Title,
				Subtitle = cardAddRequest.Subtitle,
				Description = cardAddRequest.Description,
				Phone = cardAddRequest.Phone,
				Email = cardAddRequest.Email,
				Web = cardAddRequest.Web,
				Image = cardAddRequest.Image,
				Address = cardAddRequest.Address
			};
		}
	}
}


//var card = dto.ToCard(userId);
//var card = new Card(dto, userId);