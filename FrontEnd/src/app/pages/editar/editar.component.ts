import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Heroi } from 'src/app/models/Heroi';
import { HeroiService } from 'src/app/services/heroi-service.service';


@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit{

  btnAcao = "Editar";
  btnTitulo = "Editar Heroi!";
  heroi!: Heroi;

  constructor(private heroiService : HeroiService, private router :Router,  private route : ActivatedRoute) {


  }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.heroiService.GetHeroi(id).subscribe((data) => {
        this.heroi = data.dados;

    });
  }

  async editHeroi(heroi : Heroi){

      this.heroiService.EditHeroi(heroi).subscribe(data => {
        this.router.navigate(['/']);
      });

  }

}
