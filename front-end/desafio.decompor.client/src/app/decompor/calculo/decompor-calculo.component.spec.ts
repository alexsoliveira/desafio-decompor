import { ComponentFixture, TestBed, TestComponentRenderer } from '@angular/core/testing';

import { DecomporCalculoComponent } from './decompor-calculo.component';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DecomporRoutingModule } from '../decompor.route';
import { DecomporService } from '../services/decompor.service';
import { HttpClientModule } from '@angular/common/http';

describe('Teste funcionalidade do componente DecomporCalculoComponent', async () => {
  let component: DecomporCalculoComponent;
  let fixture: ComponentFixture<DecomporCalculoComponent>;  

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DecomporCalculoComponent ],
      imports: [
        CommonModule,        
        DecomporRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule 
      ],
      providers: [
        DecomporService
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DecomporCalculoComponent);
    component = fixture.componentInstance;
        
    fixture.detectChanges();
  });

  it('Teste deve criar component DecomporCalculoComponent', () => {
    expect(component).toBeTruthy();
  });

  it('Teste deve desabilitar botão Decompor, quando o campo é inválido', async () => { 
    component.decomporForm = new FormGroup({      
      entrada: new FormControl(0, Validators.required),   
    });
    
    fixture.detectChanges();

    const button = fixture.nativeElement.querySelector('button');
    expect(button.disabled).toBe(true);
  });

  it('Teste deve habilitar botão Decompor, quando o campo é válido', async () => {        
    component.decomporForm = new FormGroup({
      entrada: new FormControl(45, Validators.required),         
    });
    
    fixture.detectChanges();

    const button = fixture.nativeElement.querySelector('button');
    expect(button.disabled).toBe(false);
  });

  it('Teste deve decompor o número de entrada e exibir resultado da decomposição', async () => {
    component.decomporForm = new FormGroup({
      entrada: new FormControl(45, Validators.required),      
    });
    
    fixture.detectChanges();
  
    const button = fixture.nativeElement.querySelector('button');
    button.click();
    await fixture.whenStable();
    fixture.detectChanges();

    let resultado = component.decomporResultado;
    
    expect(resultado).not.toBeNull();
  });
});
