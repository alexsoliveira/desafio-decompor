import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { catchError, map, Observable } from 'rxjs';
import { BaseService } from 'src/app/services/base.service';

import { Decompor } from './../models/decompor.model';
import { DecomporResultado } from '../models/decompor.resultado.model';

@Injectable()
export class DecomporService extends BaseService {
  
  constructor(private http: HttpClient) { super(); }
  
  fazerDecomposicao(decompor: Decompor) : Observable<DecomporResultado> {
    let response = this.http
          .post(this.UrlServiceV1 + 'decompor', decompor, this.ObterHeaderJson())
          .pipe(
              map(this.extractData),
              catchError(this.serviceError));

      return response;
  }  
}
