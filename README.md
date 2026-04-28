# API 02 - JWT and Entity Framework

This project is a REST API built with .NET 9, implementing authentication using JWT and data persistence using Entity Framework Core.

The system manages a relationship between users and their appointments (1:N), where a single user can have multiple appointments.

---

## 🚀 Features

- User registration and authentication
- JWT-based authentication and authorization
- CRUD operations for users
- CRUD operations for appointments (compromissos)
- One-to-many relationship (User → Appointments)
- Secure endpoints using JWT tokens

---

## 🛠️ Technologies used

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- JWT (JSON Web Token)
- SQL Server
- C#

---

## 🗄️ Data model

### User (Usuario)

- Id
- Name
- Email
- Password

### Appointment (Compromisso)

- Id
- Title
- Description
- Date
- UserId (FK)

---

## 🔗 Relationship

- One User can have multiple Appointments (1:N)

---

## 🔐 Authentication

The API uses JWT authentication:
- User logs in with credentials
- A JWT token is generated
- Token is required to access protected routes

---

## 📌 Notes

This project was developed for study purposes, focusing on:
- Authentication and authorization with JWT
- ORM usage with Entity Framework Core
- REST API design principles
- Relational database modeling
```