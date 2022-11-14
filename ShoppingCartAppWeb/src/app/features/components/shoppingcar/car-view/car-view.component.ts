import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-car-view',
  templateUrl: './car-view.component.html',
  styleUrls: ['./car-view.component.css']
})
export class CarViewComponent implements OnInit {

  cartItems = new Array<Product>()
  cartTotal = 0

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    this.loadCartItems(); 
  }

  loadCartItems() {   
    this.cartItems = this.cartService.listCartItemsLocalStorage;
    this.calcCartTotal();
    debugger;
  }

  calcCartTotal() {
    this.cartTotal = 0;
    for (var i = 0; i <= this.cartItems.length; i++) {
      this.cartTotal += (this.cartItems[i].quantity == undefined ? 0 : this.cartItems[i].quantity * this.cartItems[i].price == undefined ? 0 : this.cartItems[i]?.price)
    }   
}
}
