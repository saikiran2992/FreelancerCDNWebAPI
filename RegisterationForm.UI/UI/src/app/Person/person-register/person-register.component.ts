import { Component, OnInit } from '@angular/core';
import { PersonServiceService } from '../Service/person-service.service';
import { NgForm } from '@angular/forms';
import { SkillServiceService } from '../Service/skill-service.service';


@Component({
  selector: 'app-person-registor',
  templateUrl: './person-register.component.html',
  styleUrls: ['./person-register.component.css']
})
export class PersonRegistorComponent implements OnInit {
  constructor(public service: PersonServiceService,public SkillSevice:SkillServiceService) {
  }

  ngOnInit(): void {
    this.SkillSevice.get();
  }

  //CHB
  onChange(id: number, isChecked: boolean) {

    if (isChecked) {
      this.service.person.skillsIds.push(id);
    } else {
      const index = this.service.person.skillsIds.indexOf(id, 0);
      console.log(index);
      if (index > -1)
      {
        this.service.person.skillsIds.splice(index, 1);
        console.log(this.service.person.skillsIds);
      }
    }
  }

  submitPerson(form: NgForm) {
    if (this.service.person.id == 0 || this.service.person.id == null)
      this.service.post();
    else
      this.service.put();

    this.resetForm(form);
  }

  resetForm(form: NgForm) {
    form.form.reset();
  }
}
