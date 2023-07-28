import { Component } from '@angular/core';
import { FakedataService } from '../../fakedata.service';
import { Product, ResponseProduct } from '../../models/product';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
  providers: [FakedataService]
})
export class MainComponent {

  products:Product[] = [];

  nombre:string = '';
  precio:number = 0;
  isLoading:boolean = false;
  //injection
  constructor(private fakedataService: FakedataService) { 
    
  }
  //oninit
  ngOnInit(): void {
    this.isLoading = true;
    this.fakedataService.getProducts().pipe().subscribe((data: ResponseProduct)=>{
      this.isLoading = false;
      this.products = data.products;
    })
  }

  setName(event: any){
    this.nombre = event.target.value;
  }

  setPrice(event: any){
    this.precio = event.target.value;
  }


  search(){
    this.isLoading = true;
    this.fakedataService.getProducts().pipe().subscribe((data: ResponseProduct)=>{
      this.isLoading = false;
      this.products = data.products.filter((product: Product) => {
        return product.title.toLowerCase().includes(this.nombre.toLowerCase());
      });
    })
  }
}
