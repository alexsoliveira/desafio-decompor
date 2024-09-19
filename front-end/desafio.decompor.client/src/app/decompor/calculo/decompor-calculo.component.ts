import { DecomporResultado } from './../models/decompor.resultado.model';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';

import { Decompor } from '../models/decompor.model';
import { FormBaseComponent } from 'src/app/base-components/form-base.component';
import { DecomporService } from '../services/decompor.service';

@Component({
  selector: 'app-decompor-calculo',
  templateUrl: './decompor-calculo.component.html'
})
export class DecomporCalculoComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[] | any;
  
  errors: any[] = [];
  decomporForm: FormGroup | any;
  decompor: Decompor | any;
  decomporResultado: DecomporResultado | any; 

  entrada: number | undefined;  

  constructor(private fb: FormBuilder,
    private decomporService: DecomporService,    
  ) { 
    super();

    
    this.validationMessages = {
      entrada: {
        required: 'Informe o número para de decomposição',
        pattern: 'O número de entrada deve estar entre (1 e 100)'
      },      
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {

    let valorEntrada = new FormControl('', [Validators.required, Validators.pattern('')]);
    
    this.decomporForm = this.fb.group({
      entrada: valorEntrada,      
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.decomporForm);
  }

  fazerDecomposicao ()  {
    if (this.decomporForm.dirty && this.decomporForm.valid) {
      this.decompor = Object.assign({}, this.decompor, this.decomporForm.value);

      this.decomporService.fazerDecomposicao(this.decompor)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response : any) {
    this.decomporForm.reset();
    this.errors = [];
    
    this.decomporResultado = Object.assign({}, this.decomporResultado, response);    
    console.log(this.decomporResultado);
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;    
  }

  validarCampoEntrada(valorEntrada: any) {
    return !(valorEntrada == undefined || valorEntrada == null || valorEntrada < 0 || valorEntrada > 100);
  }
}
