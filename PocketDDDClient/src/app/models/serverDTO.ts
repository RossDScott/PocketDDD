
export interface LoginDTO {
    name: string;
}

export interface LoginResponseDTO {
    name: string;
    bearerToken: string;
}

export interface ClientMetaDataDTO {
    version: number;
}

export interface ClientMetaDataSyncResponseDTO {
    version: number;
    timeSlots: TimeSlotDTO[];
    tracks: TrackDTO[];
    sessions: SessionDTO[];
}

export interface TimeSlotDTO {
    id: number;
    from: Date;
    to: Date;
    info: string;
}

export interface TrackDTO {
    id: number;
    name: string;
    roomName: string;
}

export interface SessionDTO {
    id: number;
    title: string;
    shortDescription: string
    fullDescription: string;
    speaker: string;
    trackId: number;
    timeSlotId: number;
}

export interface SessionFeedbackDTO {
    clientId: string;
    dateTimeStamp: Date;
    sessionId: number;
    speakerKnowledgeRating: number;
    speakingSkillRating: number;
    comments: string;
}

export interface EventFeedbackDTO {
    clientId: string;
    dateTimeStamp: Date;
    refreshmentsRating: number;
    venueRating: number;
    overall: number;
    comments: string;
}

export interface ServerUpdateResponseDTO {
    clientId: string;
    score: number;
}