import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { throwError } from "rxjs";

export abstract class BaseService {

  protected UrlServiceV1: string = environment.apiUrlv1;

  protected ObterHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }    

  protected extractData(response: any) {
    return response;
  }

  protected serviceError(response: Response | any) {
    let customError: string[] = [];
    
    if (response instanceof HttpErrorResponse) {

      if (response.statusText === "Unknown Error") {
        customError.push("Ocorreu um erro desconhecido");
        response.error.errors = customError;
      }
    }    

    console.error(response);
    return throwError(() => response);
  }
}