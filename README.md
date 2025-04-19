# 🧸 Toy Robot Simulator (.NET 8)

A simple command-line simulator for a toy robot moving on a 5x5 table. Built using **.NET 8**, with **Dependency Injection**, **WebApplicationBuilder**, and unit tests written in **xUnit**.

## 📋 Problem Statement

The application simulates a toy robot moving on a square tabletop. The table is of size 5x5 units. The robot can be placed on the table, moved, rotated left/right, and report its current location. The robot must not fall off the table — any command that would result in falling is ignored.

---

## 🚀 Features

- Handles `PLACE`, `MOVE`, `LEFT`, `RIGHT`, and `REPORT` commands
- Ignores invalid moves that lead the robot off the table
- Built with modern **.NET 8** structure
- Uses **WebApplicationBuilder** for dependency injection (DI)
- Comes with full test coverage using **xUnit**

---

## 🛠️ Commands

- `PLACE X,Y,DIRECTION` — Place the robot on the table at position (X, Y) facing NORTH, SOUTH, EAST, or WEST.
- `MOVE` — Moves the robot one unit forward in the current direction.
- `LEFT` — Rotates the robot 90 degrees to the left.
- `RIGHT` — Rotates the robot 90 degrees to the right.
- `REPORT` — Outputs the current position and direction of the robot.
- `EXIT` — Ends the simulation.

---
