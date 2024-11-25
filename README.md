# 🏥 HMS - Distributed Hospital Management System

> A powerful distributed healthcare solution built with .NET Remoting and C#

[![.NET](https://img.shields.io/badge/.NET%20Framework-4.5+-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

## 🌟 Project Overview

HMS is a distributed hospital management system that leverages .NET Remoting for seamless communication between client and server components. Built with a focus on reliability and performance, it offers comprehensive tools for managing healthcare facilities.

## 🏗️ Architecture

The system is built on a robust three-tier architecture:

### 1️⃣ Middle Layer (Middle_Hosp)
- `RPC.cs`: Core interface defining all remote procedures
- Handles communication contracts between client and server
- Defines shared data structures and operations

### 2️⃣ Server Layer (Server_Hosp)
Core business logic implementation:
- `Doctor.cs`: Doctor management operations
- `Patient.cs`: Patient data handling
- `LoginService.cs`: Authentication services
- `RegisterService.cs`: User registration
- `ServerManager.cs`: Server configuration and management
- `Program.cs`: Server initialization

### 3️⃣ Client Layer (Client_Hosp)
Modern Windows Forms interfaces:
- `LoginForm.cs` & `RegisterForm.cs`: User authentication
- `MainForm.cs`: Application container
- `Dashboard.cs`: System overview
- `AddDoctor.cs`: Doctor management
- `AddPatient.cs`: Patient management
- `AddRoom.cs`: Room allocation
- `ConnectionManager.cs`: Network handling
- `Program.cs`: Client initialization

## ✨ Key Features

### 👤 User Management
- Secure authentication system
- New user registration
- Session management
- Connection state handling

### 👨‍⚕️ Doctor Management
- Complete doctor profiles including:
  - Personal details (ID, name, phone, address)
  - Professional information (specialization, department)
  - Gender specification
- Status tracking with options:
  - Available
  - In Consultation
  - On Break
  - Off Duty
  - In Surgery
  - Emergency
- Real-time list view updates
- CRUD operations with validation
- Department assignment
- Specialization tracking
- Real-time availability updates

### 🏃 Patient Care
- Comprehensive patient records:
  - Personal information
  - Blood type tracking
  - Medical history
  - Doctor assignments
  - Room allocation
  - Diagnosis management
- Real-time updates
- Patient-doctor matching
- Room management

### 📊 Dashboard Features
- Total doctor count display
- Total Patient count display
- Real-time data updates

## 🚀 Getting Started

### Database Setup
1. Configure SQL Server
2. Update connection string in `ServerManager.cs`:
