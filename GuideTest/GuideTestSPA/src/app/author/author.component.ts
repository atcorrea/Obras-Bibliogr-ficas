import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NameInfo } from './NameInfo';
import { Author } from './Author';


@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  info: any = {}
  authorName: any
  host = "http://localhost:5000/api"

  constructor(private client: HttpClient) { }

  ngOnInit() {
  }

  formatNameInAbnt() {
    let data = new NameInfo()
    data.nameString = this.info.nameString
    data.nameCount = 0

    this.client.post<Author>(this.host + '/author' + '/formatAuthor', data).subscribe((res) => {
      this.authorName = res.name
    });
    
  }
}
