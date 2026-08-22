# 24-57769-2_CompanyApp

## Lab 2: Merging Login/Register and Employee CRUD into One App

### 1. Before and after

Before the merge, the coursework had two separate Windows Forms applications:

- **Login-and-Register**: login, registration and dashboard, originally using Microsoft Access/OleDb.
- **EmployeeDetails**: employee CRUD, using SQL Server LocalDB/SqlClient.

The final solution is one Windows Forms application named `CompanyApp`, hosted from the former EmployeeDetails project. It uses one SQL Server LocalDB database named `dbCompanyApp` containing both `dbo.Users` and `dbo.Emp_details`.

The application flow is:

`Login -> Dashboard -> Manage Employees -> Employee CRUD`

Logout clears the session and opens a new login form.

### 2. The six conflicts and how they were resolved

1. **Different namespaces**  
   Imported forms were placed in the host namespace `EmployeeDetails`. The project root namespace remains `EmployeeDetails` as required, while the assembly name is `CompanyApp`.

2. **Different data providers**  
   The Access/OleDb side was ported to SQL Server using `System.Data.SqlClient`, `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, and named `@parameters`. No Access provider is used.

3. **Two databases**  
   The final application uses one database, `dbCompanyApp`, for authentication and employee data.

4. **Different framework versions**  
   The host project targets .NET Framework 4.8.

5. **Two Program.cs / two Main() methods**  
   Only the host `Program.cs` remains. It starts the application with `Application.Run(new frmLogin())`.

6. **Hidden Access-file dependency**  
   The Access `.mdb` database is removed from the final application. Authentication now reads from `dbo.Users` in SQL Server, so cleaning the solution does not depend on an untracked `.mdb` file in `bin\Debug`.

### 3. Unified database design

`Schema.sql` creates:

- `dbo.Users`
  - `UserID INT IDENTITY(1,1) PRIMARY KEY`
  - `Username NVARCHAR(50) NOT NULL UNIQUE`
  - `Password NVARCHAR(200) NOT NULL`
  - `CreatedAt DATETIME DEFAULT GETDATE()`

- `dbo.Emp_details`
  - `EmpId NVARCHAR(50) PRIMARY KEY`
  - `EmpName NVARCHAR(100) NOT NULL`
  - `EmpAge INT NOT NULL`
  - `EmpContact NVARCHAR(20)`
  - `EmpGender NVARCHAR(10)`
  - `CreatedBy INT NULL`
  - foreign key from `CreatedBy` to `dbo.Users(UserID)`

`CreatedBy` is nullable so migrated employee rows can remain valid even when their original creator is unknown.

### 4. Access account migration

Existing Access accounts were intended to be migrated into `dbo.Users` using:

```sql
INSERT INTO dbo.Users (Username, Password)
VALUES (N'username_here', N'password_here');
```

`UserID` is intentionally omitted because SQL Server generates it using `IDENTITY`.

### 5. Three-file rule and form import

Each imported Windows Forms form travels as three related files:

- `.cs` for event/code logic
- `.Designer.cs` for controls and layout
- `.resx` for resources

The merged project contains:

- `frmLogin.cs`, `frmLogin.Designer.cs`, `frmLogin.resx`
- `frmRegister.cs`, `frmRegister.Designer.cs`, `frmRegister.resx`
- `frmDashboard.cs`, `frmDashboard.Designer.cs`, `frmDashboard.resx`

The employee form was renamed from `Form1` to `frmEmployee`.

### 6. OleDb -> SqlClient

The login/register implementation uses a dedicated `User.cs` data-access class.

`User.cs` implements:

- `ValidateLogin(username, password)` -> returns `UserID` or `0`
- `UsernameExists(username)` -> uses `ExecuteScalar`
- `RegisterUser(username, password)` -> returns the new `UserID`

SQL commands use named parameters such as `@Username` and `@Password`.

`Session.cs` stores:

- `Session.UserID`
- `Session.Username`

and provides `Session.Clear()`.

### 7. Login, dashboard, CRUD and logout flow

`Program.cs` starts at `frmLogin`.

After a successful login:

1. `ValidateLogin()` returns the database `UserID`.
2. `Session.UserID` and `Session.Username` are populated.
3. A `frmDashboard` is shown.
4. The login form is hidden.

The dashboard has a **Manage Employees** button that opens `frmEmployee`.

Logout:

1. Displays a Yes/No confirmation.
2. Calls `Session.Clear()`.
3. Shows a new `frmLogin`.
4. Closes the dashboard.

`frmLogin_FormClosed` calls `Application.Exit()` so closing the login window terminates the application cleanly.

### 8. CreatedBy and LEFT JOIN

When an employee is added, the current logged-in user's `Session.UserID` is written to `dbo.Emp_details.CreatedBy`.

The grid query uses:

```sql
SELECT
    e.EmpId,
    e.EmpName,
    e.EmpAge,
    e.EmpContact,
    e.EmpGender,
    e.CreatedBy,
    u.Username AS CreatedByUsername
FROM dbo.Emp_details e
LEFT JOIN dbo.Users u
    ON e.CreatedBy = u.UserID;
```

A `LEFT JOIN` is required because migrated employee rows may have `CreatedBy = NULL`. An inner join would hide those rows.

### 9. Real build issue and fix

During development, Visual Studio produced the following build error:

```text
Could not copy "obj\Debug\CompanyApp.exe" to "bin\Debug\CompanyApp.exe".
Exceeded retry count of 10. Failed.
The file is locked by: "EmployeeDetails (25840)"
The problem was caused by an already-running EmployeeDetails process that was using the executable file. Because the executable was locked by that process, Visual Studio could not replace it with the newly built CompanyApp.exe.

The issue was resolved by stopping the running EmployeeDetails process and then rebuilding the project. After the file lock was released, the project built and ran successfully.
### 10. Why one database is better than two

One database gives the application a single source of truth. Authentication data and employee data can be linked with a real foreign key instead of keeping separate files that can drift out of sync. The `CreatedBy` relationship is a practical example: `dbo.Emp_details.CreatedBy` points directly to `dbo.Users.UserID`. Because migrated rows may have a NULL creator, the employee grid uses a `LEFT JOIN`, preserving every employee while showing the username whenever a valid creator exists. This design is easier to maintain, query, back up, and keep consistent than two unrelated databases.

### 11. Screenshots for submission

Add the following screenshots before final submission:

1. SQL Server Object Explorer showing `dbCompanyApp`, `dbo.Users`, and `dbo.Emp_details`.
2. `dbo.Users -> View Data` showing migrated accounts.
3. Visual Studio Solution Explorer showing the nested `.cs`, `.Designer.cs`, and `.resx` files for the three imported forms.
4. Working flow: Login -> Dashboard -> Manage Employees -> CRUD.
5. Employee grid showing the creator username.

> Important: screenshots must be real screenshots from the completed project. Do not use placeholder or fabricated screenshots.

## Final repository checklist

- `CompanyApp.sln`
- `CompanyApp.csproj`
- `App.config`
- `README.md`
- `Schema.sql`
- `User.cs`
- `Session.cs`
- login/register/dashboard files
- `frmEmployee` files
- `Employee.cs`
- `.gitignore`
- no `bin/`, `obj/`, `.vs/`
- no `.mdb` or `.accdb`
- no `System.Data.OleDb`

