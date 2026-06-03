# 🛡️ virusAApp (Desktop AntiVirus & Registry Scanner)

This project was developed as part of the **Object-Oriented Programming (OOP)** course at **Fırat University, Software Engineering Department**. The application is an advanced desktop security and anti-malware simulation platform featuring behavioral analysis of Windows Registry vulnerabilities, driven by a decoupled asynchronous backend.

---

## 🎓 Student Information

* **Name & Surname:** Esra Gürbüz
* **Student ID:** 230543001
* **University:** Fırat University
* **Department:** Software Engineering (Sophomore / 2nd Year)

---

## 🚀 Architectural & OOP Highlights

This application avoids "Spaghetti Code" by segregating components into decoupled, dedicated architectural layers following production-ready engineering standards:

* **Abstraction & Interfaces (`IAntiVirusService`):** Core threat detection pipelines, termination actions, and system logs are completely abstracted through interfaces. This enforces a strict structural contract, allowing the underlying malware detection engine to be swapped seamlessly without impacting other layers.
* **Dependency Inversion (Loose Coupling):** The presentation layer (`MainForm`) relies exclusively on the `IAntiVirusService` abstraction rather than concrete implementations, successfully preventing rigid, tight class cross-dependencies.
* **Event-Driven Programming:** Avoids the anti-pattern of tight UI coupling by subscribing to custom `Action` event streams (`OnThreatDetected`, `OnScanStatusChanged`). The UI layer operates entirely on an asynchronous event-driven model, natively capturing scanner pulses via specialized WinForms Event Handlers.
* **Asynchronous Execution & Thread-Safety:** Heavy threat analysis routines push processing components to background pipelines. To preserve a smooth user experience and prevent window freezing, operation orchestration is offloaded using `Task.Run` worker threads combined with `Control.BeginInvoke` to safely marshal updates back to the UI thread.
* **Robust Data Encapsulation:** Implemented strongly-typed metadata structures (`VirusThreat`) and status mappings (`ThreatSeverity` enum), eliminating runtime data uyuşmazlığı and magic-string vulnerabilities during threat logs sorting.

---

## 📁 Directory Structure

The solution is divided into four distinct modules to achieve a clear separation of concerns (SoC):

```text
virusAApp/
│
├── virusAApp/
│   ├── Interfaces/        # Service contracts, abstract business pipelines, and API boundaries
│   │   └── IAntiVirusService.cs
│   │
│   ├── Models/            # Domain Data Transfer Objects (DTO) and strict system metadata schemas
│   │   ├── VirusThreat.cs   # Encapsulates registry paths, hazard classifications, and threat records
│   │   └── ThreatSeverity.cs # Strongly-typed enum mapping vulnerability risk indices
│   │
│   ├── Services/          # Concrete business logic, asynchronous simulation pipelines, and triggers
│   │   └── AntiVirusService.cs
│   │
│   └── UI/                # Presentation layer forms, structural state layouts, and code-behind
│       ├── MainForm.cs
│       ├── MainForm.Designer.cs
│       └── Program.cs     # Application bootstrapper and main engine entry point
```
## 🛠️ Tech Stack & Dependencies

* **Language:** C#
* **Framework:** .NET 8.0 Ecosystem (Long-Term Support)
* **User Interface:** Windows Forms (WinForms)
* **Design Patterns:** Event-Driven Architecture, Separation of Concerns (SoC)

---

## 🔧 Installation & Setup

1. Clone this repository to your local machine:
   ```bash
   git clone [https://github.com/your-username/virusAApp.git](https://github.com/your-username/virusAApp.git)
   ```
2. Open the `virusAApp.sln` solution file in **Visual Studio**.
3. Ensure that the target framework is recognized as **.NET 8.0**.
4. Build the solution using `Ctrl + Shift + B` to verify that all solution assemblies and namespace files are linked properly.
5. Press `F5` or click the green **Start** button to launch the anti-malware desktop simulation panel.

---
*Developed for educational purposes as a technical OOP portfolio milestone.*
