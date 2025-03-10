# 📜 Student Management System - Database Schema Migrations

This project demonstrates **database schema migrations** using **both Change-Based (EF Code-First)** and **State-Based (Database-First) approaches**.  
Each task follows a structured approach to schema evolution while ensuring data integrity.

---

## 📌 Tasks and Implementations

### 1️⃣ Initial Schema
We created the **initial database schema**, defining the following entities:
- `Student` (Id, FirstName, LastName, Email, EnrollmentDate)
- `Course` (Id, Title, Credits)
- `Enrollment` (Id, StudentId, CourseId, Grade)

✅ **Change-Based:** Implemented using **EF Core Migrations** (`dotnet ef migrations add InitialCreate`).  
✅ **State-Based:** Created manually using **SQL scripts** and reverse-engineered (`dotnet ef dbcontext scaffold`).

---

### 2️⃣ Add `MiddleName` to `Student`
We added a `MiddleName` column to the `Student` entity.

✅ **Change-Based:** Modified the model, generated a migration (`dotnet ef migrations add AddMiddleNameToStudent`), and updated the database.  
✅ **State-Based:** Ran `ALTER TABLE Students ADD MiddleName NVARCHAR(255) NULL;` and reverse-engineered the model.

---

### 3️⃣ Add `DateOfBirth` to `Student`
A `DateOfBirth` column was introduced for `Student`.

✅ **Change-Based:** Added the property, created a migration, and updated the database.  
✅ **State-Based:** Used `ALTER TABLE Students ADD DateOfBirth DATE NOT NULL DEFAULT '2000-01-01';` to ensure backward compatibility.

---

### 4️⃣ Add `Instructor` Relation and Foreign Key in `Course`
We introduced an `Instructor` entity and linked `Course` with a foreign key.

✅ **Change-Based:**  
- Created an `Instructor` model.  
- Added `InstructorId` as a **foreign key** in `Course`.  
- Updated `SchoolContext.cs` and generated a migration.

✅ **State-Based:**  
- Created `Instructors` using `CREATE TABLE`.  
- Added `InstructorId` to `Courses` with a **FOREIGN KEY constraint**.  
- Reverse-engineered the schema.

---

### 5️⃣ Rename `Grade` to `FinalGrade` in `Enrollment`
The `Grade` column in `Enrollment` was renamed to `FinalGrade`.

✅ **Change-Based:** Used `dotnet ef migrations add RenameGradeToFinalGrade`, ensuring no data loss.  
✅ **State-Based:** Applied `EXEC sp_rename 'Enrollments.Grade', 'FinalGrade', 'COLUMN';` to rename the column safely.

---

### 6️⃣ _____
We introduced a Department entity with a foreign key relationship to Instructor.

✅ Change-Based:

    Created a Department model with properties: Id, Name, Budget, StartDate, and DepartmentHeadId.
    Generated a migration using dotnet ef migrations add AddDepartmentModel.
    Applied the migration using dotnet ef database update.

✅ State-Based:

    Created the Departments table using a raw SQL query:

CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Budget DECIMAL(18,2) NOT NULL,
    StartDate DATETIME2 NOT NULL,
    DepartmentHeadId INT NOT NULL,
    CONSTRAINT FK_DepartmentHead FOREIGN KEY (DepartmentHeadId) REFERENCES Instructors(Id) ON DELETE CASCADE
);

Updated the models to reflect the change and manually added the foreign key using SQL.

### 7️⃣ _____
We changed the Credits property in the Course entity from an int to a decimal type to better represent the credits as a precise value with decimal places.

✅ Change-Based:

    Modified the Credits property in the Course model to decimal.
    Generated a migration using dotnet ef migrations add ChangeCreditsToDecimal.
    Applied the migration using dotnet ef database update.

✅ State-Based:

    Ran the following SQL command to alter the Credits column in the Courses table:

ALTER TABLE Courses
ALTER COLUMN Credits DECIMAL(18, 2) NOT NULL;

Updated the model to reflect the change in code.
---

## 📌 Destructive vs. Non-Destructive Schema Changes
We prioritized **non-destructive** schema changes wherever possible to **preserve existing data** and avoid breaking changes.  
For example, instead of **dropping and recreating columns**, we used **`ALTER TABLE`** and **`sp_rename`** to safely evolve the schema.

Why Destructive:
For Task 7, we changed the Credits property from int to decimal. This was a destructive change because it alters the data type of an existing column in the table. However, the change was deemed appropriate as it better matches the real-world requirements for the Credits column (to support fractional values, such as 3.5 credits).

Why Non-destructive:
For most of the previous tasks, we focused on non-destructive changes, meaning we avoided dropping or recreating columns or tables. For instance, adding new columns (like MiddleName or DateOfBirth) and establishing new relationships (like the Instructor relationship with Course) were handled using ALTER TABLE commands to add columns and create relationships without affecting existing data.

---

## 🚀 How to Run the Project
1. **Clone the repository**:
   ```sh
   git clone <repo-url>
   cd StudentManagement
   ```
2. **Apply Migrations (Change-Based)**
   ```sh
   dotnet ef database update
   ```
3. **Manually Execute SQL (State-Based)**
   ```sh
   <Run SQL commands provided in the tasks>
   ```

---

## 📌 Team Contribution
- **[Oliver Ager Jogensen]**: Implemented tasks 1-5.
- **[Alexander]**: Will complete tasks 6-7.

---

### ✅ Summary
This project showcases **real-world schema migrations** using both **EF Core Migrations (Change-Based)** and **manual SQL updates (State-Based)**.  
By following best practices, we ensured a **smooth and non-destructive evolution** of the database. 🚀  
