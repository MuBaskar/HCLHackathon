import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable,of,map } from 'rxjs';
import { environment } from 'src/environments/environment';
import {UserModel} from '../Models/UserModel'


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl = `${environment.baseUrl}`

  constructor(private http: HttpClient) { }

  registerUser(user: UserModel): Observable<boolean> {
    
    //return of(true);
    
    return this.http.post<boolean>(this.baseApiUrl + 'register', user, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    }).pipe(map((res:any)=>res));
  }

  login(user: UserModel):Observable<string>{
    return this.http.post<string>(this.baseApiUrl + 'login', user, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    }).pipe(map((res:any)=>res));
  }
}
