import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient, HttpParams} from '@angular/common/http';
import {Pizza} from './classes/pizza';


@Injectable()

export class greatPizzaService
{

    constructor(private httpclient:HttpClient ){}

    getPizzas():Observable<any>{
        //return this.httpclient.get("https://jsonplaceholder.typicode.com/posts/1/comments");
        return this.httpclient.get("http://localhost:52084/api/greatpizza/getpizzas");

    }

    getPizzaById(paramId:number):Observable<any>{
       // let paramId = new HttpParams().set('id','1');
       // return this.httpclient.get("http://localhost:52084/api/greatpizza/GetIngredientsByPizzaId", {params:paramId});

        return this.httpclient.get(`http://localhost:52084/api/greatpizza/GetIngredientsByPizzaId/${paramId}`);

    }

    addPizza(pi:Pizza):Observable<any>{
        // let paramId = new HttpParams().set('id','1');
        // return this.httpclient.get("http://localhost:52084/api/greatpizza/GetIngredientsByPizzaId", {params:paramId});
 
         return this.httpclient.post('http://localhost:52084/api/greatpizza/AddPizza',pi);
 
     }


}