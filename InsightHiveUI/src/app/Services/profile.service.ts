import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root',
})
export class ProfileService {
  private profileData: BehaviorSubject<any> = new BehaviorSubject<any>({
    profileImage: '../../../assets/avatar-1.png',
    name: 'John Doe',
    email: 'johndoe@example.com',
    password: 'password123',
  });
  private reviewsUrl =
    'ttps://developer.revihews.io/reference/product-review-invitations';
  constructor(private http: HttpClient) {}

  getProfileData(): Observable<any> {
    return this.profileData.asObservable();
  }

  updateProfile(newProfileData: any): void {
    this.profileData.next(newProfileData);
  }
  getReviews(): Observable<any[]> {
    // Fetch reviews from your API
    return this.http.get<any[]>(this.reviewsUrl);
  }
}
