delete [Sessions]
delete TimeSlots
delete Tracks
delete EventDetail

GO

DBCC CHECKIDENT ('[EventDetail]', RESEED, 0);
DBCC CHECKIDENT ('[Tracks]', RESEED, 0);
DBCC CHECKIDENT ('[TimeSlots]', RESEED, 0);
DBCC CHECKIDENT ('[Sessions]', RESEED, 0);

GO

Insert into EventDetail values (1)

Insert into Tracks values (1, 'Track 1','Room 1')
Insert into Tracks values (1, 'Track 2','Room 2')
Insert into Tracks values (1, 'Track 3','Room 3')
Insert into Tracks values (1, 'Track 4','Room 4')
Insert into Tracks values (1, 'Track 5','Room 5') 

Insert into TimeSlots values (1,'2022-06-25 08:30:00.0000000 +01:00','2022-06-25 09:00:00.0000000 +01:00', 'Registration') 
Insert into TimeSlots values (1,'2022-06-25 09:10:00.0000000 +01:00','2022-06-25 09:30:00.0000000 +01:00', 'Welcome') 
Insert into TimeSlots values (1,'2022-06-25 09:30:00.0000000 +01:00','2022-06-25 10:30:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2022-06-25 10:30:00.0000000 +01:00','2022-06-25 10:45:00.0000000 +01:00', 'Tea & Coffee') 
Insert into TimeSlots values (1,'2022-06-25 10:45:00.0000000 +01:00','2022-06-25 11:45:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2022-06-25 11:45:00.0000000 +01:00','2022-06-25 12:00:00.0000000 +01:00', 'Tea & Coffee') 
Insert into TimeSlots values (1,'2022-06-25 12:00:00.0000000 +01:00','2022-06-25 13:00:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2022-06-25 13:00:00.0000000 +01:00','2022-06-25 14:15:00.0000000 +01:00', 'Lunch & lightning talks') 
Insert into TimeSlots values (1,'2022-06-25 14:15:00.0000000 +01:00','2022-06-25 15:15:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2022-06-25 15:15:00.0000000 +01:00','2022-06-25 15:45:00.0000000 +01:00', 'Afternoon Tea') 
Insert into TimeSlots values (1,'2022-06-25 15:45:00.0000000 +01:00','2022-06-25 16:45:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2022-06-25 16:45:00.0000000 +01:00','2022-06-25 17:15:00.0000000 +01:00', 'Closing')

Insert into [Sessions] values (1,'The Source Code Generation Game','','There has been a lot of buzz around the','Steve Collins',1,3,newid())
Insert into [Sessions] values (1,'The New Elasticsearch .NET Client: Getting Started and Behind the Scenes','','Elasticsearch is a leading search and analytics','Steve Gordon',2,3,newid())
Insert into [Sessions] values (1,'c','','c','c',3,3,newid())
Insert into [Sessions] values (1,'d','','d','d',4,3,newid())

Insert into [Sessions] values (1,'.NET Minimal APIs','','In this session we''ll take a look at the "what", "why" and "how" ','Kevin Smith',1,5,newid())
Insert into [Sessions] values (1,'e','','e','e',2,5,newid())
Insert into [Sessions] values (1,'f','','f','f',3,5,newid())
Insert into [Sessions] values (1,'g','','g','g',4,5,newid())

Insert into [Sessions] values (1,'h','','h','h',1,7,newid())
Insert into [Sessions] values (1,'i','','','',2,7,newid())
Insert into [Sessions] values (1,'j','','','',3,7,newid())
Insert into [Sessions] values (1,'k','','','',4,7,newid())

Insert into [Sessions] values (1,'l','','','',1,9,newid())
Insert into [Sessions] values (1,'m','','','',2,9,newid())
Insert into [Sessions] values (1,'n','','','',3,9,newid())
Insert into [Sessions] values (1,'o','','','',4,9,newid())

Insert into [Sessions] values (1,'p','','','',1,11,newid())
Insert into [Sessions] values (1,'q','','','',2,11,newid())
Insert into [Sessions] values (1,'r','','','',3,11,newid())
Insert into [Sessions] values (1,'s','','','',4,11,newid())

