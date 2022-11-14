import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.css']
})
export class ProductViewComponent implements OnInit {
 
  productList: Product[] = [];

  constructor(private productservice: ProductService,private router: Router) { }

  ngOnInit(): void {
    this.getProducts();
  }

  editUser(item:any){
    debugger;
    this.router.navigate(['/productedit/'+item.id]);
  }
  
  getProducts() {
    debugger;
    this.productservice.getProducts().subscribe(products => {    
      this.productList = products;
    })
  }
  deleteProduct(id:number): void {
    this.productservice.deleteProduct(id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/productindex']);
        },
        error => {
          console.log(error);
        });
        this.getProducts();
  }

}
