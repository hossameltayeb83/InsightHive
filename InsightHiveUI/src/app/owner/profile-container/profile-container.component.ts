import { Component } from '@angular/core';
import { ProfileViewComponent } from '../profile-view/profile-view.component';
import { UpdateProfileComponent } from '../update-profile/update-profile.component';
import {CommonModule  } from "@angular/common";
@Component({
  selector: 'app-profile-container',
  standalone: true,
  imports: [CommonModule,ProfileViewComponent, UpdateProfileComponent],
  templateUrl: './profile-container.component.html',
  styleUrl: './profile-container.component.css',
})
export class ProfileContainerComponent {
  isEditMode = false;

  toggleEditMode(): void {
    this.isEditMode = !this.isEditMode;
  }
}
