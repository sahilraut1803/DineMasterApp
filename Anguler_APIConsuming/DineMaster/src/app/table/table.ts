import { Component, OnInit } from '@angular/core';
import { TableService } from '../table-service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
declare var $:any;
@Component({
  selector: 'app-table',
  imports: [CommonModule,ReactiveFormsModule],
  templateUrl: './table.html',
  styleUrl: './table.scss'
})
export class Table implements OnInit{
  constructor(private ts:TableService){
    this.getTableDetails();
  }

  details=new FormGroup({
    name:new FormControl(''),
    capacity:new FormControl(''),
    status:new FormControl(''),
    createdBy:new FormControl('')
  });
  tabledata:any;
  
  ngOnInit() {
    this.getTableDetails();
  }

  getTableDetails()
  {
    this.ts.fetchTable().subscribe({
      next:(res)=>{
        console.log(res);
        this.tabledata=res;
      },

      error:(err)=>{
        console.log(err.message);
      },
    });
  }

  SaveTable(data:any){
    this.ts.addTable(data).subscribe({
      next:res=>{
        alert('Emp Added!!!');
        this.getTableDetails();
        $('#exampleModal').modal('hide');
      },
      error:err=>{
        console.log(err.message);
      },
    });
  }

  DelTable(id:any){
    this.ts.deleteTable(id).subscribe({
      next:res=>{
        alert('Emp Deleted!!!');
        this.getTableDetails();
      },
      error:err=>{
        console.log(err.message);
      },
    });
  }
}
