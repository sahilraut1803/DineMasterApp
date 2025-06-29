import { Routes } from '@angular/router';
import { Table } from './table/table';
import { Home } from './home/home';

export const routes: Routes = [
    {path:'',redirectTo:'/home',pathMatch:'full'},
    {path:'table',component:Table},
    {path:'**',component:Home},    
];
