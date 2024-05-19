import { Routes } from '@angular/router';
import {ProfileViewComponent} from './owner/profile-view/profile-view.component';
import { UpdateProfileComponent } from './owner/update-profile/update-profile.component';
import { HomeComponent } from './feature/home/home.component';
import { CreateBusinessComponent } from './business/create-business/create-business.component';
import { BusinessProfileComponent } from './business/business-profile/business-profile.component';
import { ReviewerProfileComponent } from './reviewer/reviewer.profile/reviewer.profile.component';
export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {
    path: 'Profile',
    component: ProfileViewComponent,
    children: [{ path: 'updateProfile', component: UpdateProfileComponent }],
  },
  {path:'reviewer', component: ReviewerProfileComponent },
  { path: 'AddBusiness', component: CreateBusinessComponent },
  { path: 'business-profile/:id', component: BusinessProfileComponent }, // Add route for business profile
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Redirect to home by default
  { path: '**', redirectTo: '/home' },
];
