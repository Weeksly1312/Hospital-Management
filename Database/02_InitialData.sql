-- Insert default admin user
INSERT INTO [dbo].[users] (username, password) VALUES ('admin', 'admin');

-- Insert sample departments
INSERT INTO [dbo].[Departments] (ID, Name) VALUES 
(1, 'Cardiology'),
(2, 'Neurology'),
(3, 'Pediatrics'),
(4, 'Emergency');

-- Insert sample specializations
INSERT INTO [dbo].[Specializations] (ID, Name) VALUES 
(1, 'Cardiologist'),
(2, 'Neurologist'),
(3, 'Pediatrician'),
(4, 'Emergency Physician');

-- Insert sample rooms
INSERT INTO [dbo].[Rooms] (id, name) VALUES 
(1, 'Room 101'),
(2, 'Room 102'),
(3, 'ICU 1'),
(4, 'Emergency 1'); 