import { TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { Observable, Observer } from 'rxjs';

import { Decompor } from '../models/decompor.model';
import { DecomporResultado } from '../models/decompor.resultado.model';
import { DecomporService } from './decompor.service';

const decomporFake: Decompor = {
  entrada: 45
}

const decomporResultadoFake: DecomporResultado = {
  numerosDivisores: [1,3,5,9,15,45],
  divisoresPrimos: [1,3,5]
}

function createResponse(body: any){
  return Observable.create((observer: Observer<any>) => {
    observer.next(body);
  });
}

describe(' Teste funcionalidade do servico DecomporService', async () => {
  let service: DecomporService;
  let decompor: Decompor;

  beforeEach(() => {
    const bed = TestBed.configureTestingModule({      
      imports: [       
        HttpClientModule  
      ],
      providers: [
        DecomporService
      ]
    });
    service = bed.inject(DecomporService);
  });

  it('Teste deve criar service DecomporService', () => {
    expect(service).toBeTruthy();
  });

  it('Teste deve executar o metodo fazerDecomposicao', async () => {
    let observerResultadoFake = createResponse(decomporResultadoFake);

    spyOn(service, 'fazerDecomposicao').and.returnValue(observerResultadoFake);

    let result = service.fazerDecomposicao(decomporFake);

    expect(result).toEqual(observerResultadoFake);
  });
});

