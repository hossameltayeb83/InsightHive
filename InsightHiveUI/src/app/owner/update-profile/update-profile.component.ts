import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms'; // Import ReactiveFormsModule
import { ProfileService } from '../../services/profile.service';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-update-profile',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './update-profile.component.html',
  styleUrl: './update-profile.component.css',
})
export class UpdateProfileComponent implements OnInit {
  profileForm!: FormGroup;
  imageUrl: string=''; // Store selected image URL

  constructor(
    private fb: FormBuilder,
    private profileService: ProfileService
  ) {}

  ngOnInit(): void {
    this.profileService.getProfileData().subscribe((profileData) => {
      this.profileForm = this.fb.group({
        profileImage: [''], // Initialize without a value
        name: [profileData.name, Validators.required],
        email: [profileData.email, [Validators.required, Validators.email]],
        password: [profileData.password, Validators.minLength(6)],
      });
      this.imageUrl = profileData.profileImage; // Set initial image URL
    });
  }

  onSubmit(): void {
    if (this.profileForm.valid) {
      const updatedProfileData = {
        ...this.profileForm.value,
        profileImage: this.imageUrl, // Use the selected image URL
      };
      this.profileService.updateProfile(updatedProfileData);
    }
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      // Read selected file as URL
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.imageUrl = e.target.result; // Set the image URL for preview
      };
      reader.readAsDataURL(file);
    }
  }
}
