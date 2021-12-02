import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api-service';
import { Subscription } from 'rxjs';
import { analyzeAndValidateNgModules, componentFactoryName } from '@angular/compiler';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  authors: any[] = [];
  authorSubscription: Subscription;
  books: any[] = [];
  bookSubscription: Subscription;

  constructor(private service: ApiService) {
    this.authorSubscription = this.service.authorsSubject.subscribe(
      (authors: any[]) => {
        authors.forEach(author => {
          author.fullName = author.firstName + " " + author.lastName;
        });
        this.authors = authors;
      }
    );
    this.bookSubscription = this.service.booksSubject.subscribe(
      (books: any[]) => {
        this.books = books;
      }
    );
    this.service.emitAuthorSubject();
    this.service.emitBooksSubject();
   }

  ngOnInit(): void {
  }

  updateBook(event: any)
  {
    if (event.data.name && event.data.isbn && event.data.authorId)
      this.service.updateBook(event.key, event.data);
  }

  createBook(event: any)
  { 
    if (event.data.name && event.data.isbn && event.data.authorId)
      this.service.createBook(event.data);
  }

  // onAuthorValueChanged(event: any, author: any)
  // {
  //   author.data.authorId = event.value;
  //   // event.component.text = event.value;
  //   // console.log(event);
  //   // console.log(author);
  //   if (event.data.name && event.data.isbn && event.data.authorId)
  //     this.service.updateBook(event.key, event.data);
  // }

  // onContentReady(event: any)
  // {
  //   console.log("contentReady");
  //   console.log(event);
  // }

  onAuthorValueChanged(event: any)
  {
  }
}
