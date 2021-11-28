﻿using AutoMapper;
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
			CreateMap<Author, AuthorDto>()
				.ForMember(a => a.Books, opt => opt.MapFrom(src => src.Books));
			CreateMap<AuthorForCreationDto, Author>();
			CreateMap<Book, BookDto>();
			CreateMap<BookForCreationDto, Book>();
		}
	}
}