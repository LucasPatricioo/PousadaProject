import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environments';

@Injectable({
  providedIn: 'root'
})
export class LoginAdminService {
  private apiUrl: string = "";
  constructor() { 
    this.apiUrl = environment.cadastroApi;
    console.log('entrei no service do login admin');
  }

  
}
