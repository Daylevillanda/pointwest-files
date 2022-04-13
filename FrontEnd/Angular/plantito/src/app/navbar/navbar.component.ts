import { Component, ElementRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ICart } from '../models/carts';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {

  carts$: BehaviorSubject<ICart[]>;
  inputSearch: string | null = '';
  @ViewChild('inputRef') inputElementRef: ElementRef | undefined;
  
  constructor(private svc: ProductService, private router: Router) {
    this.carts$ = this.svc.carts$;
   }

  search(){
    if (this.inputSearch){      
      this.router.navigate([`/search/${this.inputSearch}`])
      this.inputElementRef?.nativeElement.blur();      
    }
  }

  getTotalCart(): number {
    return this.svc.getTotalCart();
  }

  clearSearch(): void {
    this.inputSearch = '';
  }

}
