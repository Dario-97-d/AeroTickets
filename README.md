# ✈️ AeroTickets

AeroTickets is a .NET 6 WinForms desktop application developed as part of a professional training course.

## 📌 Project Overview

This application simulates an airline management system.
This is the first project in the course intended to simulate a real-world use desktop application.
It allows users to manage Airports, Airplanes, Flights and Tickets.
Data persistence is achieved through a set of XFiles, whose management is coded in the project.

---

## 🚀 Features

* ✈️ CRUD: Airport, Airplane, Flight and Ticket
* 🖥️ Interactive Windows Forms UI
* 📋 Improved search and data manipulation

---

## 📂 Project Structure

```
AeroTickets/
│── AeroTickets.sln                     # Solution file
│
│── AeroTickets.ClassLibrary/           # Data model and manipulation classes
│   │── Models/                         # Data classes
│   │── AT_Checks.cs                    # Validation methods
│   │── AT_Constants.cs                 # Utility constants
│   │── IXFiles.cs                      # XFiles interface
│   │── XFiles.cs                       # Data management (using .txt files)
│
│── AeroTickets.WinForms/               # Main WinForms project
│   │── UserControls/                   # Partial forms (UI)
│   │── Form1.cs                        # Main Form
│   │── Program.cs                      # Entry point
│
│── README.md
```

---

## ⚙️ Installation & Setup

(Requires Visual Studio with .NET 6 installed)


Clone the repository:
* git clone https://github.com/Dario-97-d/AeroTickets.git

Open the solution:
* Open AeroTickets.sln in Visual Studio

Build and run:
* Press F5 or click Start in Visual Studio

---

## 📸 Screenshots

### Start Screen

The About dropup is toggled on click. It starts closed, but is opened here to show the content.

![Start Screen with About dropup](./screenshots/start-screen-about.png)

### Search Flight

Flights may be found by searching for specific fields.

![Search Flight form](./screenshots/search-flight.png)

### Flight Selection

Double-clicking a flight opens the new Ticket form, with the Flight already selected.

![Results screen with one selected Flight](./screenshots/search-results.png)

### New Ticket

Seat 7 is taken.

![New Ticket form with Seat 7 taken](./screenshots/new-ticket-seat-taken.png)

Seat 6 is available.

![New Ticket form with Seat 6 available](./screenshots/new-ticket-seat-available.png)

### Ticket List

The newly created ticket is listed here.

![Ticket List showing the new ticket](./screenshots/tickets-with-new-one.png)

### Editing an Airplane

![Edit Airplane form](./screenshots/edit-airplane.png)

### Deleting an Airport

Deleting any data requires confirmation.

![Delete Airport confirmation](./screenshots/confirm-delete-airport.png)
