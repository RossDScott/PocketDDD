import { ClientMetaDataSyncResponseDTO, TimeSlotDTO, TrackDTO, SessionDTO } from './serverDTO';

export interface SessionItemVM{ 
    session: SessionDTO, 
    track: TrackDTO 
}