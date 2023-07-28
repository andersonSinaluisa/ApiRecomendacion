import { Component, Input, ViewChild } from '@angular/core';
import { NgbCarouselModule } from '@ng-bootstrap/ng-bootstrap';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-card-item',
  templateUrl: './card-item.component.html',
  styleUrls: ['./card-item.component.css'],
})
export class CardItemComponent {

  //recivir por parametro el nombre
  @Input () nombre = 'Nombre del producto';

  //recivir por parametro la imagen
  @Input () imagenes:string[] = [];

  //recivir por parametro el precio
  @Input () precio = 0;
  @Input () descripcion = 'Descripcion del producto';

  constructor () { }
  slideConfig = {
    slidesToShow: 1,
    slidesToScroll: 1,
    dots: true,
    autoplay: true,
    autoplaySpeed: 3000
  };

  currentIndex = 0;
  slideWidth = 0;
  @ViewChild('carousel') carousel: any;

  nextSlide(): void {
    this.carousel.next();
  }

  prevSlide(): void {
    this.carousel.prev();
  }
}
