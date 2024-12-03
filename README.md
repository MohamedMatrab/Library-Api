# 📚 **Books API**

This API enables CRUD operations for managing books in a library. Built using **ASP.NET Core** and following **Onion Architecture**, it promotes clean, maintainable, and scalable code. 

---

## 🛠️ **Features**
- 🖋️ **Add Books:** Add new books with metadata like title, author, ISBN, and more.
- 🔍 **Retrieve Books:** Fetch all books or a specific book by ID.
- ✏️ **Update Books:** Modify book details.
- ❌ **Delete Books:** Remove books by ID.
- 📖 **DTO Support:** Ensures structured data flow between layers.

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

## 🗂️ **Folder Structure**
