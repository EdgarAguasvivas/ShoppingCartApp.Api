import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-caritem',
  templateUrl: './caritem.component.html',
  styleUrls: ['./caritem.component.css']
})
export class CaritemComponent implements OnInit {

  @Input() cartItem: any

  constructor() { }

  ngOnInit(): void {
  }

}
