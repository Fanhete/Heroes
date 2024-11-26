import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Heroi } from 'src/app/models/Heroi';
import { HeroiService } from 'src/app/services/heroi-service.service';


@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent implements OnInit {

  btnAcao = "Cadastrar!";
  btnTitulo = "Cadastrar Heroi!";

  constructor(private heroiService : HeroiService, private router: Router) {
  }

  ngOnInit(): void {
  }

  createHeroi(heroi: Heroi){

       this.heroiService.CreateHeroi(heroi).subscribe((data) => {
          this.router.navigate(['/']);
       })
  }



}
