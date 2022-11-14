import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product = new Product();
  formproduct:  FormGroup;
  productId: number = 0;

  constructor(private fb:FormBuilder,private productservice: ProductService,private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.formproduct = this.fb.group({
      id: 0,
      product_name: ['', Validators.required],
      product_code: ['', Validators.required],
      price: [0, Validators.required],
      quantity: [0, Validators.required]
    });

    this.route.params.subscribe(params => {
      debugger;
      this.productId = params['id'];

      this.productservice.getProduct(this.productId).subscribe(
        user => this.loadForm(user)  
    );
    
  });
  }

  loadForm(product: any) {
    debugger;
    this.formproduct.patchValue({
      id: product.id,
      product_name: product.product_name,
      product_code: product.product_code,
      price: product.price,
      quantity: product.quantity,
    });
  }

  get formControl() {
    return this.formproduct.controls;
  }

  editProduct() {
    this.productservice.putProduct(this.productId,this.formproduct.value)
      .subscribe(
        response => {
          console.log(response);
          alert('El producto fue actualizado!');
        },
        error => {
          alert(error);
          console.log(error);
        });
  }

}
