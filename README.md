# 🧩 8-Puzzle Solver using AI Search Algorithms

A C# console application that solves the **8-Puzzle problem** using classical **Artificial Intelligence search algorithms**, with a focus on performance comparison and solution quality.

---

## 🚀 Features

* Solves the 8-Puzzle problem step-by-step
* Compares multiple AI search strategies
* Displays solution path, number of moves, and execution time
* Uses heuristic-based optimization for faster search

---

## 🧠 Implemented Algorithms

* **Breadth-First Search (BFS)** — guarantees optimal solutions
* **Depth-First Search (DFS)** — memory-efficient but non-optimal
* **A\* Search (Manhattan Distance)** — efficient and optimal informed search
* **Hill Climbing** — fast local search (may fail in some cases)

---

## 🎯 Problem Setup

**Initial State**

```
1 2 3
4 0 6
7 5 8
```

**Goal State**

```
1 2 3
4 5 6
7 8 0
```

---

## 🔎 How It Works

* Each puzzle state is stored as a **1D array of 9 elements**
* `0` represents the empty space
* Valid moves: up, down, left, right
* Parent tracking allows full solution path reconstruction
* **Manhattan Distance heuristic** guides informed search (A*)

---

## ⚡ Performance Overview

| Algorithm      | Optimal | Performance              |
| -------------- | ------- | ------------------------ |
| BFS            | ✅ Yes   | High memory usage        |
| DFS            | ❌ No    | Fast, unreliable         |
| A* (Manhattan) | ✅ Yes   | Best overall             |
| Hill Climbing  | ❌ No    | Very fast, may get stuck |

---

## 🛠️ Tech Stack

* **Language:** C#
* **Framework:** .NET Framework
* **Application:** Console-based

---

## ▶️ Getting Started

1. Open the project in **Visual Studio**
2. Build the solution
3. Run with **Ctrl + F5**
4. Choose an algorithm from the menu

---

## 👥 Team

* **Zeyad Ibrahim Abdullatif Arakip** — 2023093
* **Mostafa Ahmed Abuelyazid Elsaeedy** — 2023213

---

📘 A detailed report is available in the **`report`** folder.

