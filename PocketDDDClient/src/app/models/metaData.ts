

export interface CampaignOutlet{
    id: number;
    outletCode: string;
    outletName: string;
    street: string;
    town: string;
    postCode: string;
    groupId: number;
}

export interface CampaignOutletGrouping{
    id: number;
    name: string;
}

export interface CampaignProduct{
    id: number;
    name: string;
    offerDiscount: number;
    rebate: number;
    acceptableMin: number;
    acceptableMax: number;
}

export interface CampaignQuestionOptions{
    list: string;
    subTitle?: string
}

export interface CampaignQuestion{
    id: number;
    question: string;
    questionType: string;
    options: CampaignQuestionOptions;
    isRequired: boolean;
    isEncrypted: boolean
    order: number;
}

export interface CampaignGroupMetaData{
    version: number;
    outlets: CampaignOutlet[];    
    outletGroupings: CampaignOutletGrouping[];
    products: CampaignProduct[];
    questions: CampaignQuestion[];
}