USE StudentManagementDB;
GO

-- ==========================================
-- STUDENTS
-- ==========================================

SELECT *
FROM Students;
-- Count students
SELECT COUNT(*) AS TotalStudents
FROM Students;
-- ==========================================
-- TEACHERS
-- ==========================================

SELECT *
FROM Teachers;

-- Count teachers
SELECT COUNT(*) AS TotalTeachers
FROM Teachers;
--Verify with code=AB2345
SELECT *
FROM Teachers
WHERE TeacherCode = 'AB2345';


-- ==========================================
-- COURSES
-- ==========================================

SELECT *
FROM Courses;

-- Count courses
SELECT COUNT(*) AS TotalCourses
FROM Courses;
--verify with id=1
SELECT *
FROM Courses
WHERE Id = 1;