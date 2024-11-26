import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Response } from '../models/Response';
import { Heroi } from '../models/Heroi';

@Injectable({
  providedIn: 'root'
})
export class HeroiService {

  private apiUrl = `${environment.baseApiUrl}/Heroes`

  constructor(private http: HttpClient) { }


  GetHerois() : Observable<Response<Heroi[]>> {
      return this.http.get<Response<Heroi[]>>(this.apiUrl);
  }

  GetHeroi(id: number) : Observable<Response<Heroi>> {
    return this.http.get<Response<Heroi>>(`${this.apiUrl}/${id}`);
  }

  CreateHeroi(heroi: Heroi) : Observable<Response<Heroi[]>> {
    return this.http.post<Response<Heroi[]>>(`${this.apiUrl}`, heroi);
  }

  EditHeroi(heroi : Heroi) : Observable<Response<Heroi[]>> {
      return this.http.put<Response<Heroi[]>>(`${this.apiUrl}`, heroi);
  }

  InativaHeroi(id: number) : Observable<Response<Heroi[]>>{
      return this.http.put<Response<Heroi[]>>(`${this.apiUrl}/InativaHeroi/${id}`, id);
  }

  ExcluirHeroi(id: number) : Observable<Response<Heroi[]>>{
    return this.http.delete<Response<Heroi[]>>(`${this.apiUrl}?id=${id}`)
  }
}
