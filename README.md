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

 🎁 Bonus Features
- Report export to Excel (if implemented)

---

🖼️ Screenshots

> *(Replace image paths with your own screenshots)*

 🔐 Home Page  
![Home Page](screenshots/login![delete](https://github.com/user-attachments/assets/9c137148-ab56-4aca-b915-d517d278bb76)
![edit](https://github.com/user-attachments/assets/3292dd1a-d9b8-4654-9b1f-b88562be6ccc)
![add](https://github.com/user-attachments/assets/1a609328-95d9-424a-869e-289db330d908)
![create](https://github.com/user-attachments/assets/9c72e5a9-de2a-4c83-baea-0a0eb1bd907b)
![home](https://github.com/user-attachments/assets/98c92dad-264e-4a4d-b9c7-78f5cf8dcee9)
.png)

📋 Dashboard  
![Dashboard](screenshots/dashboard.png)

👥 User Role Management  
![Role Management](screenshots/roles.png)

 📘 Chart of Accounts  
![Chart of Accounts](screenshots/chart_of_accounts.png)

 🧾 Voucher Entry  
![Voucher Entry](screenshots/voucher_entry.png)

---
📂 Folder Structure
MiniAccountSystem/
│
├── wwwroot/                    # Static files (css, js, images)
│   ├── css/
│   └── js/
│
├── Pages/                      # Razor Pages
│   ├── Shared/                # _Layout, partials
│   ├── Auth/                  # Login, Register, Roles
│   ├── Accounts/              # Chart of Accounts
│   ├── Vouchers/              # Voucher entry
│   ├── Index.cshtml
│   └── _ViewStart.cshtml
│
├── Models/                    # Plain C# Models
│   ├── AccountModel.cs
│   ├── VoucherModel.cs
│   └── ViewModels/
│       └── VoucherEntryVM.cs
│
├── Services/                  # SQL Stored Procedure Call Wrappers
│   ├── AccountService.cs
│   ├── VoucherService.cs
│   └── UserService.cs
│
├── Data/                      # Identity & DB Context (if needed for Identity)
│   └── ApplicationDbContext.cs
│
├── Scripts/                   # SQL Scripts (schema + SPs)
│   ├── Tables.sql
│   └── StoredProcedures.sql
│
├── appsettings.json
├── Program.cs
├── Startup.cs (if .NET 5 or earlier)
├── README.md
└── MiniAccountSystem.csproj





