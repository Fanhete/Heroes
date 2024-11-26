import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Heroi } from 'src/app/models/Heroi';
import { HeroiService } from 'src/app/services/heroi-service.service';


@Component({
  selector: 'app-excluir',
  templateUrl: './excluir.component.html',
  styleUrls: ['./excluir.component.css']
})
export class ExcluirComponent implements OnInit{

  inputdata:any
  heroi!: Heroi;

  constructor(@Inject(MAT_DIALOG_DATA) public data:any, private heroiService: HeroiService, private router: Router, private ref:MatDialogRef<ExcluirComponent>){}

  ngOnInit(): void {
      this.inputdata = this.data;

      this.heroiService.GetHeroi(this.inputdata.id).subscribe(data => {
          this.heroi = data.dados;
      });
  }

  excluir(){
    this.heroiService.ExcluirHeroi(this.inputdata.id).subscribe(data => {
       this.ref.close();
       window.location.reload();
    });
  }

}
