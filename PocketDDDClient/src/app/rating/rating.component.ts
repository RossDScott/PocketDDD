import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
    selector: 'app-rating',
    templateUrl: './rating.component.html',
    styleUrls: ['./rating.component.scss'],
})
export class RatingComponent implements OnInit {
    @Input() rating: number | null;
    @Output() ratingChange: EventEmitter<number> = new EventEmitter<number>();

    constructor() { }

    ngOnInit() { }

    handleRatingStarClicked(rating: number){
        this.rating = rating;
        this.ratingChange.emit(rating);
    }
}
