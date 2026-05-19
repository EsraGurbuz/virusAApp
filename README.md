# virusAApp - Object-Oriented AntiVirus & Registry Scanner

A professional, decoupled desktop application developed in C# and .NET 8.0 Windows Forms that simulates malware registry detection and remediation processes. This project was engineered specifically to showcase advanced Object-Oriented Programming (OOP) architectures, clean code conventions, and multi-threaded event-driven engineering.

## 🚀 Key Architectural Features & OOP Concepts

- **Separation of Concerns (SoC):** The codebase is rigidly partitioned into standalone conceptual layers (`Interfaces`, `Models`, `Services`, `UI`) ensuring zero spaghetti pattern violations.
- **Strict Abstraction:** User Interface layers depend strictly on abstract contracts (`IAntiVirusService`) rather than concrete business models, implementing the *Dependency Inversion Principle (SOLID)*.
- **Event-Driven UI Notification:** Avoids anti-patterns of tight coupling by subscribing to custom `Action` event streams (`OnThreatDetected`, `OnScanStatusChanged`) pushed by asynchronous engine background tasks.
- **Asynchronous Processing & Thread Safety:** Heavy threat simulation scanning actions utilize non-blocking `Task.Run` worker threads combined with `Control.BeginInvoke` to safely dispatch updates back to the UI state thread.

---

## 📂 Project Directory Breakdown

```text
virusAApp/
│
├── Interfaces/
│   └── IAntiVirusService.cs       # Formal behavioral contract for scanning components
│
├── Models/
│   ├── VirusThreat.cs             # Encapsulated state and properties of a security hazard
│   └── ThreatSeverity.cs          # Strongly-typed enum mapping risk indices
│
├── Services/
│   └── AntiVirusService.cs        # Concrete business engine executing async registry simulators
│
└── UI/
    ├── MainForm.cs                # Form controller displaying localized grid metrics
    └── MainForm.Designer.cs       # Auto-generated programmatic UI engine settings
```

## 🛠️ Technology Stack & Dependencies
- **Framework:** .NET 8.0 (Long-Term Support)
- **GUI Engine:** Windows Forms App (.NET Desktop Workload)
- **Language:** C# 12
- **Version Control:** Git & Professional Conventional Commit Standards

## ⚡ Technical Concept Highlights (For Reviewers)

**1. Thread-Safe Invocation**
Because the threat hunting pipeline runs off-thread, attempting to write directly to the interface's ListView would throw cross-thread violations. This architecture enforces safe marshaling:
```
if (this.InvokeRequired)
{
    this.BeginInvoke(new Action(() => Service_OnThreatDetected(threat)));
    return;
}
// UI manipulations happen safely below
```
**2. Event-Driven Decoupling**
The user interface does not poll the backend engine. Instead, it signs a contract to listen for triggers:
```
concreteService.OnThreatDetected += Service_OnThreatDetected;
```

230543001
