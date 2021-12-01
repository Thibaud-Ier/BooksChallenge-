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

  updateAuthor(event: any)
  {
    this.service.updateAuthor(event.key, event.data);
  //     component: inheritor {callBase: undefined, _customClass: undefined, _$element: initRender(1), NAME: 'dxDataGrid', _eventsStrategy: NgEventsStrategy, …}
// data: {id: '3f9a0026-e78e-4307-a4df-c28470b7867d', firstName: 'Jack', lastName: 'Londonsssss', books: Array(0)}
// element: dx-data-grid.dx-widget.dx-visibility-change-handler
// key: "3f9a0026-e78e-4307-a4df-c28470b7867d"
  }
}
