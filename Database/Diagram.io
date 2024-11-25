Table Departments {
  ID int [primary key]
  Name varchar [note: "Maximum length: 100"]
}

Table Specializations {
  ID int [primary key]
  Name varchar [note: "Maximum length: 100"]
}

Table Rooms {
  ID int [primary key, note: "Room ID"]
  Name varchar [note: "Maximum length: 100"]
  RoomType varchar [note: "Type of room (e.g., ICU, General, etc.)"]
  FloorNumber int [note: "Floor where the room is located"]
  BedCapacity int [note: "Total number of beds in the room"]
  AvailableBeds int [note: "Number of beds currently available"]
  EquipmentList text [note: "Comma-separated list of equipment in the room"]
  SpecialFeatures text [note: "Any special features of the room (e.g., isolation, wheelchair-accessible)"]
  DepartmentID int
}

Table Doctors {
  ID int [primary key]
  FirstName varchar [note: "Maximum length: 50"]
  LastName varchar [note: "Maximum length: 50"]
  PhoneNumber varchar [note: "Maximum length: 20"]
  Address varchar [note: "Maximum length: 255, nullable"]
  Gender char [note: "Must be 'F' or 'M'"]
  SpecializationID int
  DepartmentID int
  Status varchar [default: 'Available', note: "Maximum length: 20"]
}

Table Patients {
  ID int [primary key]
  FirstName varchar [note: "Maximum length: 50"]
  LastName varchar [note: "Maximum length: 50"]
  Gender char [note: "Must be 'F' or 'M'"]
  BloodType varchar [note: "Maximum length: 10, nullable"]
  DateOfBirth date
  PhoneNumber varchar [note: "Maximum length: 20"]
  Address varchar [note: "Maximum length: 255, nullable"]
  DoctorID int
  RoomID int
  Diagnosis text
}

Table Users {
  ID int [primary key, note: "Auto-incremented"]
  Username varchar [note: "Maximum length: 50, nullable"]
  Password varchar [note: "Maximum length: 50, nullable"]
}

Ref: Rooms.DepartmentID > Departments.ID
Ref: Doctors.SpecializationID > Specializations.ID
Ref: Doctors.DepartmentID > Departments.ID
Ref: Patients.DoctorID > Doctors.ID
Ref: Patients.RoomID > Rooms.ID

https://dbdiagram.io/d/6744e4a8e9daa85acaacca9d
