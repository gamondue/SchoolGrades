!! da verificare, usare le query della riduzione database ad una sola classe !!
DELETE FROM Classes 
WHERE idClass <>9; 

DELETE FROM Classes_Students
WHERE idClass <>9; 

DELETE FROM Classes_StartLinks 
WHERE idClass <>9;

DELETE FROM Lessons 
WHERE idClass <>9;

DELETE FROM Students
WHERE idStudent NOT IN (
SELECT idStudent FROM Classes_Students)

DELETE FROM Grades
WHERE idStudent NOT IN (
SELECT idStudent FROM Classes_Students)

DELETE FROM StudentsPhotos_Students
WHERE idStudent NOT IN (
SELECT idStudent FROM Classes_Students)

DELETE FROM StudentsPhotos
WHERE idStudentsPhoto NOT IN(
SELECT idStudentsPhoto FROM StudentsPhotos_Students);

DELETE FROM Lessons_Images 
WHERE Lessons_Images.idLesson NOT IN
(
SELECT idLesson from Lessons
); 

DELETE FROM Lessons_Topics 
WHERE idLesson NOT IN
(
SELECT idLesson from Lessons
); 



1804911292631938466

DELETE FROM Students; 

DELETE FROM Lessons_Topics 
WHERE Lessons_Topics.idLesson NOT IN
(
SELECT idLesson from Lessons
WHERE Lessons.idClass = 9
); 


DELETE FROM Lessons
WHERE Lessons.idClass <> 9; 

DELETE FROM Images 
WHERE Images.idImage NOT IN
(
SELECT idImage FROM Lessons_Images
);

DELETE FROM Classes_Students 
WHERE Classes_Students.idClass NOT IN
(
SELECT idClass FROM Classes
); 

DELETE FROM Grades 
WHERE Grades.idStudent NOT IN
(
SELECT idStudent FROM Classes_Students
); 


UPDATE Classes
SET idClass=1; 

UPDATE Classes_StartLinks
SET idClass=1; 

UPDATE Lessons
SET idClass=1; 

UPDATE Classes_Students
SET idClass=1; 




