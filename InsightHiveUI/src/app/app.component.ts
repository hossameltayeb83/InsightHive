import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {HeaderComponent} from './core/header/header.component';
import { CommonModule } from '@angular/common';
import {FooterComponent} from './core/footer/footer.component';
import { ReactiveFormsModule,FormGroup } from '@angular/forms'; // Import ReactiveFormsModule
import { ProfileViewComponent } from './owner/profile-view/profile-view.component';
import { UpdateProfileComponent } from './owner/update-profile/update-profile.component';
import { ProfileContainerComponent } from './owner/profile-container/profile-container.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterOutlet,
    HeaderComponent,
    FooterComponent,
    ProfileViewComponent,
    UpdateProfileComponent,
    ProfileContainerComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'InsightHiveUI';
  
}
