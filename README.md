# Todo List Web-Application

## Table of Contents
<ol>
<li>Project Overview</li>
<br/>
<li>Solution Summary</li>
<br/>
<ul>
  <li>2.1 Scope</li>
  <li>2.2 Assumptions</li>
  <li>2.3 Dependencies</li>
  <li>2.4 Risks</li>
</ul>
<br/>
<li>Schematic Diagram</li>
<br/>
<li>System Design</li>
<br/>
<ul>
<li>4.1 Proposed Design</li>
<li>4.2 Component Inventory</li>
</ul>
<br/>
<li>Database Design</li>
<br/>
<ul>
<li>5.1 Data Model</li>
<li>5.2 Tables Structure</li>
</ul>
<br/>
<li>App Implementation</li>
<br/>
<li>Drawbacks and Future Scope</li>
</ol>

### 1. Project Overview
The Todo List Web-Application is a C# project designed to streamline and manage the day-to-day tasks of people. This project aims to provide end users various functionalities, allowing them to access and manage their tasks effectively which would increase their overall productivity.

This Web-Application will allow users to login using their usernames and passwords. To make the App more secure, user authentication could be added. Every user will have their own Todo Lists, be it for work, home, gym, etc. Each list would comprise of various tasks, and each task would have multiple activities which would need to be completed by the user.

Using this Web-App, users will be able to perform basic CRUD operations. They will be able to add, update, delete, organize their tasks in different categories and prioritize them based on level of importance. This App will also allow use of images in place of plain text for different tasks. Pagination has been implemented to display few data at a time to avoid cluttering UI.

By implementing the Todo List Web-Application, the project aims to enhance the productivity and efficiency of people completing their day-to-day tasks. It eliminates the need of manual paper-based record keeping and provides a user-friendly interface. With features like task creation, scheduling and prioritization, this project offers a comprehensive solution for maintaining an organized and effective task management environment.

### 2. Solution Summary

#### 2.1 Scope
The scope of Todo List Web-Application encompasses the development of a comprehensive application using C# on .NET Framework. The project aims to assist people in effectively managing their day-to-day tasks. The application will provide a range of features and functionalities to enhance user experience.

The project scope includes the following aspects:

#### 1. Admin Controls
* View and Delete users as per need
* Search users based on their usernames
* See upto 5 user details per page with the help of paged lists

#### 2. User Registration
* Create a new Account having a unique username
* Form Validations in place to verify user details
* Only 1 admin is available for the application

#### 3. Task Management
* Create Todo Lists for different requirements
* Manage Tasks and track progress completion
* Create various activities as a checklist

#### 4. Database Management
* Establish and maintain a robust backend database
* Entity Framework used for Code-Based migrations
* Ensure data consistency, integrity and security

#### 5. Frontend Application Development
* User-Friendly and interactive interface for people to interact with the app
* Design intuitive views and forms for users
* Implement functionalities such as search, sort for better accessibility

#### 2.2 Assumptions
* The Application assumes that only 1 admin exists to manage the users and that the admin creates the first account on the application to prevent any user from registering themselves as an admin
* Admin can only view and delete users from the system but cannot edit their details
* The application runs smoothly in a production environment and is able to handle high loads and scale as per requirement
* All the details of a user i.e. their to-do lists, tasks and checklists are deleted if they delete their account or are removed by the admin
* If an admin deletes their account, then the next person registering must be a replacement for admin to prevent regular users registering themselves as admin
  
#### 2.3 Dependencies

1. **Database Management System**: The system relies on a robust and reliable database management system (DBMS) to store and manage data related to users, lists, tasks and activities. Microsoft SQL Server is chosen as the ideal DBMS and is created using Entity Framework’s Code-Based Migrations.

2. **Database Connectivity**: The project relies on a database connectivity layer to establish a connection with the database management system. In ASP.NET, this is typically achieved using ADO.NET or an ORM (Object-Relational Mapping) framework such as Entity Framework.

3. **Backend Framework**: The development of the Todo List Web-App requires a suitable backend framework like ASP.NET or ASP.NET Core using C# programming language. The framework provides the necessary tools and libraries to handle data processing, business logic, and integration with the database.

4. **Frontend Technologies**: The frontend of the system relies on web technologies like HTML, CSS, and JavaScript, Bootstrap, jQuery, etc. to create a user-friendly interface. All the UI views are written and rendered using the powerful ASP.NET MVC Razor syntax to facilitate interaction with the back-end.

5. **Development Tools and IDE**: The development of Todo List Web-Application relies on tools and integrated development environments (IDEs) like Visual Studio, Visual Studio Code, or JetBrains Rider, which provide necessary features for coding, debugging, and project management. Visual Studio was selected as the ideal choice.
  
6. **Testing Frameworks**: Dependencies on testing frameworks, such as NUnit or xUnit for unit testing and Selenium for automated UI testing, ensure the reliability and quality of the system through comprehensive testing.

#### 2.4 Risks

1. **Data Security Risks**: As the system involves the storage and management of sensitive information of member details, there is risk of data breaches, unauthorized access, or data loss. Proper security measures, such as encryption, secure authentication, and regular backups, should be implemented to mitigate these risks.

2. **Technical Challenges**: Developing a comprehensive task management system requires handling complex functionalities, integrating various components and ensuring smooth communication between the front-end and back-end. Technical challenges may arise during development, such as compatibility issues, performance bottlenecks, or software bugs. Proper testing and continuous monitoring should be carried out to identify and resolve these challenges.

3. **User Acceptance and Adoption**: The success of Todo List Web-Application depends on its adoption and acceptance by end-users. There may be resistance to change or a learning curve for users transitioning from manual or legacy systems. Adequate training, user feedback, and user interface design considerations should be incorporated to address these challenges and ensure smooth user adoption.

4. **Requirement Changes and Scope Creep**: Throughout the project lifecycle, there is a possibility of evolving requirements, changes in client expectations, or scope creep. These changes can impact project timelines, budgets, and overall project success. Effective communication, proper requirement analysis, and change management processes should be in place to handle and accommodate these changes without compromising the project's objectives.

5. **Integration and External Dependencies**: The Todo List Web-Application might require integration with external systems or APIs for functionalities such as Image search, premium services or authentication services. Any issues with these integrations, changes in third-party APIs, or service disruptions can pose risks to the project's functionality and timelines. Thorough testing, monitoring, and proactive communication with external providers are essential to mitigate these risks.

6. **Scalability and Performance**: As the System grows and handles a larger volume of data and users, scalability and performance can become critical factors. Inefficient database queries, inadequate server resources, or architectural limitations can impact the system's performance and responsiveness. Regular performance testing, capacity planning, and optimization efforts should be undertaken to ensure the system can handle increasing demands.

7. **Project Management Risks**: Effective project management is crucial for the successful delivery of the Online Library Management System. Risks such as project delays, budget overruns, resource constraints, or miscommunication between project stakeholders can impact the project's outcome. Adequate project planning, risk assessment, regular monitoring, and proactive communication can help mitigate these risks.

### 3. Schematic Diagram

A schematic, or schematic diagram, is a representation of the elements of a system using abstract, graphic symbols rather than realistic pictures. It gives an overview of overall system.

<p align="center">
  <img width="510" alt="image" src="https://github.com/user-attachments/assets/71e30253-383f-49b8-9df6-73513d271e2a">
</p>

### 4. System Design

#### 4.1 Proposed Design

Todo List Web-Application is a multi-user system. Hence for each user registration and login is required at the start of application. Model classes are used to store the type of data and relationship between them. Users will see different views rendered by the controller after model binding takes place. The different views that user can interact within the system are:

* Home Page containing information about the application
* New User Registration
* User/Admin Login
* View, Update or delete account information
* Create Lists containing various tasks and activities
* Manage tasks and activities effectively using checklist and prioritize them
* Addition of Images as Tasks is possible
* Track % completion of tasks and activities

To control the flow of the system, different controllers will be present for each of the model classes. They are:

* Home controller
* User controller/Admin Controller
* TodoList controller
* Task controller
* TaskActivities controller

#### 4.2 Component Inventory

The Todo List Web-Application using ASP.NET MVC architecture.

* For view that is top layer (user interface, web)
* For control flow that is middle layer (domain models)
* For business implementation that is bottom layer (persistence)
* Connection to the database is done using Code First approach

### 5. Database Design

#### 5.1 Data Model

<p align="center">
  <img width="503" alt="image" src="https://github.com/user-attachments/assets/8a985aa0-ef51-4e66-93b4-6e56631f25ea">
</p>

#### 5.2 Tables Structure

<p align="center">
  <img width="503" alt="image" src="https://github.com/user-attachments/assets/5a5a8030-4209-4b80-86b6-12c41c6837b2">
</p>

<p align="center">
  <img width="503" alt="image" src="https://github.com/user-attachments/assets/a4787d93-e2c4-48b5-88a1-54b6bf7620db">
</p>

### 6. App Implementation

![Screenshot (1)](https://github.com/user-attachments/assets/92bde8ef-b08c-416a-a4e1-8073761b1cbd)
![Screenshot (2)](https://github.com/user-attachments/assets/cbf24b6e-8575-480f-bb14-57bcac4f9ad0)
![Screenshot (3)](https://github.com/user-attachments/assets/0fe03e37-d688-4878-8b7b-b85e4d2f13c3)
![Screenshot (4)](https://github.com/user-attachments/assets/007fa65b-b37a-4aca-9910-050f793d3109)
![Screenshot (5)](https://github.com/user-attachments/assets/821ce4f8-7dfe-427a-8e6c-23d3ce4d9163)
![Screenshot (6)](https://github.com/user-attachments/assets/2a7f0f7f-7c56-4dcf-b574-5c0569a6a5e9)
![Screenshot (7)](https://github.com/user-attachments/assets/6980fec4-5ac1-4882-bd7a-15660e272ba1)
![Screenshot (8)](https://github.com/user-attachments/assets/767be3d2-fe03-448b-b74b-93f26d4a96ca)
![Screenshot (9)](https://github.com/user-attachments/assets/07172cc7-2531-4a35-a17a-4f6a127ddaa6)
![Screenshot (10)](https://github.com/user-attachments/assets/0333abdf-7009-4921-92dc-4f5ff22e7747)
![Screenshot (11)](https://github.com/user-attachments/assets/254e5a90-4cb7-405d-8a2a-199232f92a45)
![Screenshot (12)](https://github.com/user-attachments/assets/4c724de7-c802-4d39-b684-b5f3c90d737a)
![Screenshot (13)](https://github.com/user-attachments/assets/1b34d5c5-9784-4b25-b047-bbf4c9448ef9)
![Screenshot (14)](https://github.com/user-attachments/assets/b122a755-e023-4360-bcff-19fd08dbcf5b)
![Screenshot (15)](https://github.com/user-attachments/assets/1eab1d80-94d3-4c2d-8190-de6021e685b0)
![Screenshot (16)](https://github.com/user-attachments/assets/c925ca64-94e8-4644-ad28-2ead79a0b3d8)
![Screenshot (17)](https://github.com/user-attachments/assets/ccadfaf2-77ea-4881-a459-2c1e7d9109a4)
![Screenshot (18)](https://github.com/user-attachments/assets/22c3fc24-3fc1-4bd7-8db4-c429f56b8ab7)
![Screenshot (19)](https://github.com/user-attachments/assets/8bb9f53d-ad74-4f19-bf34-21b04180652e)
![Screenshot (20)](https://github.com/user-attachments/assets/b4f3a020-6f49-44dc-8200-a7c448f264f7)
![Screenshot (21)](https://github.com/user-attachments/assets/76946e42-b2dd-4ff1-a10f-47b5a113361d)
![Screenshot (22)](https://github.com/user-attachments/assets/1fecf6bf-a1a3-4010-99a7-a945c6a0054e)

### 7. Drabacks and Future Scope

* There is only 1 Admin to monitor the application. In future, additional admins can be created to better handle the users.
* Scheduling can be implemented based on which mails can be triggered to end-users. This will notify them regarding the status of their tasks/activities.
* Functionality to reset passwords can be implemented. Currently, if the user forgets their password, it has to be looked up in DB.
* UI can be improved significantly to achieve simultaneous tasks in a single page through AJAX calls. Bootstrap's card layout can be utilized to make the Todo Lists look more compact.
* The application can be run in local currently, since it has not been deployed on a server.






