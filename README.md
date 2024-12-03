# 📚 **Books API**

This API enables CRUD operations for managing books in a library. Built using **ASP.NET Core** and following **Onion Architecture**, it promotes clean, maintainable, and scalable code.

---

## 🛠️ **Features**
- 🖋️ **Add Books:** Add new books with metadata like title, author, ISBN, and more.
- 🔍 **Retrieve Books:** Fetch all books or a specific book by ID.
- ✏️ **Update Books:** Modify book details.
- ❌ **Delete Books:** Remove books by ID.
- 📖 **DTO Support:** Ensures structured data flow between layers.
- 🧪 **Unit Tests:** Ensures code reliability with tests implemented using **xUnit** and **Moq**.

---

## 🏛️ **Architecture Overview**

The API adopts **Onion Architecture** to separate concerns effectively. This approach ensures that core logic remains independent of external dependencies like data access or frameworks.

### 🌀 **Layered Design**:
1. **Core/Domain Layer**  
   Contains entities (`Book`) and business rules. Defines repository abstractions.
2. **Application Layer**  
   Coordinates workflows, implements business use cases, and uses **DTOs** for data transfer.
3. **Infrastructure Layer**  
   Handles persistence and external services using **Entity Framework Core**.
4. **Presentation/API Layer**  
   Exposes API endpoints using **ASP.NET Controllers**.

---

## 🔧 **Technologies Used**
- **ASP.NET Core** for building the API
- **Entity Framework Core** for database access
- **xUnit** and **Moq** for unit testing
- **Onion Architecture** for clean code separation

---

## 🚀 **Getting Started**

### Prerequisites
- **.NET SDK** (Version 6.0 or higher)
- **SQL Server** for database storage
- **Visual Studio** or **VS Code** (recommended for development)

### Steps to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/books-api.git
   cd books-api
