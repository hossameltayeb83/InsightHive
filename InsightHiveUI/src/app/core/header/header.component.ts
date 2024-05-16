import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import {CommonModule} from '@angular/common'
import { RouterLink,RouterLinkActive } from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  isSearchVisible = false;
  isMenuOpen = false;
 

  toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
