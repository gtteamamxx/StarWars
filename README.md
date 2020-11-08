# About

This project is all about Star Wars.

It's simple CRUD application connected to MS SQL Database which allows to store and maintain
Star Wars characaters, character friends and also episodes.

# Details
Application have 3 layers.

API <> BLL <> DAL

BLL contains logic for API controllers requests like Create/Update/Delete etc aggregated into services. Each service delegates responsibility to another service depends on request.

Validation takes place before object manipulation so we can only operate on valid objects. Object manipulation is also moved into separated classes.

All request are transation-scoped. Transaction is moved to highest layer. You can see `IDatabaseContext` injected into controller and used just after service execution. 

# Getting started

To run application simple type:

`dotnet run --project "StarWars.API"`

to run tests:

`dotnet test`

# Specification

.NET Core 3.1, 
Swagger,
MS SQL, 
NUnit, 
Coverlet, 
ReportGenerator, 
Moq, 
FluentAssertions,
FluentValidation, 
Entity Framework Core, 
AutoMapper

# Design patterns

Factory, Strategy, Singleton, Dependency injection, Orchestrator, Builder, SOLID, DRY, YAGNI.

# Tests

Project have only sample Unit and Integration tests.
