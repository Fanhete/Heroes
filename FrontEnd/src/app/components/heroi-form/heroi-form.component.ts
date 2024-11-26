import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Heroi } from 'src/app/models/Heroi';
import { HeroiService } from 'src/app/services/heroi-service.service';


@Component({
  selector: 'app-heroi-form',
  templateUrl: './heroi-form.component.html',
  styleUrls: ['./heroi-form.component.css']
})
export class HeroiFormComponent implements OnInit{
  @Output() onSubmit = new EventEmitter<Heroi>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input()  dadosHeroi: Heroi | null = null;

  heroiForm!: FormGroup;
  ativo:number = 1;


  constructor(private heroiService : HeroiService, private router: Router) {
  }


  ngOnInit(): void {

    this.heroiForm = new FormGroup ({
      id: new FormControl(this.dadosHeroi ? this.dadosHeroi.id : 0),
      nome: new FormControl(this.dadosHeroi ? this.dadosHeroi.nome : '', [Validators.required]),
      nomeHeroi: new FormControl(this.dadosHeroi ? this.dadosHeroi.nomeHeroi : '',[Validators.required]),
      dataNascimento: new FormControl(this.dadosHeroi ? this.dadosHeroi.dataNascimento : '',[Validators.required]),
      altura: new FormControl(this.dadosHeroi ? this.dadosHeroi.altura : '',[Validators.required]),
      peso: new FormControl(this.dadosHeroi ? this.dadosHeroi.peso : '',[Validators.required]),
    });
  }


  get nome(){
    return this.heroiForm.get('nome')!;
  }

  submit(){

      console.log(this.heroiForm.value)

      this.onSubmit.emit(this.heroiForm.value);
  }

}
