import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { User } from '../Model/User';


@Injectable({
  providedIn: 'root'
})
export class PersonServiceService {

  public person: User = new User();
  public allPerson: User[] = [];
  private readonly baseUrl: string = 'http://localhost:5003/api/user'

  constructor(private http: HttpClient) { }

  get() {
    return this.http.get(this.baseUrl)
      .toPromise()
      .then(res => this.allPerson = res as User[]);
  }

  post() {
     return this.http.post(this.baseUrl, this.person).subscribe(res => { this.get() }, err => { console.log(err) });
  }

  put() {
    return this.http.put(`${this.baseUrl}/${this.person.id}`, this.person).subscribe(res => { this.get(); }, err => { console.log(err) });
  }

  delete(personId: number | string) {
    return this.http.delete(`${this.baseUrl}?id=${personId}`).subscribe(res => { this.get() }, err => { console.log(err) });
  }
}
