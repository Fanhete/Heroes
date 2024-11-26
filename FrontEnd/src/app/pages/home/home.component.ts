import { Component, OnInit } from '@angular/core';
import { ExcluirComponent } from '../../components/excluir/excluir.component'
import { MatDialog } from '@angular/material/dialog';
import { Heroi } from 'src/app/models/Heroi';
import { HeroiService } from 'src/app/services/heroi-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  herois: Heroi[] = [];
  heroisGeral: Heroi[] = [];
  columnsToDisplay = ['Id', 'Nome', 'NomeHeroi', 'DataNascimento', 'Altura', 'Peso','Ações', 'Teste'];


  constructor(private heroiService : HeroiService, public matDialog: MatDialog) { }


  ngOnInit(): void {
    this.heroiService.GetHerois().subscribe((data) => {
      const dados = data.dados;
       dados.map((item) => {
        //  item.dataDeCriacao = new Date(item.dataDeCriacao!).toLocaleDateString('pt-BE');
       });

      this.heroisGeral = dados;
      this.herois = dados;

    })
  }



  search(event : Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.herois = this.heroisGeral.filter(heroi => {
      return heroi.nome.toLowerCase().includes(value);
    })
  }


  openDialog(id : number){
    this.matDialog.open(ExcluirComponent,{
      width: '350px',
      height: '350px',
      data: {
        id: id
      }
    })
  }


}



