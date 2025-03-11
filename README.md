### <font color="blue">Pet Care Organizer</font>
#### Overview

Pet Care Organizer is a comprehensive web application designed to help pet owners manage their pets' daily routines and needs efficiently. With multi-user support, task assignment, and tracking features, it's the perfect tool for families or households with shared pet care responsibilities.

#### Team Members

- Maddie Livingston
- Donovan Kilpela
- Robert Green
- Tristen Hibbert

### Features

- **<font color="green">Dashboard</font>**: Log daily tasks such as feeding, potty breaks, and grooming
- **<font color="green">Appointment Tracker</font>**: Keep track of veterinary appointments
- **<font color="green">Supply Management</font>**: Monitor and manage pet supply levels
- **<font color="green">Multi-user Support</font>**: Collaborate on pet care with family members
- **<font color="green">Task Assignment</font>**: Assign tasks to specific users
- **<font color="green">Completion Tracking</font>**: Monitor who completed each task
- **<font color="green">Reminders</font>**: Receive alerts for low supplies and upcoming appointments

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

- **<font color="blue">User Authentication</font>**: Secure login page
- **<font color="blue">Session State</font>**: Track daily task progress and user preferences
- **<font color="blue">Input Validation</font>**: Ensure data integrity (e.g., food quantity must be a number)
- **<font color="blue">Dependency Injection</font>**: For easier testing and maintenance
- **<font color="blue">Web API</font>**: Enable mobile access for logging tasks, assigning tasks, and updating supplies

