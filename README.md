### Pet Care Organizer
#### Overview

Pet Care Organizer is a comprehensive web application designed to help pet owners manage their pets' daily routines and needs efficiently. With multi-user support, task assignment, and tracking features, it's the perfect tool for families or households with shared pet care responsibilities.

#### Team Members

- Maddie Livingston
- Donovan Kilpela
- Robert Green
- Tristen Hibbert

### Features

- **Dashboard**: Log daily tasks such as feeding, potty breaks, and grooming
- **Appointment Tracker**: Keep track of veterinary appointments
- **Supply Management**: Monitor and manage pet supply levels
- **Multi-user Support**: Collaborate on pet care with family members
- **Task Assignment**: Assign tasks to specific users
- **Completion Tracking**: Monitor who completed each task
- **Reminders**: Receive alerts for low supplies and upcoming appointments

### Technology Stack

- ASP.NET Core MVC
- Razor Views with Tag Helpers
- Entity Framework Core
- SQL Server
- Web API for mobile integration

### Project Structure

- Multi-page web application with a navigation menu
- Separate sections for Daily Tasks, Appointments, and Supplies
- CRUD functionality connected to a backend database
- Structured controllers with business logic in separate service classes
- Unit tests for business logic in service classes

### Key Components

- **User Authentication**: Secure login page
- **Session State**: Track daily task progress and user preferences
- **Input Validation**: Ensure data integrity (e.g., food quantity must be a number)
- **Dependency Injection**: For easier testing and maintenance
- **Web API**: Enable mobile access for logging tasks, assigning tasks, and updating supplies
