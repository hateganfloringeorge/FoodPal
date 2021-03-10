import { ChangeDetectorRef, Component, NgZone, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Provider } from '../models/provider';
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
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initForm();
    this.data$ = this.providerSvc.getProvider(2).pipe(
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
        })
      );
    });
  }

  save() {
    if (this.formGroup.valid) {
      const form = this.formGroup.value;
      console.log('new name: ', form);
    } else {
      this.getFormValidationErrors();
    }
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
}