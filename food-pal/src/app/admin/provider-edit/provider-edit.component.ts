import { ChangeDetectorRef, Component, NgZone, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Provider } from '../models/provider';
import { ItemStatus } from '../models/provider-catalogue';
import { ProvidersService } from '../services/providers.service';

@Component({
  selector: 'app-provider-edit',
  templateUrl: './provider-edit.component.html',
  styleUrls: ['./provider-edit.component.scss'],
})
export class ProviderEditComponent implements OnInit {
  data$: Observable<Provider>;

  formGroup: FormGroup;
  nameFormControl: FormControl;

  catalogItems: FormArray;

  get nameErrors() {
    return !!this.nameFormControl.errors
      ? Object.keys(this.nameFormControl.errors)
      : [];
  }

  constructor(
    private providerSvc: ProvidersService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
  ) {}

  ngOnInit(): void {

    this.initForm();
    const providerId = +this.route.snapshot.paramMap.get('providerId');
    this.data$ = this.providerSvc.getProvider(providerId).pipe(
      tap((data) => {
        this.fillForm(data);
      })
    );
  }

  initForm() {
    this.nameFormControl = new FormControl(
      {
        value: '',
        updateOn: 'blur',
      },
      [Validators.required, Validators.minLength(5), Validators.maxLength(150)]
    );

    this.catalogItems = new FormArray([]);

    this.formGroup = this.formBuilder.group({
      id: new FormControl(),
      name: this.nameFormControl,
      description: new FormControl(),
      location: new FormControl(),
      providerCatalogue: new FormGroup({
        id: new FormControl(),
        description: new FormControl(),
        items: this.catalogItems,
      }),
    });
  }

  fillForm(data: Provider) {
    this.formGroup.get('id').setValue(data.id);
    this.formGroup.get('name').setValue(data.name);
    this.formGroup.get('description').setValue(data.description);
    this.formGroup.get('location').setValue(data.location);
    this.formGroup
      .get('providerCatalogue.description')
      .setValue(data.catalogue.description);
    this.formGroup.get('providerCatalogue.id').setValue(data.catalogue.id);
    data.catalogue?.items?.forEach((item) => {
      (this.formGroup.get('providerCatalogue.items') as FormArray).push(
        new FormGroup({
          id: new FormControl(item.id),
          name: new FormControl(item.name),
          price: new FormControl(item.price),
          status: new FormControl(item.status),
        })
      );
    });
  }

  save() {
    if (this.formGroup.valid) {
      const form = this.formGroup.value;
      console.log(this.catalogItems);
    } else {
      this.getFormValidationErrors();
    }
  }

  addCatalogueItem(){
    this.catalogItems.push(this.formBuilder.group({
      name: new FormControl(),
      price: new FormControl(),
      status: new FormControl(ItemStatus.Added)
    }));
  }

  getFormValidationErrors() {
    Object.keys(this.formGroup.controls).forEach((key) => {
      const controlErrors: ValidationErrors = this.formGroup.get(key).errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach((keyError) => {
          console.log(
            'Key control: ' + key + ', keyError: ' + keyError + ', err value: ',
            controlErrors[keyError]
          );
        });
      }
    });
  }

  deleteCatalogItem(control : AbstractControl) {

    var newValue = control.value;
    if(newValue.status !== ItemStatus.Deleted)
    {
        newValue.status = ItemStatus.Deleted;
        control.setValue(newValue);
    }  
  }

  checkDeleted(control : AbstractControl): boolean {
    if (control.value.status === ItemStatus.Deleted)
      return false;
    else 
      return true;
  }
}