import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import { Pizza } from './../classes/pizza';


@Injectable()

export class greatPizzaService
{

    constructor(private httpclient:HttpClient ){}
    endPoint:string = "http://localhost:52084/api/greatpizza";

    getPizzas():Observable<any>{
        return this.httpclient.get(`${this.endPoint}/getpizzas`);
    }

    getPizzaById(paramId:number):Observable<any>{
        return this.httpclient.get(`${this.endPoint}/GetIngredientsByPizzaId/${paramId}`);
    }

     allIngredients():Observable<any>{
         return this.httpclient.get(`${this.endPoint}/GetIngredients`);
     }

    addPizza(pi:Pizza):Observable<any>{
        return this.httpclient.post(`${this.endPoint}/AddPizza`,pi);
    }

    editPizza(pi:Pizza):Observable<any>{
        return this.httpclient.post(`${this.endPoint}/AddPizza`,pi);
    }


}