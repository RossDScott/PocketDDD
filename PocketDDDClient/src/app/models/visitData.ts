export interface Visit {
    clientId: string;
    outletId: number;
    startDateTimestamp: Date;
    endDateTimestamp?: Date | undefined;
    rebateGiven?: number | undefined;
    totalSales?: number | undefined;
    packsSold?: number | undefined;
    visitProducts: VisitProduct[];
    visitSales: VisitSale[];
}

export interface VisitProduct{    
    productId: number;        
    normalPrice: number;
    offerPrice: number;
    rebate: number;
}

export interface VisitSale{
    clientId: string;
    visitClientId: string;
    start: Date;
    end?: Date | undefined;
    isTobaccoSale: boolean;
    gpsCords?: string | undefined; //dont worry about for now!!!
    salesTotal?: number | undefined;
    packCount?: number | undefined;
    rebateTotal?: number | undefined;

    salesLines?: VisitSalesLine[] | undefined;
    salesAnswers?: VisitSaleAnswer[] | undefined;
}

export interface VisitSalesLine{
    productId: number;
    qty: number;
    salesSubTotal?: number | undefined;
    rebateSubTotal?: number | undefined;
}

export interface VisitSaleAnswer{
    questionId: number;
    answer: string;
}