import { Component, OnInit,  } from '@angular/core';

import { Author } from '../author/Author';
import { AuthorService } from '../_services/author-service.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-authors-list',
  templateUrl: './authors-list.component.html',
  styleUrls: ['./authors-list.component.css']
})
export class AuthorsListComponent implements OnInit {

  authors: Author[]

  constructor(private svc: AuthorService) { }

  ngOnInit() { 
    this.getAuthors()   
  }

  getAuthors() {
    this.svc.getAuthors().subscribe((res) => {
      this.authors = res
    },
    error => {
      console.log(error)
    },
    () => {
      window.setTimeout(() => { this.getAuthors()}, 1000);      
    })
  }

  removeAuthorFromHistory(id: number)
  {
    this.svc.removeAuthorFromHistory(id).subscribe(((res) => {
      console.log(res)
      this.svc.getAuthors()
    }))
  }
}
