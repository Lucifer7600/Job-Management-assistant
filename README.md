# 📌 JobFlow – Smart Job Application Manager  
Built with **ASP.NET Core (.NET 8)**, **EF Core**, **Clean Architecture**, and **ClosedXML**

JobFlow is a full-stack .NET application designed to help job seekers stay organized and work more efficiently during their job search.  
It streamlines tracking, scoring, and managing job applications — while showcasing modern, professional software engineering practices.

---

## 🌟 What JobFlow Helps You Do

- Track and manage all your job applications  
- Score job postings based on how well they match your skills  
- Export your full job list to Excel  
- Store notes, documents, dates, and interactions  
- Improve clarity and productivity while job searching  

> ⚠️ **Important:**  
> JobFlow does **NOT** scrape or automate LinkedIn Easy Apply.  
> It fully respects LinkedIn’s Terms of Service — all data is manually entered by the user.

---

## 🚀 Features

### ✔ Full CRUD Job Management
- Add, edit, view, and delete job entries  
- Save company, position, contact info, job type, website link, and more  
- Track status (New, Applied, Interview, Offer, Rejected, etc.)

### ✔ Smart Compatibility Scoring  
Paste any job description and JobFlow will:

- Detect skills like **C#, .NET, ASP.NET Core, SQL, React, Git**, and others  
- Count matched keywords  
- Generate a compatibility level (Low / Medium / High)  
- Provide a clear explanation of why the score was given  

**Example:**  
Matched **7 of 16 key skills:**  
*C#, .NET, ASP.NET Core, SQL, Entity Framework, JavaScript, Git*

### ✔ Excel Export (ClosedXML)
Export all jobs to Excel with one click — including:

- Company  
- Position  
- LinkedIn URL  
- Way of Application  
- Website  
- Job Type  
- Location  
- Contact  
- Status  
- Job Documents  
- Last Interaction Notes  
- Compatibility Score + Explanation  

Perfect for offline review or backups.

### ✔ Search & Filtering
Quickly filter by:

- Status  
- Compatibility Score  
- Any keyword  

Makes it easy to find:

- Unapplied jobs  
- High-match jobs  
- Recently updated jobs  

---

## 🧱 Clean Architecture (Layered Design)

-- JobFlow.Domain → Entities, enums, domain rules 
-- JobFlow.Application → Services, interfaces, compatibility engine 
-- JobFlow.Infrastructure → EF Core, database context, Excel export 
-- JobFlow.Web → MVC UI, controllers, views 



This architecture makes the solution:

- Easy to maintain  
- Easy to extend  
- Perfect for real professional learning  
- GitHub-ready and enterprise-friendly  

---

## 🧰 Tech Stack

| Layer / Component     | Technology |
|----------------------|------------|
| Backend Framework     | ASP.NET Core MVC (.NET 8) |
| Database              | SQLite + Entity Framework Core |
| Frontend              | Razor Views + Bootstrap |
| Architecture          | Clean Architecture |
| File Export           | ClosedXML (Excel XLSX) |
| IDE                   | Visual Studio 2022 / 2026 |

---

## 📂 Project Structure

JobFlow/
├── JobFlow.Domain/
│ └── Entities (Job, enums)
├── JobFlow.Application/
│ └── Services (compatibility engine, interfaces)
├── JobFlow.Infrastructure/
│ ├── Data (DbContext)
│ └── Services (Excel export)
├── JobFlow.Web/
│ ├── Controllers
│ ├── Views (Razor)
│ ├── wwwroot
│ └── Program.cs



---

## ▶️ Running the Project Locally

### 1️⃣ Prerequisites
- .NET 8 SDK  
- Visual Studio 2022 / 2026  
- SQLite (no setup required — EF Core auto-creates DB)

### 2️⃣ Restore & Build
dotnet restore
dotnet build

### 3️⃣ Apply Migrations
dotnet ef database update --project JobFlow.Infrastructure --startup-project JobFlow.Web

### 4️⃣ Run the Application
dotnet run --project JobFlow.Web

---

📈 Future Enhancements

AI-powered screening question generator
Automatic resume & cover-letter picker
Daily review dashboard
Email reminders & notifications
Multi-user support (SaaS mode)


🙌 Author

Abhishek Lunagariya
Montreal, QC, Canada
Junior .NET Developer
Learning full-stack development by building real software products


⭐ Support the Project

If you find JobFlow helpful:
Star ⭐ the repository
Fork and experiment with new ideas
Share it with other job seekers and developers
