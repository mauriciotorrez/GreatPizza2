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
  ingredientsByPizzaId:string[];
  allIngredients:string[];
  resultOK :any;
  updatePizzaModel:Pizza;
  newPizzaModel:Pizza;

  ngOnInit(){

    this._greatPizzaService.getPizzas()
    .subscribe
    (
      data=>
      {
        this.lstComments = data;
      }
    );
/*
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

*/
   
    
this.getAllIngredients();


}

getPizzaIngredientsById(id:number){
  this._greatPizzaService.getPizzaById(id)
  .subscribe
  (
    data=>
    {
      if (data !== null && data !== 'undefined' && data !== '')
      {
        this.ingredientsByPizzaId = data.split(',');
      }
      else
      {
        this.ingredientsByPizzaId = [];
      }
    }
  );
}

getAllIngredients(){
  this._greatPizzaService.allIngredients()
  .subscribe
  (
    data=>
    {
      this.allIngredients= data;
    }
  );
}

onClickAddPizza(){
  alert('add pizza');

  this._greatPizzaService.addPizza(this.newPizzaModel)
  .subscribe
  (
    data=>
    {
      this.resultOK = data;
    }
  );
  

}


onClickSavePizza(){
  alert('edit pizza');

  this._greatPizzaService.addPizza(this.updatePizzaModel)
  .subscribe
  (
    data=>
    {
      this.resultOK = data;
    }
  );
  
}

}
