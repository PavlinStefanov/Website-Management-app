# Website-Management-app

 build solution
 start ValuesController just to fire up local IISExpress

 Software requirements
 - Visual Studio 2019 16.5 
 Userd framework and libraries
 - .NET Core 3
 - Entity Framework 2
 - NLog

 Used layered Clean Architecure for .NET Core
 - Core Layer - benefits and key points
   - Domain 
     - entities
     - value objects
     - logic related to the domain entities
     - exceptions

   - Application 
     - interfaces and abstractions
     - view models and DTO-s 
     - business logic and types
     - command/query patterns
       - simplicity
       - performance
       - scalability
       - ability to attach behavior before or efter each request(logging, validation, caching, authorisation)
     - exceptions

 - Infrastructure Layer - benefits and key points
    - persistence concerns
    - identity concerns
    - api clients
    - comunications wthi any external system
    - indipendent of the database
    - fluent api configuration over data anotations
    - conventions over configurations
    - automacaly apply all enity type configurations
    - no layers depend on infrastructure

  - Presentation Layer - benefits and key points
   - any SPA(Angular, React.js, Vue.js)
   - web api
   - controllers should not contain any app logic
   - create and define well defined view models
 
 
 Optimisations
 - add conteroller restrictions based on the user roles
   - use AspNet.Identity provider and create user token in base of the rules
 - change cqrs library with MediatR. (I user it in the past. To many bugs and issues)
 - create middle layer pipeline in application layer for any external/internal concern. Inject them in cqrs library(logging, validation, caching, authorisation) 
