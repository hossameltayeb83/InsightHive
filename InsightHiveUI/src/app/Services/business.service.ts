import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Business } from '../_modules/business';

@Injectable({
  providedIn: 'root',
})
export class BusinessService {
  private businesses: Business[] = [
    {
      id: 1,
      name: 'Business 1',
      description: 'Description for Business 1',
      logo: '../../assets/img1.jpg',
      subCategoryId: 101, // Include subCategoryId
      subCategoryName: 'Category 1',
      ownerId: 101,
    },
    {
      id: 2,
      name: 'Business 2',
      description: 'Description for Business 2',
      logo: '../../assets/img5.jpeg',
      subCategoryId: 102, // Include subCategoryId
      subCategoryName: 'Category 2',
      ownerId: 102,
    },
    // Add more sample businesses as needed
  ];

  constructor() {}

  getBusinessById(id: number): Observable<Business | undefined> {
    const business = this.businesses.find((b) => b.id === id);
    return of(business);
  }
  createBusiness(newBusiness: Business): Observable<number> {
    // Simulate creation by adding the new business to the list
    const nextId = this.businesses.length + 1;
    const businessWithId = { ...newBusiness, id: nextId };
    this.businesses.push(businessWithId);
    return of(nextId); // Return the ID of the newly created business
  }
}
