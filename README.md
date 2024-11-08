# SmartWorkout Project

This project, SmartWorkout, is a .NET-based application designed to manage and monitor workouts, exercises, and user information. The app is structured to facilitate user authentication, logging workout sessions, and storing exercise details in a structured, organized way.


The project contains multiple components for managing users, workouts, exercises, and authentication. Key areas include the following:

## Authentication and Authorization: 
Custom authentication state provider, middleware handling, and authorization service.
## Entity Models: 
Classes representing the core entities such as User, Workout, Exercises, etc.
## Database Context: 
Data handling for storing and retrieving information about users and workout activities.
 # File Descriptions

## 1. Authentication and Authorization
AuthService.cs & IAuthService.cs:
AuthService.cs provides methods for handling user authentication logic, while IAuthService.cs defines the interface for authentication service functionalities, such as logging in and managing user sessions.
CustomAuthStateProvider.cs:
A custom authentication state provider for Blazor, responsible for managing the current authentication state of the user and integrating with Blazor's authorization requirements.
BlazorAuthorizationMiddlewareResultHandler.cs:
Middleware for handling authorization results in Blazor, ensuring the correct access permissions for users based on their authentication state.
## 2. Entity Models
User.cs:
Represents a user entity in the application, holding essential details about each user (e.g., ID, name, gender, workout history).
Workout.cs:
Defines the structure of a workout session, storing details about the session and allowing linkage with user accounts and exercise logs.
Exercises.cs:
Represents the exercise entity, containing information about each available exercise, including name, description, and target muscle groups.
ExerciseLog.cs:
This entity logs individual exercises completed during a workout session, tracking the exercises a user performed within each workout.
Gender.cs:
An enumerator that defines gender options for users, providing a controlled vocabulary for user gender.
## 3. Database Context
SmartWorkoutContext.cs:
This file serves as the Entity Framework Core database context, managing the database connection and data operations for the entities (User, Workout, Exercise, etc.) used in the application.
## 4. Mapping Utilities
ExerciseMapper.cs & UserMapper.cs:
Utility files for mapping data between the entities and the database or other data layers, ensuring a consistent data format throughout the application.
## 5. Project Configuration
Program.cs:
The main entry point for the application. It initializes the web host, configures services (including authentication and authorization), and starts the application.
Netrom.csproj:
The project file for the .NET application, specifying dependencies, target frameworks, and project metadata.
launchSettings.json:
Configuration file for the launch settings, defining profiles for running the application in different environments (HTTP, HTTPS, and IIS Express), setting URLs, and environment variables.
