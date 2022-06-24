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

Insert into TimeSlots values (1,'2022-06-25 08:30:00.0000000 +01:00','2022-06-25 09:00:00.0000000 +01:00', 'Registration') 
Insert into TimeSlots values (1,'2022-06-25 09:00:00.0000000 +01:00','2022-06-25 09:30:00.0000000 +01:00', 'Welcome') 
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

-- Session 1
Insert into [Sessions] values (1,'The Source Code Generation Game','There has been a lot of buzz around the introduction of source code generators in .NET 5  and Microsoft has been building on this in .NET 6 and 7. But, how did we get here and what may the future hold?',
'There has been a lot of buzz around the introduction of source code generators in .NET 5 and Microsoft has been building on this in .NET 6 and there is more to come in .NET 7. 

But, how did we get here and what may the future hold?

Starting with the question of "What is code generation?", I present a brief history of my journey into source code generation, starting with the ZX Spectrum (program published in a UK magazine to convert machine code into BASIC DATA statements), through the Visual Basic 3-6 years (VB code created when element clicked upon; tools to generate VB from SQL tables and stored procs)

I will then move on to do a whistle-stop tour of
* How .NET introduced tooling in Visual Studio for code-generation for SOAP Service Reference clients, RESX resources and the pitfalls of the code generated
* How previously, most code generation has been template based using external tooling run outside VS to generate files that need to be manually included in .NET projects to compile
* Introduction of T4 templates in Visual Studio (leading onto .NET Core''s dotnet new command line templates)
* Code generation "on-the-fly" in Regular Expressions (intermediate code or compile to MSIL) and Entity Framework (SQL statement generation)
* IL Weaving vs Source Code Generation
*  Latest version of service reference code generation for REST and gRPC

The remainder of the talk will focus on the source generators introduced with .NET 5 and 6, covering
* How they differ from traditional template based code generation by being part of the compilation process
* Tooling to help with debugging in Visual Studio
* Gotchas with the tooling in Visual Studio!
* Unit testing code generation
* Microsoft''s use of generators in .NET 6

Lastly, we will look at where source generators may go in the future
* Enhancements proposed for .NET 7
* AI enhanced code generation with Intellicode and Github Copilot integration?
* "Computer make it so" - Experiments being done in AI generated code without a template or specification',
'Steve Collins',1,3,newid())
Insert into [Sessions] values (1,'The New Elasticsearch .NET Client: Getting Started and Behind the Scenes','In this session, we''ll learn about leveraging the power of Elasticsearch within .NET applications, utilising the new Elasticsearch .NET client library. Join Steve to learn about the redesigned client, how to get started and take a peek behind the scenes with its development.',
'Elasticsearch is a leading search and analytics solution used by thousands of companies worldwide for use cases, including search, analytics, monitoring and security information and event management (SIEM). With an emphasis on speed, scale, and relevance, it''s transforming how the world uses data.

In this session, we''ll learn about leveraging the power of Elasticsearch within .NET applications, utilising the new Elasticsearch .NET client library. Join Steve to learn about the .NET client and how to install it in .NET applications and use it to begin indexing and searching documents. We''ll even take a sneak peek at how we maintain the library using code generation.

This session is aimed at software developers looking to get started by combining the capabilities of Elasticsearch with their .NET applications. You''ll leave with the core knowledge required to begin using Elasticsearch and the .NET client library.',
'Steve Gordon',2,3,newid())
Insert into [Sessions] values (1,'Mastering MLOps in Azure','Software Developers/Engineers are being asked more and more to work with various aspects of data, in particular the productionisation of Machine Learning Models. In this session we will talk about various Azure technologies we can use to achieve this, including how to manage Feature Stores and monitoring model life cycles.',
'Software Developers/Engineers are being asked more and more to work with various aspects of data, in particular the productionisation of Machine Learning Models. In this session we will talk about various Azure technologies we can use in our day jobs to achieve this, including how to manage Feature Stores and monitoring model life cycles, plus we will discuss the different architectures that can be implemented.

"85% of big data projects fail" (Gartner, 2017). "87% of data science projects never make it to production" (VentureBeat, 2019). "Through 2022, only 20% of analytic insights will deliver business outcomes"  (Gartner, 2019). When working with data it is vital that different Data Professionals and Software Developers/Engineers work in harmony together for successful outcomes, consequently we will also cover how we can try to best achieve this and how this has been done when working with clients in our day job.

The session will be delivered by myself, a Data Engineering Consultant with a background in Software Engineering, and my colleague Luke Menzies, who is a Data Science Consultant',
'Anna Wykes and Luke Menzies',3,3,newid())
Insert into [Sessions] values (1,'Automated Azure Dashboards Generation','Automated Azure Dashboards Generation','Azure Dashboards are a great way in which to have visibility of your platform in Azure. Application Insights / Log Analytics are tools that integrate seamlessly with other Azure resources which captures valuable telemetry you need to know to understand your system. The process of creating those visualisations can be a fun and creative one, but difficult to manage if you have multiple environments, want to manage change of dashboards as static code, reuse visualisations easily. I shall be showing what we have developed here at ClearBank that allows engineers to use their known tech stack to builds applications, and also produce Azure Dashboards.',
'Joshan Mahmud',4,3,newid())

-- Session 2 
Insert into [Sessions] values (1,'.NET Minimal APIs','The Minimal API story started in November 2019, it was introduced to eliminate the barrier to entry for creating C# APIs. Minimal APIs have minimal dependencies and are ideal for microservices and apps that will have minimum files, features, and dependencies in ASP.NET Core.','In this session we''ll take a look at the "what", "why" and "how" around the .NET Minimal APIs and how we can utilize these to make our API faster and more understandable. We''ll also cover the new .NET Minimal APIs coming in .NET 7!',
'Kevin Smith',1,5,newid())
Insert into [Sessions] values (1,'Docker is a gateway Drug - .NET Everywhere','As an old-school dot NET developer, who had spent a lot of time building applications on IIS - first using WebForms and then MVC, when Docker came along I was initially a little apprehensive about it. In this talk I go through my journey of discovery - learning about docker, and and then about microservices, and then about devOps and getting more familiar with testing and how I''ve grown to love it.',
'As an old-school dot NET developer, who had spent a lot of time building web applications on IIS - first using WebForms and then MVC, when Docker came along I was initially a little apprehensive about it. In this talk I go through my journey of discovery - learning about docker, and and then about microservices, and then about devOps and getting more familiar with testing and how I''ve grown to love it.

I''ll go through : 
* My first exposure to linux (dual booting gentoo in the 00s)
* Raspberry Pis from 2 (pre .NET core) to the newer ones
* Building websites in webforms and MVC
* Hosting them on a raspberry Pi in .NET Core 3.1
* Running Docker on a raspberry Pi (Sql Azure edge)
* Getting my Pis running a K3s cluster + learning Kubernetes
* Microservices and Micro-architectures in containers
* Devops + all that jazz

This take tale will wander a little, but hopefully be something that anyone who is yet to really get to play with the cool cross platform tools available now with .NET can use to show what''s possible.',
'Carl Sargunar',2,5,newid())
Insert into [Sessions] values (1,'Software Architecture - In Search of The Fourth Chord','Discussing software architecture, and giving some examples of some of the more popular patterns.','Having never really played a guitar, I once heard someone tell me that all you really needed to learn were three or four chords, and you could do a good impression of most [rock] songs.  Whether or not that''s true, I have no idea - however, there are a few key principles in software architecture that will get you most of the way there.  In this talk, we''ll cover some popular patterns, and talk about their relative advantages and disadvantages.  We''ll also look at a couple of examples of these patterns using .Net.',
'Paul Michaels',3,5,newid())
Insert into [Sessions] values (1,'Workshop: how to run user experience testing','Usability testing is super easy, and shouldn''t be a big deal.
Split into teams and run some simple tests on your favourite websites to see how they perform.
We''ll cover choosing the right type of test to conduct, planning it, writing your questions, doing it and taking notes.','Usability testing is super easy, and shouldn''t be a big deal.
Split into teams and run some simple tests on your favourite websites to see how they perform.
We''ll cover choosing the right type of test to conduct, planning it, writing your questions, doing it and taking notes.',
'Amy Lobé',4,5,newid())

-- Session 3
Insert into [Sessions] values (1,'Azure Cognitive Services – AI for everyone!','Artificial Intelligence – everyone wants to get involved but many find it too difficult to start. Microsoft have built a suite of APIs that make getting started a breeze and before anyone thinks that this is all a bit noddy, we have used this at my firm to build multi award winning software.

In this beginners session, I will introduce you to the different areas within Cognitive Services and if the presentation gods are kind we will have plenty of demos.
','Artificial Intelligence – everyone wants to get involved but many find it too difficult to start. Microsoft have built a suite of APIs that make getting started a breeze and before anyone thinks that this is all a bit noddy, we have used this at my firm to build multi award winning software.

In this beginners session, I will introduce you to the different areas within Cognitive Services and if the presentation gods are kind we will have plenty of demos.',
'Phil Simpson',1,7,newid())
Insert into [Sessions] values (1,'At Least Once','A discussion of Pat Helland''s paper ''Life Beyond Distributed Transactions'' and a demonstration of the .NET OSS project Brighter''s Outbox support.','We want to ensure that all parties to a transaction are consistent. In a distributed system two-phase commit becomes a barrier to scaling. Instead we rely on eventual consistency. But for an even driven architecture, what does "relying on eventual consistency"  mean in practice?

Drawing on Pat Helland''s paper "Life Beyond Distributed Transactions", in this presentation we will look at: 

The two approaches we can take towards ensuring eventual consistency: choreography and orchestration, and the trade off between them. 
Why asynchronous approaches are more reliable.
What to do if things go wrong or compensation, and the different strategies we have from retry to reservation.
How we deal with stale data.
Why we can only ever promise "at least once", and how we offer "at least once."

Finally, we will demo  the Outbox, using the .NET OSS library Brighter and EF Core, to show how you can ensure "at least once".',
'Ian Cooper',2,7,newid())
Insert into [Sessions] values (1,'DDD, The Value Of Value Objects','DDD, The Value Of Value Objects','Domain Driven Design has many a parts to it around strategic and tactical patterns. Knowing which ones to apply to get the most value out is a challenge.
I want to share the learnings that I''ve gotten from entering a new organisation and seeing what patterns can be applied with little effort but result in massive gains. Moreover, I want to talk about software correctness, utilising the types system to your advantage. Avoiding death by a thousand primitives.',
'Callum Linington',3,7,newid())
Insert into [Sessions] values (1,'Data Scientists, Making Sh!t up Since 1974','By now you will all have seen data science talks where presenters have said "We just download data from here, and blend it with data from there, then we run it through an algorithm and *jazz hands* we make a prediction". Well, okay, cool, but what happens if you don''t have any data? As a data scientist, you can''t just shrug and say "dunno mate". In this session we''ll examine the process of elicitation and we''ll use it to predict the success of this conference, live, using Python and Jupyter Notebooks.','By now you will all have seen data science talks where presenters have said "We just download data from here, and blend it with data from there, then we run it through an algorithm and *jazz hands* we make a prediction". Well, okay, cool, but what happens if you don''t have any data? As a data scientist, you can''t just shrug and say "dunno mate". In this session we''ll examine the process of elicitation and we''ll use it to predict the success of this conference, live, using Python and Jupyter Notebooks.',
'Gary Short',4,7,newid())

-- Session 4 
Insert into [Sessions] values (1,'Why premature optimisation is the root of all evil','A short talk on the perils of optimising your code too early, the pains it can cause, and how you might avoid it','Donald Knuth wrote in ''The Art Of Computer Programming'' in 1968 that ''premature optimisation is the root of all evil (or at least most of it) in programming''

The same still holds true today, that whilst it seems like a good idea at the time, optimising too early can cause problem to your project long term.

This short talk shows some recognizable patterns you may have seen where premature optimisation causes problems, and how you might be able to avoid these pitfalls.',
'Craig Jones',1,9,newid())
Insert into [Sessions] values (1,'Scaling your .NET app with Azure','You''ve made it big time, and your web app just can''t handle the traffic... Where do you even start with scaling in Azure? This session will cover all there is to know about efficiently scaling an app on Azure; from scaling on App Service, to hosting in containers on AKS, and all the DevOps magic in between.','You''ve made it big time, and your web app just can''t handle the traffic... Where do you even start with scaling in Azure?
This session will cover all there is to know about efficiently scaling an app on Azure; from scaling on App Service, to hosting in containers on AKS, and all the DevOps magic in between.
Lets start by exploring the auto-scaling options available in Azure App Service, using Application Insights to guide the thresholds we set and monitor how our app performs. We''ll see the impact that external dependencies (database, storage) has on scaling, and smart ways to mitigate any challenges that arise.
As our scale grows, so will our costs... I''ll share my tips for cost effective scaling, taking a look at the options Azure makes available at our fingertips – through containerized apps + AKS, and serverless products like Azure SQL Serverless.
Finally, I''ll show how to configure a deployment pipeline in Azure DevOps that glues all of these solutions together.',
'Callum Whyte',2,9,newid())
Insert into [Sessions] values (1,'Outnumbered – Force Multipliers in Software Security','Outnumbered – Force Multipliers in Software Security','You''re dropped into a business that is growing – in people, software, and volume. You realise that Infosec and Technology have had limited engagement, you are at ground zero and your already 3 years behind. There are 120 things you could do and your outnumbered 100 to 1 by engineers– so what do you do? How to make the biggest impact? I will be talking through some of the learnings I’ve had from delivering security transformation, what do I measure and how I get the most bang (risk reduction) for a buck.',
'Sebastian Coles',3,9,newid())
Insert into [Sessions] values (1,'Building next generation web apps with Blazor','Blazor and WebAssembly are game changers. Developers can now write powerful client-side applications using C# running directly in the browser. In this session, we''ll go beyond the theory and see what it''s like to actually write Blazor applications - exploring loads of great features along the way.',
'The widespread adoption of WebAssembly, by all major browsers, has opened the world of front-end development to languages other than JavaScript. The platform leading the charge is Blazor - a new client-side UI framework from the Microsoft ASP.NET team. Blazor allows developers to write client-side applications using C# which runs inside the browser without needing plugins or transpilation - how cool is that!

In this code-focused session, we''ll explore the Blazor platform. Starting with the fundamentals, we''ll look at how to organise our applications for better maintainability. Then we''ll look at how to handle user input using forms and validation. We''ll then explore some more advanced topics such as JavaScript interop and authentication and authorisation.

This session is great for developers both new to Blazor or who have prior experience and want to deepen their knowledge.',
'Chris Sainty',4,9,newid())

-- Session 5
Insert into [Sessions] values (1,'DevOps and Microservices Better Together','You want to do DevOps and move fast using continuous delivery but your architecture is holding you back. In this talk, we will look at how a microservices architecture is essential to make DevOps and CI/CD successful.','We all want to get out of the rot of traditional SDLC, waterfall, big bang deployments, long release cycles.
We want to be faster, more flexible, providing more value upfront, WINNING, have short feedback loops, be able to work in small cross-functional teams 

To do that we want to be able to do Continuous Integration (CI) and Continuous  Deployment (CD) which leads us to Continuous Delivery. 

This methodology widely referred to today as DevOps and Continuous Delivery
 is described in the DevOps handbook...

The theme that repeats in the book is that in order to achieve this we need to "have architecture that is modular, well encapsulated, and loosely-coupled so that small teams are able to work with high degrees of autonomy, with failures being small and contained, and without causing global disruptions."

In this talk, we will look at how we can build better microservices so our DevOps will be a win',
'Sean Farmar',1,11,newid())
Insert into [Sessions] values (1,'Augmented Reality for iOS using Xamarin, ARKit, C# and .NET','In this session we will look at how easy (yet overlooked) it is for .NET developers to create augmented reality mobile applications for iOS devices using Xamarin, ARKit and C#','We will talk about augmented reality in general before looking at how to implement it.

We will look at the many features that we can make use of when we target iOS devices and Apples Augmented Reality framework ARKit including 

* Plane detection
* Image detection
* Object detection
* Facial tracking
* Facial expression detection
* Body tracking
* Touch gestures
* Physics engine
* Animations',
'Lee Englestone',2,11,newid())
Insert into [Sessions] values (1,'Let’s stop blaming our users for getting hacked when it is our problem to solve','Users cannot secure your web applications through password choice alone. You cannot blame them for this; it is not their problem to solve. It is ours, as security professionals, identity professionals, and software developers.',
'Users cannot secure your web applications through password choice alone. You cannot blame them for this; it is not their problem to solve. It is ours, as security professionals, identity professionals, and software developers.
Typical 2FA implementations such as TOTP and push notification have had some success, but they can be frustrating to use and are still vulnerable to basic phishing techniques. OWASP and NIST are now recommending FIDO2, which offers a realistic solution in the form of frictionless, possession-based authentication that has inbuilt anti-phishing techniques. But what does FIDO2 look like to a developer and how does it actually work?
In this talk, I’m going to look at: why common 2FA mechanisms aren’t up to scratch; how to phish your friends using Evilginx; spooky biometrics; and how to use WebAuthn and FIDO2 to protect your users.',
'Scott Brady',3,11,newid())
Insert into [Sessions] values (1,'Mental Health: It''s Time to Talk (the post pandemic revision)','Mental health affects us all, and this has become more widespreadly accepted, in part, due to the Covid-19 pandemic.

So what changed in that time, and what did we learn (or in some cases re-learn) since the outbreak of the Covid-19 pandemic.','Mental health affects us all, albeit at varying levels of intensity, be it from having a restless nights sleep or Bi-Polar Disorder and is still a subject that we tend to approach with caution, if we even speak about it at all, whether with our colleagues and managers, doctors and even our closest friends and family.

Starting talking about our mental health is often hard, but it is one of the most powerful tools in your arsenal to managing your own and your team''s mental health and should be discussed in all 1:1s.

Come and gain an insight into some of the things to look out for as preliminary signs that your colleagues, friends, family and perhaps, most importantly, yourself may be suffering, plus how to broach this all-important conversation.

This also includes additional content based on learnings since the outbreak of the Covid-19 Pandemic',
'Ryan Yates',4,11,newid())

