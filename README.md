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
  - Common Properties:
    - Basic personal information (ID, name, contact details)
    - Address and gender information
  - Doctor-specific Features:
    - Specialization management
    - Department assignment
    - Status tracking
  - Patient-specific Features:
    - Medical information (blood type, diagnosis)
    - Doctor assignments
    - Room management
  - Core Operations:
    - CRUD operations for doctors and patients
    - Authentication and user management
    - Department and specialization lookups
    - Real-time data retrieval

Serves as the contract layer between client and server, ensuring type safety and operation consistency across the distributed system.

### 2️⃣ Server Layer (Server_Hosp)
Core business logic implementation:
- `Doctor.cs`: Doctor management operations (CRUD, department/specialization handling, status management)
- `Patient.cs`: Patient management operations (CRUD, room assignments, medical records)
- `LoginService.cs`: Authentication services (user validation, session handling)
- `RegisterService.cs`: User registration with duplicate checking
- `ServerManager.cs`: Server configuration, TCP channel setup, connection management, and error handling
- `Program.cs`: Server initialization and service registration

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

### Prerequisites
- SQL Server 2019 or later
- Visual Studio 2019+ with .NET Framework 4.5+
- Windows OS (for .NET Remoting)

### Database Setup
1. Create a new SQL Server database
2. Execute the SQL scripts from the `Database` folder in order:
   - `01_CreateTables.sql` - Creates the database schema (tables and relationships)
   - `02_InitialData.sql` - Populates initial data (departments, specializations, rooms, admin user)

3. Update connection string in `ServerManager.cs`:
   ```csharp
   private const string YOUR_DB = @"Data Source=YOUR_SERVER\SQLEXPRESS;Initial Catalog=YOUR_DATABASE;Integrated Security=True;Connect Timeout=30;";
   ```

4. Set your connection string as active:
   ```csharp
   public static readonly string ConnectionString = YOUR_DB;
   ```

> 📝 **Note**: SQL scripts can be found in the `Database` folder of the repository.

## 📊 Database Schema

The system uses a relational database with the following structure:

[![Database Schema](https://dbdiagram.io/d/6744e4a8e9daa85acaacca9d)](https://dbdiagram.io/d/6744e4a8e9daa85acaacca9d)

### Key Tables:
- **Departments**: Manages hospital departments
- **Specializations**: Tracks medical specializations
- **Rooms**: Handles room management with capacity and equipment tracking
- **Doctors**: Stores doctor information and their assignments
- **Patients**: Maintains patient records and medical information
- **Users**: Manages system authentication

### Key Relationships:
- Doctors are assigned to Departments and Specializations
- Patients are linked to their assigned Doctors and Rooms
- Rooms are associated with specific Departments

### Database Features:
- Comprehensive tracking of room capacity and equipment
- Full patient medical history support
- Doctor status and assignment management
- Integrated user authentication system

### Server Configuration
1. Open the solution in Visual Studio
2. Set `Server_Hosp` as the startup project
3. Build and run the server
4. Verify the console shows: "Server is running on port 2222!"

### Client Setup
1. Ensure the server is running
2. Set `Client_Hosp` as the startup project
3. Build and run the client
4. Use the login form to access the system
   - Default credentials:
     - Username: admin
     - Password: admin

### Troubleshooting
- If connection fails, verify:
  - SQL Server is running
  - Connection string is correct
  - Server application is running
  - Port 2222 is not blocked by firewall

### Development Setup
1. Clone the repository
   ```bash
   [git clone https://github.com/yourusername/HMS.git](https://github.com/Weeksly1312/Hospital-Management.git)
   ```
2. Open `Client_Hosp.sln` in Visual Studio
3. Restore NuGet packages
4. Build the entire solution

This project was created by:
- **Soufiane EL HALLAOUI**
- **Mohammed KOUCHAR**
