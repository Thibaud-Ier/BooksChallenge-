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

    getAuthors()
    {
        this.httpClient.get<any[]>('https://localhost:44342/api/Authors')
        .subscribe(
          (response: any) => {
            console.log(response);
            this.authors = response;
            this.emitAppareilSubject();
          },
          (error: any) => {
            console.log('Erreur ! : ' + error);
            console.log(error);
          }
        );
    }
}