import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Course } from '../interfaces/course';
import { selectionsObject } from '../interfaces/selections-object';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  obj = {} as selectionsObject;
  coursesData= [] as Course[];
  showValidation=false;

  form = this._formBuilder.group({
    name: this._formBuilder.array([]),
    courseId: this._formBuilder.array([]),
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null)
  });
  totalDuration: number = 0;
  Calculation: any;
  constructor(private apiService: ApiService, private _formBuilder: FormBuilder) { }
  ngOnInit() {
    // get courses list
    this.apiService.get("/courses").subscribe((data: any)=>{
			this.coursesData = data.courses;
		})
  }
  onChangeEventFunc(courseid: number, isChecked: any) {
    const courses = (this.form.controls.courseId as FormArray);
    const selectedCourse = this.coursesData.find(x => x.id === courseid);

    if (isChecked.checked) {
      //add checked item to the courses list
      courses.push(new FormControl(courseid));
      //calculate total courses durations
      this.totalDuration = this.totalDuration + (selectedCourse?.duration || 0)
    } else {
      //remove unchecked item from the courses list
      const index = courses.controls.findIndex(x => x.value === courseid);
      courses.removeAt(index);
      //calculate total courses durations
      this.totalDuration = this.totalDuration - (selectedCourse?.duration || 0)
    }
  }
  submit() {
    if(this.form.value.courseId && this.form.value.start && this.form.value.end)
    {
      this.showValidation = false;
      console.log(this.form.value.courseId);
    console.log(this.form.value.start?.toDateString());
    //contructing submit object
    this.obj.StartDate = this.form.value.start || undefined;
    this.obj.StartDate?.setDate(this.obj.StartDate.getDate() + 1 );

    this.obj.EndDate = this.form.value.end || undefined;
    this.obj.EndDate?.setDate(this.obj.EndDate.getDate() + 1 );

    this.obj.CoursesIdsList = this.form.value.courseId as Array<number>;
    this.obj.TotalCoursesDuration = this.totalDuration;
    console.log(this.obj)

    //post data to server
    this.apiService.post("/calculation",this.obj).subscribe((data: any)=>{
			this.Calculation = data;
		});
  }
  else
  this.showValidation = true;
}
}
