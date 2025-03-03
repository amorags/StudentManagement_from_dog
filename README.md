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
[Task left for student partner]

---

### 7️⃣ _____
[Task left for student partner]

---

## 📌 Destructive vs. Non-Destructive Schema Changes
We prioritized **non-destructive** schema changes wherever possible to **preserve existing data** and avoid breaking changes.  
For example, instead of **dropping and recreating columns**, we used **`ALTER TABLE`** and **`sp_rename`** to safely evolve the schema.

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
