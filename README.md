# School Management Console App

Welcome to the School Management Console App, a comprehensive C# application designed to streamline various administrative and academic processes in educational institutions. This application offers a user-friendly interface for managing courses, students, teachers, and more.

## Key Features

- **User Authentication:** Robust login/logout system for different user roles (students, teachers, administrators).
- **Course Management:** Create, update, and view courses along with detailed information.
- **Student Enrollment:** Manage student enrollments in courses.
- **Teacher Assignment:** Assign teachers to courses and manage their schedules.
- **Administrator Panel:** Specialized controls for administrators for user and system management.
- **Academic Calendar:** Keep track of academic events, exams, and deadlines.
- **Module Management:** Organize courses into modules for better academic structuring.

## Classes and Their Relationships:
Person

Base class for Student, Teacher, and Administrator.
Attributes: Name, ID, etc.
Methods: Common methods relevant to all people in the system.
Student (inherits from Person)

Attributes: Student-specific properties (e.g., courses enrolled).
Methods: Enroll in course, view grades, etc.
Teacher (inherits from Person)

Attributes: Teacher-specific properties (e.g., courses teaching).
Methods: Assign grades, manage courses, etc.
Administrator (inherits from Person)

Attributes: Admin-specific properties.
Methods: Manage users, system settings, etc.
Course

Attributes: Course details like name, code, credits.
Relationships: Associated with Teacher and Student.
Module

Attributes: Module details.
Relationships: Contains multiple Courses.
User

For login/logout functionality.
Relationships: Associated with Person.
Program

Main entry point of the application.
Interacts with all other classes.

## Getting Started

These instructions will help you set up the project on your local machine for development and testing purposes.

### Prerequisites

- Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/wisescream/CSHARP-Project.git
2. Navigate to the project directory:
cd CSHARP-Project
3. Setup the environment :
   '''pw or cmdp
   dotnet build
   Install-Package Newtonsoft.Json
   Then adjust what should be adjusted
5. Build and run the application:
dotnet run
### Usage
After launching the app, follow the on-screen instructions to navigate through the application. Each user role will have access to different features based on their permissions.
### Acknowledgments
Big Thanks To Mr Mehdi who taught us C# and was always with us when needed.
