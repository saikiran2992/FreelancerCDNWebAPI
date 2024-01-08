import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Skill } from '../Model/Skill';

@Injectable({
  providedIn: 'root'
})
export class SkillServiceService {

  public Skill: Skill = new Skill();
  public allSkill: Skill[] = [];
  private baseUrl:string='http://localhost:5003/api/Skill';

  constructor(private http:HttpClient) { }

  get(){
    return this.http.get(this.baseUrl).toPromise().then(res=>this.allSkill=res as Skill[]);
  }
}
