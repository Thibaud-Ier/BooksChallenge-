using AutoMapper;
using Entities.DTO.Authors;
using Entities.DTO.Books;
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
			CreateMap<Author, AuthorDto>()
				.ForMember(a => a.Books, opt => opt.MapFrom(src => src.Books));
			CreateMap<AuthorForCreationDto, Author>();
			CreateMap<AuthorForUpdateDto, Author>();
			CreateMap<Book, BookDto>();
			CreateMap<BookForCreationDto, Book>();
			CreateMap<BookForUpdateDto, Book>();
		}
	}
}