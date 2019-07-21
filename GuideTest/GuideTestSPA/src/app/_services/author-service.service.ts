import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Author } from '../author/Author';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {

  host = "http://localhost:5000/api/authors"

  constructor(private client: HttpClient) { }
  
  getAuthors() : Observable<Author[]>{
    return this.client.get<Author[]>(this.host);
  }

  removeAuthorFromHistory(id: number) : Observable<Author>{
    return this.client.delete<Author>(this.host + "/" + id)
  }
}
