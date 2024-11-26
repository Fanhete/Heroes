import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Heroi } from 'src/app/models/Heroi';
import { HeroiService } from 'src/app/services/heroi-service.service';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesComponent implements OnInit{

   heroi?: Heroi;
   id!:number;

  constructor(private heroiService: HeroiService, private route: ActivatedRoute, private router : Router) {

  }

  ngOnInit(): void {

      this.id =  Number(this.route.snapshot.paramMap.get("id"));

      this.heroiService.GetHeroi( this.id).subscribe((data) => {
         const dados = data.dados;
         this.heroi = dados;
      });
  }


  InativaHeroi(){

      this.heroiService.InativaHeroi(this.id).subscribe((data) => {
        this.router.navigate(['']);
        }
      );

  }
}
