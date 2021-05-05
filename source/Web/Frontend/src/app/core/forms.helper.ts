import { FormGroup } from "@angular/forms";

export class FormsHelper {
    public validateControl = (form: FormGroup, controlName: string) => {
        return form.controls[controlName].invalid && form.controls[controlName].touched
    }
    
    public hasError = (form: FormGroup, controlName: string, errorName: string) => {
        return form.controls[controlName].hasError(errorName)
    }
}