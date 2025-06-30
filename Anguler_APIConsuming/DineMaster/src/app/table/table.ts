import { ChangeDetectorRef,Component, OnInit } from '@angular/core';
import { TableService } from '../table-service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MasterTable } from '../master-table';
import { response } from 'express';
declare var $:any;
@Component({
  selector: 'app-table',
  imports: [CommonModule,ReactiveFormsModule,FormsModule],
  templateUrl: './table.html',
  styleUrl: './table.scss'
})
export class Table implements OnInit{
  constructor(private ts:TableService, private cd: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.getTableDetails();
  }
  isEditMode = false;

  details=new FormGroup({
    tableId: new FormControl(''),
    name:new FormControl('',[Validators.required,Validators.maxLength(10)]),
    capacity:new FormControl('',[Validators.required, Validators.min(2), Validators.max(10)]),
    status:new FormControl('',[Validators.required]),
    createdBy:new FormControl('Admin'),
    modifiedBy:new FormControl('Admin')
  });
  tabledata:any;
  // tabledata:any[]=[];

  getTableDetails(){
    this.ts.fetchTable().subscribe({
      next:(res) => {
        console.log('Fetched Table Data:', res);
        this.tabledata = res;
        this.cd.detectChanges();
      },
      error:(err) => {
        console.log('Error fetching table data:', err.message);
      }
    });
  }
  // getTableDetails() {
  //   this.ts.fetchTable().subscribe({
  //     next: (res) => {
  //       this.tabledata = res;
  //       this.cd.detectChanges(); 
  //       console.log('Fetched Table Data:', res);
  //     },
  //     error: (err) => {
  //       console.error('Error fetching table data:', err.message);
  //     }
  //   });
  // }

  openAddModal() {
    this.isEditMode = false;
    $('#modalH').text('Add New Table');
    this.details.reset({ createdBy: 'Admin'});
    $('#exampleModal').modal('show');
  }

  SaveOrUpdateTable(data: any) {
    if (this.isEditMode) {
      this.ts.updateTable(data).subscribe({
        next: (res) => {
          alert('✅ Table Updated Successfully!');
          $('#exampleModal').modal('hide');
          this.getTableDetails();
        },
        error: (err) => {
          console.log('Error updating table:', err.message);
        }
      });
    } 
    else {
      this.ts.addTable(data).subscribe({
        next: (res) => {
          alert('✅ Table Added Successfully!');
          $('#exampleModal').modal('hide');
          this.getTableDetails();
        },
        error: (err) => {
          console.log('Error adding table:', err.message);
        }
      });
    }
  }

  EditTable(data : any) {
    this.isEditMode = true;
    this.details.reset();
    $('#modalH').text('Edit Table');
    this.details.reset({ modifiedBy: 'Admin'});
    this.details.controls.tableId.setValue(data.tableId);
    this.details.controls.name.setValue(data.name);
    this.details.controls.capacity.setValue(data.capacity);
    this.details.controls.status.setValue(data.status);
    $('#exampleModal').modal('show');           
  }

  // EditTable(id: any) {
  //   this.ts.getTable(id).subscribe({
  //     next: (res) => {
  //       this.isEditMode = true;
  //       $('#modalH').text('Edit Table');
  //       this.details.patchValue({ ...res, modifiedBy: 'Admin' }); // autofill form
  //       $('#exampleModal').modal('show');
  //     },
  //     error: (err) => {
  //       console.error('Error fetching table by id:', err.message);
  //     }
  //   });
  // }

  DelTable(id: any) {
    if (confirm('Are you sure you want to delete this table?')) {
      this.ts.deleteTable(id).subscribe({
        next: (res) => {
          alert('🗑️ Table Deleted Successfully!');
          this.getTableDetails();
        },
        error: (err) => {
          if (err.error?.message === 'Cannot delete this record') {
          alert('⚠️ This table is associated with a reservation and cannot be deleted.');
          } else {
            console.error('Error deleting table:', err.message);
          }
        }
      });
    }
  }

  get name() {
    return this.details.controls.name;
  }

  get capacity() {
    return this.details.controls.capacity;
  }

  get status() {
    return this.details.controls.status;
  }

}
