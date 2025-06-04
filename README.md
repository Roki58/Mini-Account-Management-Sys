 🧾 Mini Account Management System

A simple and functional accounting system built using ASP.NET Core (Razor Pages) and MS SQL Server using stored procedures only — developed as part of a technical assessment to demonstrate core features like user role management, chart of accounts, and voucher entry in a clean, modular architecture. Key modules include user role management, chart of accounts, and voucher entry.

---

🚀 Technologies Used

- ASP.NET Core (Razor Pages)
- MS SQL Server (Stored Procedures)
- ASP.NET Identity (with custom roles)
- Bootstrap, HTML/CSS
- No LINQ

---

🔐 Core Features

 1. User Roles & Permissions
- Manage user roles: `Admin`, `Accountant`, `Viewer`
- Grant module-wise access via stored procedures

 2. Chart of Accounts
- Add/Edit/Delete accounts (e.g. Cash, Bank, Receivable)
- Display accounts in a parent-child tree view
- Stored Procedure: `sp_ManageChartOfAccounts`

 3. Voucher Entry Module
Supports:
- Journal, Payment, and Receipt vouchers  
Fields:
- Date, Reference No., Multi-line Debit/Credit entries  
- Dropdown-based account selection  
Stored Procedure: `sp_SaveVoucher`


---

🖼️ Screenshots

> *(Replace image paths with your own screenshots)*

 🔐 Home Page  
![home](https://github.com/user-attachments/assets/98c92dad-264e-4a4d-b9c7-78f5cf8dcee9)
.png)

📋 Dashboard  
![Dashboard](screenshots/dash![add](https://github.com/user-attachments/assets/4fd71fd3-a67d-4f89-b4fe-dbef2a69f1a7)
board.png)

👥 User Create  
![Create Account](screenshots/ro![create](https://github.com/user-attachments/assets/b1232dea-8aac-475d-9e11-f12f50405ab6)
les.png)

 📘 Edit Accounts  
![Edit Account](screenshots/c![edit](https://github.com/user-attachments/assets/5ba0aa64-6061-4147-8dc9-c21a8807f86c)
hart_of_accounts.png)

 🧾 Delete Accounts  
![Delete Account](screen![delete](https://github.com/user-attachments/assets/d4ceea6f-d371-4b31-84af-3cf4ef8b9ddd)
shots/voucher_entry.png)

⚙️ Getting Started

Run the App

dotnet run

---
📂 Folder Structure

![folder1](https://github.com/user-attachments/assets/9cee4d50-1eb8-4871-83b2-d82a109bb1bd)
![folder2](https://github.com/user-attachments/assets/3bf81322-7448-4e94-b761-28cac8acf103)

# 🏃‍♂️ How to Run the Mini Account Management System

A simple and functional accounting system built using ASP.NET Core (Razor Pages) and MS SQL Server using stored procedures only — developed as part of a technical assessment to demonstrate core features like user role management, chart of accounts, and voucher entry.

---

## ✅ Prerequisites

- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/en-us/download)
- SQL Server (LocalDB, Express, or full version)
- SQL Server Management Studio (optional)
- Visual Studio 2022+ / VS Code / JetBrains Rider

---

 ▶️ Steps to Run

 1. Clone or Extract the Project
```bash
git clone https://github.com/Roki58/Mini-Account-Management-Sys.git
cd Mini-Account-Management-Sys
```
Or unzip the downloaded folder.

 2. Set Up the Database

- Create a database in SQL Server (e.g., `MiniAccountDb`).
- Run the stored procedure and table creation scripts (if provided).

 3. Update `appsettings.json`
```json
"ConnectionStrings": {
  "DbConnection": "Server=localhost;Database=MiniAccountDb;Trusted_Connection=True;"
}
```

 4. Restore & Build

dotnet restore
dotnet build


 5. Apply Migrations (if needed)
dotnet ef database update


 6. Run the App

dotnet run









