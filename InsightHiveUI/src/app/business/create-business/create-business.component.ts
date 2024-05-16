import { Component , OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators,ReactiveFormsModule } from '@angular/forms';
import {CommonModule} from '@angular/common';
import {Business} from '../../_modules/business';
import {BusinessService} from '../../services/business.service';
import { Filters } from '../../_modules/filters'; 
import {Category} from '../../_modules/category';
@Component({
  selector: 'app-create-business',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './create-business.component.html',
  styleUrl: './create-business.component.css',
})
export class CreateBusinessComponent implements OnInit {
  businessForm!: FormGroup;
  logoFile: File | null = null;
  categories: Category[] = [
    {
      id: 1,
      name: 'Category A',
      filters: [
        { id: 1, name: 'Filter 1' },
        { id: 2, name: 'Filter 2' },
      ],
    },
    {
      id: 2,
      name: 'Category B',
      filters: [
        { id: 3, name: 'Filter 3' },
        { id: 4, name: 'Filter 4' },
      ],
    },
  ];
  
  selectedCategory!: Category;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private businessService: BusinessService
  ) {}

  ngOnInit(): void {
    this.businessForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      logo: ['', Validators.required],
      categoryId: ['', Validators.required],
      filterId: ['', Validators.required],
      subCategoryId: ['', Validators.required],
      subCategoryName: ['', Validators.required],
      ownerId: ['', Validators.required],
    });
  }

  onCategoryChange(): void {
    const categoryId = this.businessForm.get('categoryId')?.value;
    this.selectedCategory = this.categories.find(
      (category) => category.id === categoryId
    )!;
    this.businessForm.get('filterId')?.setValue(null);
  }

  onSubmit(): void {
    if (this.businessForm.valid && this.logoFile) {
      const newBusiness: Business = this.businessForm.value;
      newBusiness.logo = this.logoFile.name;

      this.businessService.createBusiness(newBusiness).subscribe(
        (createdBusinessId: number) => {
          this.router.navigate(['/business-profile', createdBusinessId]);
        },
        (error) => {
          console.error('Error creating business:', error);
        }
      );
    } else {
      this.businessForm.markAllAsTouched();
    }
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    this.logoFile = file;
  }
}
