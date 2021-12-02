import { Subject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  authorsSubject = new Subject<any[]>();
  authors: any[] = [];
  booksSubject = new Subject<any[]>();
  books: any[] = [];

  constructor(private httpClient: HttpClient) {
    this.getAuthors();
    this.getBooks();
  }

  emitAuthorSubject() {
    this.authorsSubject.next(this.authors.slice());
  }

  getAuthors() {
    this.httpClient.get<any[]>('https://localhost:44342/api/Authors')
      .subscribe(
        (response: any) => {
          this.authors = response;
          this.emitAuthorSubject();
        },
        (error: any) => {
          console.log('Erreur get authors ! : ');
          console.log(error);
        }
      );
  }

  updateAuthor(id: string, data: any) {
    var body = this.authorToBody(data);
    this.httpClient.put<any[]>("https://localhost:44342/api/Authors/" + id, body)
      .subscribe(
        (response: any) => {
        },
        (error: any) => {
          console.log('Erreur put authors ! : ');
          console.log(error);
        }
      );
  }

  createAuthor(data: any) {
    var body = this.authorToBody(data);
    this.httpClient.post<any[]>("https://localhost:44342/api/Authors/", body)
      .subscribe(
        (response: any) => {
          this.getAuthors();
        },
        (error: any) => {
          console.log('Erreur post authors ! : ');
          console.log(error);
        }
      );
  }

  emitBooksSubject() {
    this.booksSubject.next(this.books.slice());
  }

  getBooks() {
    this.httpClient.get<any[]>('https://localhost:44342/api/Books')
      .subscribe(
        (response: any) => {
          this.books = response;
          this.emitBooksSubject();
        },
        (error: any) => {
          console.log('Erreur get books ! : ');
          console.log(error);
        }
      );
  }

  updateBook(id: string, data: any) {
    var body = this.booktoBody(data);
    this.httpClient.put<any[]>("https://localhost:44342/api/Books/" + id, body)
      .subscribe(
        (response: any) => {
          this.getAuthors();
        },
        (error: any) => {
          console.log('Erreur put books ! : ');
          console.log(error);
        }
      );
  }

  createBook(data: any) {
    var body = this.booktoBody(data);
    this.httpClient.post<any[]>("https://localhost:44342/api/Books/", body)
      .subscribe(
        (response: any) => {
          this.getAuthors();
          this.getBooks();
        },
        (error: any) => {
          console.log('Erreur post authors ! : ');
          console.log(error);
        }
      );
  }

  private authorToBody(author: any)
  {
    var body: any = {};

    body.firstName = author.firstName;
    body.lastName = author.lastName;

    return body;
  }

  private booktoBody(book: any)
  {
    var body: any = {};

    body.name = book.name;
    body.isbn = book.isbn;
    body.authorId = book.authorId;

    return body
  }
}