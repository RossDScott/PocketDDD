
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { IonicModule } from "@ionic/angular";
import { RatingComponent } from "./rating.component";

@NgModule({
    declarations: [
        RatingComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        IonicModule
      ],
    exports: [
        RatingComponent,
    ]
  })
  export class RatingComponentModule { }