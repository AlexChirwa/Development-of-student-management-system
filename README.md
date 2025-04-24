# Development-of-student-management-system

## 📘 Student Management System (WinForms + ADO.NET)

This is a desktop-based **Student Management System** I built using **C# WinForms** and **ADO.NET**, with **SQL Server** managing all the backend data. The goal? To replace tedious spreadsheet and paper-based student record systems with a slick, interactive interface that’s easy to use and easy to scale.

This project was developed during my Database Systems course at **Wuhan Institute of Technology**, fully supervised by my lecturer **Dawei Wen**. I collaborated with classmates during design discussions, debugging, and testing, which made this a real team-learning experience.

---

## ✨ What the System Does

Here’s what you can actually do with the system:

- ✅ **Add, Edit, View, and Delete student records** — including name, gender, department, birthday, email, and even profile pictures
- 🔍 **Search by student ID**
- 🧾 **Sort and view students by department or gender**
- 🛡️ **Data integrity rules** protect against duplicate entries or invalid input (e.g. gender must be “M” or “F”, dates must be within range)
- 🧠 Designed to manage at least **100+ students easily** during development and can scale to thousands thanks to optimized SQL queries and indexing

---

## 🧑‍🎓 Who This System Helps

This Student Management System was designed with **educational institutions** in mind — particularly small-to-medium-sized colleges and training centers that still rely on **manual or spreadsheet-based systems**.

Here’s who benefits:

- **Librarians & Admin Staff:** Save time by entering and retrieving student info with just a few clicks instead of flipping through files or Excel sheets.
- **Lecturers:** Can view or verify student details quickly, especially when linked to course data or grade records.
- **Students:** Get their records managed more accurately, reducing mix-ups in names, IDs, and departments.
- **IT Departments:** Gain a lightweight, reliable database-driven system that can be hosted and maintained internally.

💡 Whether it's reducing errors, saving hours of admin work, or giving staff a user-friendly interface — this system was built to make life simpler and more organized across the board.

---

## 🛠️ Tech Stack

- **Frontend**: Windows Forms App (.NET Framework)
- **Backend**: ADO.NET with C# for DB interaction
- **Database**: SQL Server 2019
- **Dev Tool**: Visual Studio

---

## 🔑 Key Features (Made Simple)

- **CRUD Operations**  
  (Create, Read, Update, Delete): This is the basic backbone of almost every database system. You can create new students, read/view existing ones, update their data, or delete them if needed.

- **GUI (Graphical User Interface)**  
  Instead of typing commands, everything runs through buttons, dropdowns, and forms. This makes it super accessible for non-technical users like admin staff.

- **Foreign Key Constraints**  
  These are database rules that ensure students can only be added under valid departments, and course enrollments only reference real students and courses. Basically: no weird broken data allowed.

- **Data Validation**  
  We use checks and constraints to prevent bad data. For example, students can't be born in 2040, and every department must exist before assigning a student to it.

---

## 🔐 Data Integrity & Security Enforcement

You might see buzzwords like *“data integrity”* or *“security enforcement”* — so here’s what that really means:

- 👀 **Integrity** = no duplicates, no missing relationships, no garbage data
- 🔒 **Security Enforcement** = role-based views in the DB, where students can only read data, teachers can edit grades, and admins can do it all

These protections help prevent accidental errors *and* intentional misuse (think: tampering grades or deleting all students by mistake).

---

## 💬 Soft Skills + Teamwork

This wasn’t a solo mission. I worked closely with my classmates on planning, testing, and feedback sessions. I:
- 💬 Listened to suggestions to improve usability
- 🧪 Took turns testing functionality on different machines
- 🔧 Troubleshot bugs together with peers in lab environments

This experience helped me grow as a **collaborative developer** — learning how to merge ideas, debug as a team, and refine a system iteratively.

---

## 🧪 Testing & Real-World Simulation

- Manual testing was done using different student data sets (20–30 entries)
- Ran validations like image upload failures, invalid emails, or missing fields
- Confirmed the DB rules blocked unauthorized or invalid entries
- Designed for real-world deployment in educational environments

---

## 📸 Screenshots

### 🪪Windows Authentication
![Windows Authentication](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Windows-Authentication.png)

### 👩‍💻SQL Server Authentication requires
![SQL Server Authentication requires](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/SQL-Server-Authentication-requires.png)

### 🪢Database Relationship Diagram
![Database Relationship Diagram](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Database-Relationship-Diagram.png)

### 🚀the query of the database
![the query of the database](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/the-query-of-the-database.png)

### ✅t_Student table
![t_Student table](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/t_Student-table.png)

### ✅t_Course table
![t_Course table](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/t_Course-table.png)

### ✅t_SC table
![t_SC table](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/t_SC-table.png)

### ✅t_Sdept table
![t_Sdept table](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/t_Sdept-table.png)

### 🧱Configure the new Windows Forms Application
![Configure the new Windows Forms Application](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Configure-the-new-Windows-Forms-Application.png)

### 🧱⚒️Windows form and Solution Explorer
![Windows form and Solution Explorer](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Windows-form-and-Solution-Explorer.png)

### 🧱⚒️Modifying the form name
![Modifying the form name](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Modifying-the-form-name.png)

### 🤺Application main form interface
![Application main form interface](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Application-main-form-interface.png)

### 🪢Database connection string settings
![Database connection string settings](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Database-connection-string-settings.png)

### 👦🏾👧🏾Gender drop down box data binding
![Gender drop down box data binding](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Gender-drop-down-box-data-binding.png)

### 👩‍💻Student Management Form
![Student Management Form](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Student-Management-Form.png)

### 📝Insert student information
![Insert student information](https://raw.githubusercontent.com/AlexChirwa/Development-of-student-management-system/main/screenshots/Insert-student-information.png)



---

## 🧭 How to Run This Locally

1. Install **Visual Studio**
2. Open the `StdMng2023.sln` solution file
3. Ensure SQL Server is running and restore/import the provided `StdMng2023V2` database
4. Update the connection string in `App.config` if needed:
   ```
   Server=YOUR_SERVER;Database=StdMng2023V2;Integrated Security=True
   ```
5. Press `F5` or `Ctrl + F5` to launch the WinForms app

---

## 👨‍🏫 Supervision & Guidance

This project was **developed by me, Alex Chirwa**, under the full supervision of **Lecturer Dawei Wen** during my **Database Management Systems (DBMS)** course at **Wuhan Institute of Technology**.

I want to acknowledge my **classmates** who participated in hands-on test sessions and helped shape the user flow based on real feedback.

---

## 🪪 License

MIT — you’re free to explore, learn, and fork this project.

---

## 🙌 Thanks for Reading!

If you're a student, educator, or developer interested in building educational systems — feel free to fork this repo or reach out! I’m always up for sharing knowledge or improving the system.

---
