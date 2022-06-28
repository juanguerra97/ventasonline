import {Component, OnInit} from '@angular/core';
import {Producto, ProductosClient} from "../web-api-client";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  productos: Producto[] = [];
  loadingProductos = true;

  constructor(private productosClient: ProductosClient) {
  }

  ngOnInit() {
    this.cargarProductos();
  }

  private cargarProductos() {
    this.loadingProductos = true;
    this.productosClient.getProductos()
      .subscribe({
        next: res => {
          this.productos = res;
          this.loadingProductos = false;
        },
        error: error => {
          console.error(error);
          this.loadingProductos = false;
        }
      })
  }

}
