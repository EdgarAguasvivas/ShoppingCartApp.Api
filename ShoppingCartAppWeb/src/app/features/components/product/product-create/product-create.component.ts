import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  
  formproduct:  FormGroup;
  user: Product = new Product();
  data: any;
  massage:string; 

  constructor(private fb:FormBuilder,private router:Router,private productservice: ProductService) { 
    this.formproduct = fb.group({
      product_name: ['',Validators.required],
      product_code: ['',Validators.required],
      price: [0,Validators.required],
      quantity: [0,Validators.required]             
    })
  }

  ngOnInit(): void {
  }

  create(){
    debugger;
    this.productservice.postProduct(this.formproduct.value).subscribe(    
      data =>    
      {           
        this.formproduct.reset(); 
        alert("Creado correctamente!");
      }); 
  }

}
