using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace BooksChallenge
{
	/// <summary>
	/// Mapping Profile
	/// </summary>
	public class MappingProfile : Profile
	{
		/// <summary>
		/// List of mappings.
		/// </summary>
		public MappingProfile()
		{
			CreateMap<Author, AuthorDTO>()
				.ForMember(a => a.Books, opt => opt.MapFrom(src => src.Books)); ;
			CreateMap<Book, BookDTO>();
		}
	}
}