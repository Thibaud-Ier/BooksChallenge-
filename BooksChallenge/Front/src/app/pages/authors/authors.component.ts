import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/api-service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.scss']
})
export class AuthorsComponent implements OnInit {
  authors: any[] = [];
  authorSubscription: Subscription;

  constructor(private service: ApiService) {
    this.authorSubscription = this.service.authorsSubject.subscribe(
      (authors: any[]) => {
        this.authors = authors;
      }
    );
    this.service.emitAppareilSubject();
   }

  ngOnInit(): void {
  }

}
