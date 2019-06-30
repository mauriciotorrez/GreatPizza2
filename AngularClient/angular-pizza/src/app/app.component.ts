import { Component } from '@angular/core';
import {greatPizzaService} from './services/greatpizzaapi.service';
import {Pizza} from './classes/pizza';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-pizza';

  constructor(private _greatPizzaService:greatPizzaService ){

  }

  lstComments:Pizza[];
  ingredientsByPizzaId:string;
  resultOK :any;

  ngOnInit(){

    this._greatPizzaService.getPizzas()
    .subscribe
    (
      data=>
      {
        this.lstComments = data;
      }
    );

    var oPizza = new Pizza();
    oPizza.name_pizza = 'test new pizza';
    oPizza.idIngredient = '1,3';


    this._greatPizzaService.addPizza(oPizza)
    .subscribe
    (
      data=>
      {
        this.resultOK = data;
      }
    );



    
    




}

getPizzaIngredientsById(id:number):string{
  let result :'';
  this._greatPizzaService.getPizzaById(id)
  .subscribe
  (
    data=>
    {
      result: data;
    }
  );
  return result;

}

}
