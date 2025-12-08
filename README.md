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

JobFlow.Domain → Entities, enums, domain rules
JobFlow.Application → Services, interfaces, compatibility engine
JobFlow.Infrastructure → EF Core, database context, Excel export
JobFlow.Web → MVC UI, controllers, views

