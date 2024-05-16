import { Component,OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { Observable } from 'rxjs';
import { ProfileService } from '../../services/profile.service';
import {CommonModule} from '@angular/common';
import { UpdateProfileComponent } from '../update-profile/update-profile.component';

@Component({
  selector: 'app-profile-view',
  standalone: true,
  imports: [CommonModule, UpdateProfileComponent],
  templateUrl: './profile-view.component.html',
  styleUrl: './profile-view.component.css',
})
export class ProfileViewComponent implements OnInit {
  profileData: Observable<any> = new Observable<any>();
  reviews$: Observable<any[]>=new Observable<any[]>();
  isEditMode = false;
  constructor(private profileService: ProfileService,public router:Router) {}

  ngOnInit(): void {
    this.profileData = this.profileService.getProfileData();
  }
  toggleEditMode() {
    
    this.isEditMode = !this.isEditMode;
    if (this.isEditMode) {this.router.navigateByUrl('/Profile/updateProfile');}
  }
}
  


  

