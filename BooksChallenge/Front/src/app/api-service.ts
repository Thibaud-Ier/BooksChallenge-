import { Subject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  authorsSubject = new Subject<any[]>();
  authors: any[] = [];

  constructor(private httpClient: HttpClient) {
    this.getAuthors();
  }

  emitAppareilSubject() {
    this.authorsSubject.next(this.authors.slice());
  }

  getAuthors() {
    this.httpClient.get<any[]>('https://localhost:44342/api/Authors')
      .subscribe(
        (response: any) => {
          this.authors = response;
          this.emitAppareilSubject();
        },
        (error: any) => {
          console.log('Erreur get authors ! : ');
          console.log(error);
        }
      );
  }

  updateAuthor(id: string, data: any) {
    var body: any = {};

    body.firstName = data.firstName;
    body.lastName = data.lastName;
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
    var body: any = {};

    body.firstName = data.firstName;
    body.lastName = data.lastName;
    this.httpClient.post<any[]>("https://localhost:44342/api/Authors/", body)
      .subscribe(
        (response: any) => {
        },
        (error: any) => {
          console.log('Erreur post authors ! : ');
          console.log(error);
        }
      );
  }
}