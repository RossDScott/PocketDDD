delete [UserSessionFeedback]
delete [UserEventFeedback]
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

Insert into Tracks values (1, 'Track 1','The Junction')
Insert into Tracks values (1, 'Track 2','Brunel''s Boardroom')
Insert into Tracks values (1, 'Track 3','Brunel''s Breakout Room')
Insert into Tracks values (1, 'Track 4','Clock Tower Room')

Insert into TimeSlots values (1,'2023-04-29 08:30:00.0000000 +01:00','2023-04-29 09:00:00.0000000 +01:00', 'Registration & Breakfast | Sponsored by Elastic Mint') 
Insert into TimeSlots values (1,'2023-04-29 09:00:00.0000000 +01:00','2023-04-29 09:30:00.0000000 +01:00', 'Welcome briefing') 
Insert into TimeSlots values (1,'2023-04-29 09:30:00.0000000 +01:00','2023-04-29 10:30:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2023-04-29 10:30:00.0000000 +01:00','2023-04-29 10:45:00.0000000 +01:00', 'Tea & Coffee | Sponsored by ALD Automotive') 
Insert into TimeSlots values (1,'2023-04-29 10:45:00.0000000 +01:00','2023-04-29 11:45:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2023-04-29 11:45:00.0000000 +01:00','2023-04-29 12:00:00.0000000 +01:00', 'Tea & Coffee | Sponsored by ALD Automotive') 
Insert into TimeSlots values (1,'2023-04-29 12:00:00.0000000 +01:00','2023-04-29 13:00:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2023-04-29 13:00:00.0000000 +01:00','2023-04-29 14:15:00.0000000 +01:00', 'Lunch & lightning talks | Sponsored by Just Eat Takeaway.com') 
Insert into TimeSlots values (1,'2023-04-29 14:15:00.0000000 +01:00','2023-04-29 15:15:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2023-04-29 15:15:00.0000000 +01:00','2023-04-29 15:45:00.0000000 +01:00', 'Afternoon Tea | Sponsored by ALD Automotive') 
Insert into TimeSlots values (1,'2023-04-29 15:45:00.0000000 +01:00','2023-04-29 16:45:00.0000000 +01:00', null) 
Insert into TimeSlots values (1,'2023-04-29 16:45:00.0000000 +01:00','2023-04-29 17:15:00.0000000 +01:00', 'Closing & Prize draw')

-- Session 1
Insert into [Sessions] values (1,'Cleaning your Big Ball of Mud with CQS',
'Having worked as a contract developer for many years Matt has had the pleasure of seeing a lot of systems, built using many different patterns and architectures. One thing they all had in common though was that, more often than not, over time the codebase would degrade into a "Big Ball of Mud". The Command Query Separation pattern can help keep code maintainable, easy to test and help you conform to SOLID principles. In this talk, we will discuss what CQS is, its benefits and how it differs from CQRS.','Having worked as a contract developer for many years Matt has had the pleasure of seeing a lot of systems, built using many different patterns and architectures. One thing they all had in common though was that, more often than not, over time the codebase would degrade into a "Big Ball of Mud". The Command Query Separation pattern can help keep code maintainable, easy to test and help you conform to SOLID principles. In this talk, we will discuss what CQS is, its benefits and how it differs from CQRS.',
'Matt Hunt',1,3,newid())

Insert into [Sessions] values (1,'Migrating a cloud native bank away from shared credentials  lessons learnt in technical migrations',
'We will discuss how to lead mass technical migrations in large organisations, beginning with the skills required to get senior stakeholders to give the time, money, and support needed to run the campaign. We’ll also cover demonstrating great decision making and other methods to get everyone aligned with the approach.
 
Getting time and money is one thing, bringing everyone on the journey and making migrations easy is the next challenge! We’ll cover how to thrive as a pseudo product owner (ask, don’t tell) and how to create a great developer experience. We’ll also look at identifying and managing evolving and emerging stakeholders.
 
Finally, we’ll take a deep dive into the technical challenges of moving from static credentials to Azure Managed Identity. We’ll see some of the tooling we built to support the migration and explore the good, the bad and the ugly gotchas!','We will discuss how to lead mass technical migrations in large organisations, beginning with the skills required to get senior stakeholders to give the time, money, and support needed to run the campaign. We’ll also cover demonstrating great decision making and other methods to get everyone aligned with the approach.
 
Getting time and money is one thing, bringing everyone on the journey and making migrations easy is the next challenge! We’ll cover how to thrive as a pseudo product owner (ask, don’t tell) and how to create a great developer experience. We’ll also look at identifying and managing evolving and emerging stakeholders.
 
Finally, we’ll take a deep dive into the technical challenges of moving from static credentials to Azure Managed Identity. We’ll see some of the tooling we built to support the migration and explore the good, the bad and the ugly gotchas!',
'Huw Jeffries',2,3,newid())

Insert into [Sessions] values (1,'Maths + Code = Art',
'As a father of a six year old girl, I often wondered how I could entice my little one into coding and math and steer her away from stereotypical so-called feminine careers. 

One way to do this is by explaining to her the importance of programming and automation in today''s world and show her the lucrative jobs that are available for her such as software development at a Banking Firm. Having tried this and failing miserably, I thought of an alternative.

I showed her a cool motion graphic, or an audio visualizer that''s very colourful, that would make her go "Wow". Without any prompting, she asked me how I made it. Art is a language she speaks (and most kids for that matter). If we can show our kids that "code" is another kind of brush to make art, then we might have a better chance at grabbing their attention.

Aside from this fact, generative and procedural art has many applications in film, games, and virtual production. The goal of this talk is to introduce the concept of visual scripting using Geometry Nodes in Blender. We will finish off by compositing the final result into a Music Video of sorts as a practical example.','As a father of a six year old girl, I often wondered how I could entice my little one into coding and math and steer her away from stereotypical so-called feminine careers. 

One way to do this is by explaining to her the importance of programming and automation in today''s world and show her the lucrative jobs that are available for her such as software development at a Banking Firm. Having tried this and failing miserably, I thought of an alternative.

I showed her a cool motion graphic, or an audio visualizer that''s very colourful, that would make her go "Wow". Without any prompting, she asked me how I made it. Art is a language she speaks (and most kids for that matter). If we can show our kids that "code" is another kind of brush to make art, then we might have a better chance at grabbing their attention.

Aside from this fact, generative and procedural art has many applications in film, games, and virtual production. The goal of this talk is to introduce the concept of visual scripting using Geometry Nodes in Blender. We will finish off by compositing the final result into a Music Video of sorts as a practical example.',
'Murthy Upadhyayula',3,3,newid())

Insert into [Sessions] values (1,'Being Staff Plus',
'For a long period of time the only path that organizations offered developers who wanted to grow their influence was the management track. In recent years organizations have begun to offer individual contributor roles beyond senior developer such as staff or principal engineer. 

Staff Plus roles differ from senior engineering roles and require new skill sets to influence, guide and shape the engineering direction of an organization and often require the engineer to work independently.

In this presentation we will cover what you need to know about Staff Plus roles: 

* Staff Plus Roles and Archetypes
* Moving Beyond Code
* Technical Leadership
* Work on What Matters 

We will cover topics around influence without authority, determining where to spend your time, and how to help the engineering teams succeed.

We will finish with an exploration of how you move toward a Staff Plus role','For a long period of time the only path that organizations offered developers who wanted to grow their influence was the management track. In recent years organizations have begun to offer individual contributor roles beyond senior developer such as staff or principal engineer. 

Staff Plus roles differ from senior engineering roles and require new skill sets to influence, guide and shape the engineering direction of an organization and often require the engineer to work independently.

In this presentation we will cover what you need to know about Staff Plus roles: 

* Staff Plus Roles and Archetypes
* Moving Beyond Code
* Technical Leadership
* Work on What Matters 

We will cover topics around influence without authority, determining where to spend your time, and how to help the engineering teams succeed.

We will finish with an exploration of how you move toward a Staff Plus role',
'Ian Cooper',4,3,newid())

-- Session 2 
Insert into [Sessions] values (1,'SOLID Principles in 5 Nightmares',
'The 5 SOLID principles - popularised by "Uncle" Bob Martin in some of his highly influential books on Object Orientated Software development - are rarely cited directly but they are nevertheless at the heart of a lot of the thinking that goes into modern software development.

These principles have been around in some form or other ever since the 1980s, but continue to be just as relevant today as they were then.

In this talk, we''re going to look at each of the 5 SOLID principles, these being:

* Single Dependency Principle
* Open/Close Principle
* Liskov Substitution Principle
* Interface Segregation Principle
* Dependency Inversion Principle

See what he did there with the names?

We''ll look at each in turn, with the help of some slightly imaginative examples taken from a popular SF franchise.  What are they, what nightmare scenarios can occur if they aren''t followed, and how they can subsequently be applied.','The 5 SOLID principles - popularised by "Uncle" Bob Martin in some of his highly influential books on Object Orientated Software development - are rarely cited directly but they are nevertheless at the heart of a lot of the thinking that goes into modern software development.

These principles have been around in some form or other ever since the 1980s, but continue to be just as relevant today as they were then.

In this talk, we''re going to look at each of the 5 SOLID principles, these being:

* Single Dependency Principle
* Open/Close Principle
* Liskov Substitution Principle
* Interface Segregation Principle
* Dependency Inversion Principle

See what he did there with the names?

We''ll look at each in turn, with the help of some slightly imaginative examples taken from a popular SF franchise.  What are they, what nightmare scenarios can occur if they aren''t followed, and how they can subsequently be applied.',
'Simon Painter',1,5,newid())

Insert into [Sessions] values (1,'User testing in production: how to run a public beta',
'You’ve built something. It isn’t fully ready for a proper launch, but you want to let people start using it anyway. You’re thinking about running a public beta.

Almost every new feature at Anvil makes its debut with a public beta, and I want to share some of the things we’ve learned along the way. For example, when does it makes sense to use one? How do you handle documentation when something isn’t quite official yet, and might be replacing an existing feature? When is it too early to go to beta - or too late?

In this talk, I’ll discuss why and when you might want to run a public beta, and what you can expect out of the experience - good, bad, and ugly. I’ll talk about user feedback: ways to collect it, how to interpret it, and whether you should act on it. Finally, I’ll talk about how to decide when it’s all over, and what to bear in mind as you take the plunge into General Availability.

This talk is aimed at anyone with an interest in feature launches and user engagement. The audience should come away with a good idea of when public betas make sense as a strategy, what the goals of that beta should be, and how best to achieve them.','You’ve built something. It isn’t fully ready for a proper launch, but you want to let people start using it anyway. You’re thinking about running a public beta.

Almost every new feature at Anvil makes its debut with a public beta, and I want to share some of the things we’ve learned along the way. For example, when does it makes sense to use one? How do you handle documentation when something isn’t quite official yet, and might be replacing an existing feature? When is it too early to go to beta - or too late?

In this talk, I’ll discuss why and when you might want to run a public beta, and what you can expect out of the experience - good, bad, and ugly. I’ll talk about user feedback: ways to collect it, how to interpret it, and whether you should act on it. Finally, I’ll talk about how to decide when it’s all over, and what to bear in mind as you take the plunge into General Availability.

This talk is aimed at anyone with an interest in feature launches and user engagement. The audience should come away with a good idea of when public betas make sense as a strategy, what the goals of that beta should be, and how best to achieve them.',
'Eli Holderness',2,5,newid())

Insert into [Sessions] values (1,'Teabags, Muddy Knees and Imposter syndrome: Atypical careers in tech [Brought to you by SECCL]',
'In a career spanning the factory floor, call centres, dev teams and board rooms, it''s fair to say Adam has had some pretty varied life experience. In this talk he will share his personal reflections on what it means to navigate a career from an atypical path. He will discuss the value of experience which comes outside of typical education to work routes and how this cognitive diversity adds value, especially in technology. Ultimately, the session will provide insight on what this means for building great teams, and also getting the best out of ourselves.','In a career spanning the factory floor, call centres, dev teams and board rooms, it''s fair to say Adam has had some pretty varied life experience. In this talk he will share his personal reflections on what it means to navigate a career from an atypical path. He will discuss the value of experience which comes outside of typical education to work routes and how this cognitive diversity adds value, especially in technology. Ultimately, the session will provide insight on what this means for building great teams, and also getting the best out of ourselves.',
'Adam Jones',3,5,newid())

Insert into [Sessions] values (1,'A Day In The Life of A Data Scientist',
'In this hour long session I''ll walk you through a typical day in the life of a data scientist (me). We''ll look at a real world question and how I go about working out the answer.','In this hour long session I''ll walk you through a typical day in the life of a data scientist (me). We''ll look at a real world question and how I go about working out the answer.',
'Gary Short',4,5,newid())

-- Session 3
Insert into [Sessions] values (1,'High Performance JSON Serialization with Code Generation on C# 11 and .NET 7.0',
'In this talk you will see how features added to recent versions of C# can dramatically improve parsing and generation of JSON data compared with longer established .NET JSON handling mechanisms. You will see how to use high-performance memory-efficient techniques (including Spans and IO Pipelines), and also how code generators can reduce runtime overheads. This talk will explore the tradeoff between maximizing performance and ease of use, and will show how choose between the various options now available in modern .NET applications.','In this talk you will see how features added to recent versions of C# can dramatically improve parsing and generation of JSON data compared with longer established .NET JSON handling mechanisms. You will see how to use high-performance memory-efficient techniques (including Spans and IO Pipelines), and also how code generators can reduce runtime overheads. This talk will explore the tradeoff between maximizing performance and ease of use, and will show how choose between the various options now available in modern .NET applications.',
'Ian Griffiths',1,7,newid())

Insert into [Sessions] values (1,'Developer Ethics - why is it important ?',
'In this session, we will try to  find answers for important questions


* Are there any code of ethics that every programmer must follow?

* Are there any case studies for breach of ethics from which we can learn ?

* Are there any principles that can be adopted to make the life of a software engineer much easier?

Let''s discuss more in detail in the session.','In this session, we will try to  find answers for important questions


* Are there any code of ethics that every programmer must follow?

* Are there any case studies for breach of ethics from which we can learn ?

* Are there any principles that can be adopted to make the life of a software engineer much easier?

Let''s discuss more in detail in the session.',
'Sneha Ramesh',2,7,newid())

Insert into [Sessions] values (1,'.NET, Azure & Umbraco: The First Twelve Months',
'This talk focuses around my first twelve months of learning and working within the .NET and Azure space, and my first six months of using Umbraco CMS and being involved in its community.

I’ll be talking from my perspective as a former music educator and junior software developer about my experiences of learning new technologies, what I feel are the strengths and the weaknesses of the training materials currently available, and my opinions on how to encourage and support fellow newcomers to the .NET space

For new users and those who’re considering using .NET for the first time I’ll be discussing how to avoid common pitfalls, the most conducive ways to ask constructive questions, where to go for the right (and crucially, helpful) answers, and how can learn by contributing to a technology’s growth.

For more experienced .NETians I’ll be discussing ways to attract, educate and retain new users, supporting them from first time to fulltime!','This talk focuses around my first twelve months of learning and working within the .NET and Azure space, and my first six months of using Umbraco CMS and being involved in its community.

I’ll be talking from my perspective as a former music educator and junior software developer about my experiences of learning new technologies, what I feel are the strengths and the weaknesses of the training materials currently available, and my opinions on how to encourage and support fellow newcomers to the .NET space

For new users and those who’re considering using .NET for the first time I’ll be discussing how to avoid common pitfalls, the most conducive ways to ask constructive questions, where to go for the right (and crucially, helpful) answers, and how can learn by contributing to a technology’s growth.

For more experienced .NETians I’ll be discussing ways to attract, educate and retain new users, supporting them from first time to fulltime!',
'Richard Jackson',3,7,newid())

Insert into [Sessions] values (1,'gRPC in .NET: Basics and More',
'gRPC is Google''s implementation of RPC. With .NET Core 3.0, gRPC has become a first-class support in .NET. 

In my session, we will look at what gRPC is, and how to both create a gRPC service and consume it. We will also discuss the four modes or methods of gRPC, versioning and also talk about options when it comes to hosting gRPC services.','gRPC is Google''s implementation of RPC. With .NET Core 3.0, gRPC has become a first-class support in .NET. 

In my session, we will look at what gRPC is, and how to both create a gRPC service and consume it. We will also discuss the four modes or methods of gRPC, versioning and also talk about options when it comes to hosting gRPC services.',
'Poornima Nayar',4,7,newid())

-- Session 4 
Insert into [Sessions] values (1,'Using DDD To Decompose Your Monolith',
'Software design is hard, maybe the hardest part of building software systems...
When designing distributed systems things get even more challenging.
Now that Microservices are so popular, we all want to decompose our monoliths to smaller units of independent components. If we don''t want to end up with a distributed monolith, we need to have a toolbox of design concepts so we can achieve well-defined boundaries between our components groups described as "Services" and "Service Boundaries" in the Service Oriented Architecture or SOA paradigm.

The traditional way of designing systems based on a domain data model with very complex relationships and dependencies may kind of work when building a monolith, but just breaks apart when you building distributed systems.

One of the pillars of distributed system design is to solve the **coupling** problem. 

If we look at the tenants of SOA they all address coupling: 

* **Explicit Boundaries**: In it''s the simplest form it is to find what belongs together and making sure there are no leakages between the defined boundaries of a "Service".
* **Autonomy**: Like in Object orientation, Keep our components and "Services" autonomous, encapsulated and have as little dependencies to the outside as possible.
* **Sharing schema and contracts not classes**: Make sure we don''t introduce coupling by using an open protocol for communication.
* **Compatibility based upon policy**: This is the hardest tenant to articulate, but again, it''s about loose coupling, an explicit API that describes the component''s behaviour.

In order to achieve this, we need to rethink how we design our components and "Services"
We need to move from monolith thinking to distributed thinking, leaving the single relational data model to multiple vertical bounded contexts that together compose a "Service" boundary.

In this talk I will walk through the process of designing a very simplistic and naive vertical slice while introducing the concepts from Domain Driven Design (DDD) and SOA, to build a single vertical, from there you will be able to do your first steps to design a loosely coupled distributed system, and be on the way to find you "Service" boundaries. ','Software design is hard, maybe the hardest part of building software systems...
When designing distributed systems things get even more challenging.
Now that Microservices are so popular, we all want to decompose our monoliths to smaller units of independent components. If we don''t want to end up with a distributed monolith, we need to have a toolbox of design concepts so we can achieve well-defined boundaries between our components groups described as "Services" and "Service Boundaries" in the Service Oriented Architecture or SOA paradigm.

The traditional way of designing systems based on a domain data model with very complex relationships and dependencies may kind of work when building a monolith, but just breaks apart when you building distributed systems.

One of the pillars of distributed system design is to solve the **coupling** problem. 

If we look at the tenants of SOA they all address coupling: 

* **Explicit Boundaries**: In it''s the simplest form it is to find what belongs together and making sure there are no leakages between the defined boundaries of a "Service".
* **Autonomy**: Like in Object orientation, Keep our components and "Services" autonomous, encapsulated and have as little dependencies to the outside as possible.
* **Sharing schema and contracts not classes**: Make sure we don''t introduce coupling by using an open protocol for communication.
* **Compatibility based upon policy**: This is the hardest tenant to articulate, but again, it''s about loose coupling, an explicit API that describes the component''s behaviour.

In order to achieve this, we need to rethink how we design our components and "Services"
We need to move from monolith thinking to distributed thinking, leaving the single relational data model to multiple vertical bounded contexts that together compose a "Service" boundary.

In this talk I will walk through the process of designing a very simplistic and naive vertical slice while introducing the concepts from Domain Driven Design (DDD) and SOA, to build a single vertical, from there you will be able to do your first steps to design a loosely coupled distributed system, and be on the way to find you "Service" boundaries. ',
'Sean Farmar',1,9,newid())

Insert into [Sessions] values (1,'Designing and building an event sourcing system using .NET, CosmosDb and Elastic',
'Getting an event sourcing based solution right is challenging. And that''s true even before you add ambitious quality goals like zero data-loss and great scalability and performance. However, it brings many benefits when done well.

In this talk, we''ll dive into the details of a real-world cloud-native solution built on top of CosmosDb and ElasticSearch. We''ll also show how to get great observability in Datadog as well. Whilst we will show a concrete solution, we''ll cover the key ideas that will translate into whatever technologies you choose.','Getting an event sourcing based solution right is challenging. And that''s true even before you add ambitious quality goals like zero data-loss and great scalability and performance. However, it brings many benefits when done well.

In this talk, we''ll dive into the details of a real-world cloud-native solution built on top of CosmosDb and ElasticSearch. We''ll also show how to get great observability in Datadog as well. Whilst we will show a concrete solution, we''ll cover the key ideas that will translate into whatever technologies you choose.',
'James World & Gareth James',2,9,newid())

Insert into [Sessions] values (1,'Unlocking Diversity: Empowering Men as Allies in Advancing Women in Tech',
'This session will be a thought-provoking and inspiring presentation aimed at encouraging men to take action and become allies for women in tech. The speaker will discuss the current state of gender diversity in the tech industry, highlighting the persistent imbalance between men and women and the barriers preventing women from participating in tech. The speaker will then discuss the crucial role men can play as allies in advancing women in tech and provide specific steps they can take to become effective and influential allies, such as mentorship programs, sponsoring women for leadership positions, and advocating for policies that support gender equality. The session will also address common misconceptions about men and gender equality and encourage men to take action and make a difference in advancing women in tech. The session will conclude with a recap of the importance of male allies in promoting women in tech and a call to action for men to take the initiative to become allies and make a positive impact in the tech industry.','This session will be a thought-provoking and inspiring presentation aimed at encouraging men to take action and become allies for women in tech. The speaker will discuss the current state of gender diversity in the tech industry, highlighting the persistent imbalance between men and women and the barriers preventing women from participating in tech. The speaker will then discuss the crucial role men can play as allies in advancing women in tech and provide specific steps they can take to become effective and influential allies, such as mentorship programs, sponsoring women for leadership positions, and advocating for policies that support gender equality. The session will also address common misconceptions about men and gender equality and encourage men to take action and make a difference in advancing women in tech. The session will conclude with a recap of the importance of male allies in promoting women in tech and a call to action for men to take the initiative to become allies and make a positive impact in the tech industry.',
'Jennifer Daniel',3,9,newid())

Insert into [Sessions] values (1,'Decentralized Identity. Your identity, your control',
'Today we use our digital identity at work, at home, and across every app, service, and device we use. It’s made up of everything we say, do, and experience in our lives. From purchasing tickets for an event, checking into a hotel, to even ordering lunch. Currently, our identity and all our digital interactions are owned and controlled by other parties, in some cases, even without our knowledge.


This identity data has too often been exposed in security breaches. These breaches affect our social, professional, and financial lives. What if there was a better way; one which puts you in control of your identity data... Well now there is.','Today we use our digital identity at work, at home, and across every app, service, and device we use. It’s made up of everything we say, do, and experience in our lives. From purchasing tickets for an event, checking into a hotel, to even ordering lunch. Currently, our identity and all our digital interactions are owned and controlled by other parties, in some cases, even without our knowledge.


This identity data has too often been exposed in security breaches. These breaches affect our social, professional, and financial lives. What if there was a better way; one which puts you in control of your identity data... Well now there is.',
'Dee Bolt',4,9,newid())

-- Session 5
Insert into [Sessions] values (1,'There''s No Such Thing As Plain Text - Dylan Beattie',
'Software is complicated. Machine learning, microservice architectures, message queues... every few months there''s another revolutionary idea to consider, another framework to learn. And underneath so many of these amazing ideas and abstractions is text. When you work in software, you spend your life working with text. Some of those text files are source code, some are configuration files, some of them are documentation. Editors, revision control systems, programming languages - everything from C# and HTML to Git and VS Code is based on the idea of "plain text files". But... what if I told you there''s no such thing?

When we say something is a "plain text file", we''re relying on a huge number of assumptions - about operating systems, editors, file formats, language, culture, history... and, most of the time, that''s OK. But when it goes wrong, "plain text" can lead to some of the weirdest bugs you''ve ever seen... why is there Chinese in the event logs? Why is the city of Aarhus in the wrong place? And why does Magnus Mårtensson always have trouble getting into the USA?  Join Dylan Beattie for a fascinating look into the hidden world of text files - from the history of mechanical teletypes to encodings, collations and code pages. We''ll look at some memorable bugs, some golden rules for working with plain text - and we''ll even find out the story behind the mysterious phrase "pike matchbox" and what it has do with driving in the Soviet Union.','Software is complicated. Machine learning, microservice architectures, message queues... every few months there''s another revolutionary idea to consider, another framework to learn. And underneath so many of these amazing ideas and abstractions is text. When you work in software, you spend your life working with text. Some of those text files are source code, some are configuration files, some of them are documentation. Editors, revision control systems, programming languages - everything from C# and HTML to Git and VS Code is based on the idea of "plain text files". But... what if I told you there''s no such thing?

When we say something is a "plain text file", we''re relying on a huge number of assumptions - about operating systems, editors, file formats, language, culture, history... and, most of the time, that''s OK. But when it goes wrong, "plain text" can lead to some of the weirdest bugs you''ve ever seen... why is there Chinese in the event logs? Why is the city of Aarhus in the wrong place? And why does Magnus Mårtensson always have trouble getting into the USA?  Join Dylan Beattie for a fascinating look into the hidden world of text files - from the history of mechanical teletypes to encodings, collations and code pages. We''ll look at some memorable bugs, some golden rules for working with plain text - and we''ll even find out the story behind the mysterious phrase "pike matchbox" and what it has do with driving in the Soviet Union.',
'Dylan Beattie',1,11,newid())

Insert into [Sessions] values (1,'Everything You Need to Know About Configuration in .NET',
'','',
'Kevin Smith',2,11,newid())

Insert into [Sessions] values (1,'Blazor state management',
'We''ve all seen the Blazor demos and it looks great!
I''ve been working on client side apps since .net 1.0 and it''s been painful. However, we now have mature, robust frameworks like Angular & React, so Blazor is very much on the back foot.

It doesn''t have the mature ecosystem of other frameworks, so this makes it hard to find best practices, robust architectures and production ready solutions.

I made some bad choices on how to deal with state when I started. So in this session I will take you on an accelerated journey of making mistakes, iterating, learning, and ultimately heading in the right direction.','We''ve all seen the Blazor demos and it looks great!
I''ve been working on client side apps since .net 1.0 and it''s been painful. However, we now have mature, robust frameworks like Angular & React, so Blazor is very much on the back foot.

It doesn''t have the mature ecosystem of other frameworks, so this makes it hard to find best practices, robust architectures and production ready solutions.

I made some bad choices on how to deal with state when I started. So in this session I will take you on an accelerated journey of making mistakes, iterating, learning, and ultimately heading in the right direction.',
'Ross Scott',3,11,newid())

Insert into [Sessions] values (1,'Automating Monthly .NET Patching with GitHub Actions and dotnet-outdated [Brought to you by Just Eat Takeaway.com]',
'With the productivity and performance benefits developers gain from using modern .NET over .NET Framework, also comes the less-exciting flip-side - patching the version of .NET in production environments every month to keep your applications secure.

Keeping up-to-date with security and reliability fixes is an important ongoing activity within software development, but it’s not very exciting, and it can be easy to fall behind - what if we could automate the process of patching our applications?

In this talk, we’ll explore how we can use the flexibility of GitHub Actions together with tools such as dotnet-outdated to automatically patch .NET applications on a monthly basis with minimal manual effort.','With the productivity and performance benefits developers gain from using modern .NET over .NET Framework, also comes the less-exciting flip-side - patching the version of .NET in production environments every month to keep your applications secure.

Keeping up-to-date with security and reliability fixes is an important ongoing activity within software development, but it’s not very exciting, and it can be easy to fall behind - what if we could automate the process of patching our applications?

In this talk, we’ll explore how we can use the flexibility of GitHub Actions together with tools such as dotnet-outdated to automatically patch .NET applications on a monthly basis with minimal manual effort.',
'Martin Costello',4,11,newid())

