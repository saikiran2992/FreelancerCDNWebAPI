import { Component, ElementRef, OnInit } from '@angular/core';
import { User } from '../Model/User';
import { PersonServiceService } from '../Service/person-service.service';
import { SkillServiceService } from '../Service/skill-service.service';

@Component({
  selector: 'app-person-info',
  templateUrl: './person-info.component.html',
  styleUrls: ['./person-info.component.css']
})
export class PersonInfoComponent implements OnInit {

  constructor(public service: PersonServiceService,public SkillService:SkillServiceService) { }

  ngOnInit(): void {
    this.service.get().then(res => console.log(res));
    console.log(this.service.allPerson);
  }

  deletePerson(Id: number | string) {
    if (confirm("Are You Sure"))
      this.service.delete(Id);
  }

  showPerson(person: User) {

    this.service.person = Object.assign({}, person);

    //CHB
    //To Clear All Checkboxes
    this.SkillService.allSkill.forEach(element => {
      const checkbox = document.getElementById(
        'chb'+element.id,
      ) as HTMLInputElement | null;
      
      if (checkbox != null) {
        checkbox.checked = false;
      }
    });
    
    //CHB
    //To Select The Skills Already Assigned To The Person
    // Insert
    this.service.person.skillsIds.forEach(element => {
      const checkbox = document.getElementById(
        'chb'+element,
      ) as HTMLInputElement | null;
      console.log(checkbox);
      if (checkbox != null) {
        checkbox.checked = true;
        //this.service.person.SkillIds.push(element);
      }
    });
  }


}
