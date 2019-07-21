import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Author } from './Author';
import { AuthorService } from '../_services/author-service.service';


@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  host = "http://localhost:5000/api/authors"

  info: any = {}
  authorName: any

  constructor(private client: HttpClient, private service: AuthorService) { }

  ngOnInit() {
  }

  formatNameInAbnt() {
    let data = new Author()
    data.nameString = this.info.nameString

    this.client.post<Author>(this.host , data).subscribe((res) => {
      this.authorName = res.authorName
      this.service.getAuthors()
    });    
  }  
}
