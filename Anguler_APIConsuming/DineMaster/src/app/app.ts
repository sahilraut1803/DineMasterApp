import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { RouterLink, RouterOutlet } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'DineMaster';
}
