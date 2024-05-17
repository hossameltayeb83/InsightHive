import { Component ,OnInit} from '@angular/core';
import { Business } from '../../_modules/business';
import { ActivatedRoute } from '@angular/router';
import {CommonModule} from "@angular/common";
import { BusinessService } from "../../services/business.service";
@Component({
  selector: 'app-business-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './business-profile.component.html',
  styleUrl: './business-profile.component.css',
})
export class BusinessProfileComponent implements OnInit {
  business: Business | undefined;
  // businessId: number | undefined;
  imageUrl: string | undefined;

  constructor(
    public route: ActivatedRoute,
    private businessService: BusinessService
  ) {}

  // ngOnInit(): void {
  //   this.route.paramMap.subscribe((params) => {
  //     const businessId = params.get('id');
  //     if (businessId) {
  //       // Fetch business details by ID
  //       this.businessService
  //         .getBusinessById(parseInt(businessId, 10))
  //         .subscribe(
  //           (business: Business | undefined) => {
  //             if (business) {
  //               this.business = business;
  //             } else {
  //               console.error('Business not found');
  //             }
  //           },
  //           (error) => {
  //             console.error('Error fetching business:', error);
  //           }
  //         );
  //     }
  //   });
  // }
  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const businessId = Number(params.get('id'));
      if (businessId) {
        this.businessService.getBusinessById(businessId).subscribe(
          (business: Business | undefined) => {
            if (business) {
              this.business = business;
              this.imageUrl = `assets/images/${business.logo}`; // Assign the retrieved business to the component property
            } else {
              console.error('Business not found');
            }
          },
          (error) => {
            console.error('Error fetching business:', error);
          }
        );
      }
    });
  }
}

