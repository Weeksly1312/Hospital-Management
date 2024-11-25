-- Create Departments table
CREATE TABLE [dbo].[Departments] (
    [ID]   INT           NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Create Specializations table
CREATE TABLE [dbo].[Specializations] (
    [ID]   INT           NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Create Rooms table
CREATE TABLE [dbo].[Rooms] (
    [id]   INT           NOT NULL,
    [name] VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

-- Create Doctors table
CREATE TABLE [dbo].[Doctors] (
    [id]                INT           NOT NULL,
    [first_name]        VARCHAR (50)  NOT NULL,
    [last_name]         VARCHAR (50)  NOT NULL,
    [phone_number]      VARCHAR (20)  NOT NULL,
    [address]           VARCHAR (255) NULL,
    [gender]            CHAR (1)      NOT NULL,
    [specialization_id] INT           NOT NULL,
    [department_id]     INT           NOT NULL,
    [status]            VARCHAR (20)  DEFAULT ('Available') NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([specialization_id]) REFERENCES [dbo].[Specializations] ([ID]),
    FOREIGN KEY ([department_id]) REFERENCES [dbo].[Departments] ([ID]),
    CHECK ([gender]='F' OR [gender]='M')
);

-- Create Patients table
CREATE TABLE [dbo].[Patients] (
    [id]            INT           NOT NULL,
    [first_name]    VARCHAR (50)  NOT NULL,
    [last_name]     VARCHAR (50)  NOT NULL,
    [gender]        CHAR (1)      NOT NULL,
    [blood_type]    VARCHAR (10)  NULL,
    [date_of_birth] DATE          NOT NULL,
    [phone_number]  VARCHAR (20)  NOT NULL,
    [address]       VARCHAR (255) NULL,
    [doctor_id]     INT           NOT NULL,
    [room_id]       INT           NOT NULL,
    [diagnosis]     TEXT          NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([doctor_id]) REFERENCES [dbo].[Doctors] ([id]),
    FOREIGN KEY ([room_id]) REFERENCES [dbo].[Rooms] ([id]),
    CHECK ([gender]='F' OR [gender]='M')
);

-- Create Users table
CREATE TABLE [dbo].[users] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR (50) NULL,
    [password] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
); 