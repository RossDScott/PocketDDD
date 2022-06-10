import { ClientMetaDataSyncResponseDTO, TimeSlotDTO, TrackDTO, SessionDTO } from './serverDTO';

export interface SessionItemVM{ 
    session: SessionDTO, 
    track: TrackDTO
    isBookmarked: boolean;
}

export interface MetaDataVM{
    timeSlots: TimeSlotVM[];
}

export interface TimeSlotVM{
    id: number;
    from: Date;
    to: Date;
    info: string;

    sessions: SessionItemVM[];
}