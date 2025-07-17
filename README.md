# 📝 Blog Management System

A full-featured Blog Management System built with ASP.NET Core and Entity Framework Core. This project demonstrates key concepts of backend development including authentication, role-based authorization, layered architecture, and token-based API consumption.

---

## 🚀 Features

- ✅ User Registration & Login (JWT-based)
- ✅ Role-Based Authorization (Admin, Author)
- ✅ Blog & Category CRUD Operations
- ✅ Authentication Middleware
- ✅ Token generation and validation
- ✅ Swagger API documentation with JWT support

---

## 🛠 Technologies Used

| Layer                  | Technology                        |
|------------------------|------------------------------------|
| Language               | C#                                 |
| Backend Framework      | ASP.NET Core 8 Web API             |
| ORM & DB Access        | Entity Framework Core              |
| Architecture           | Layered (API, Application, Domain, Infrastructure, Persistence) |
| Authentication         | JWT (Json Web Token)               |
| Authorization          | Role-based Authorization           |
| Database               | MS SQL Server                      |
| Documentation          | Swagger (Swashbuckle)              |
| IDE                    | Visual Studio 2022                 |

---

## 📂 Project Structure

BlogManagementSystem
│
├── BlogManagementSystem.API → API Layer (Controllers, Swagger setup)
├── BlogManagementSystem.Application → Business Logic (DTOs, Interfaces, Services)
├── BlogManagementSystem.Domain → Domain Models (Entities, Enums)
├── BlogManagementSystem.Infrastructure→ JWT, Logging, Configurations
├── BlogManagementSystem.Persistence → EF Core DbContext, Repositories, Migrations

---

## 🧪 How to Test

1. Clone the repo and run `dotnet ef database update` to create the database.
2. Run the API project (`BlogManagementSystem.API`).
3. Open Swagger and:
   - Use `/api/Auth/Register` to create a new user.
   - Use `/api/Auth/Login` to get a JWT token.
   - Authorize Swagger using the token to test blog and category endpoints.

---

# 🇹🇷 Blog Yönetim Sistemi

ASP.NET Core ve Entity Framework Core ile geliştirilen tam özellikli bir Blog Yönetim Sistemi. Bu proje, kullanıcı doğrulama, rol tabanlı yetkilendirme, katmanlı mimari ve token bazlı API kullanımını içeren temel backend becerilerini göstermektedir.

---

## 🚀 Özellikler

- ✅ Kullanıcı Kayıt ve Giriş (JWT tabanlı)
- ✅ Rol Tabanlı Yetkilendirme (Admin, Yazar)
- ✅ Blog ve Kategori CRUD işlemleri
- ✅ Yetkilendirme Middleware yapısı
- ✅ Token üretimi ve doğrulama
- ✅ JWT destekli Swagger dokümantasyonu

---

## 🛠 Kullanılan Teknolojiler

| Katman                | Teknoloji                          |
|------------------------|------------------------------------|
| Dil                   | C#                                 |
| Backend Framework     | ASP.NET Core 8 Web API             |
| ORM & DB              | Entity Framework Core              |
| Mimari                | Katmanlı (API, Application, Domain, Infrastructure, Persistence) |
| Kimlik Doğrulama      | JWT (Json Web Token)               |
| Yetkilendirme         | Rol Tabanlı Yetkilendirme          |
| Veritabanı            | MS SQL Server                      |
| Dokümantasyon         | Swagger (Swashbuckle)              |
| Geliştirme Ortamı     | Visual Studio 2022                 |

---

## 📂 Proje Yapısı

BlogManagementSystem
│
├── BlogManagementSystem.API → API Katmanı (Controller, Swagger)
├── BlogManagementSystem.Application → İş Katmanı (DTO, Servisler, Arayüzler)
├── BlogManagementSystem.Domain → Temel Model ve Enums
├── BlogManagementSystem.Infrastructure→ JWT, Logging, Yapılandırmalar
├── BlogManagementSystem.Persistence → EF Core DbContext, Repository ve Migration


---

## 🧪 Test Etme Adımları

1. Repoyu klonlayın ve `dotnet ef database update` komutuyla veritabanını oluşturun.
2. `BlogManagementSystem.API` projesini çalıştırın.
3. Swagger arayüzünü açarak:
   - `/api/Auth/Register` ile yeni kullanıcı oluşturun.
   - `/api/Auth/Login` ile JWT token alın.
   - Swagger'a token ile giriş yaparak blog ve kategori endpointlerini test edin.

---

## 📌 Not

Frontend kısmı ilerleyen zamanlarda React ile geliştirilecektir. Backend, frontend tarafından JWT token ile güvenli bir şekilde kullanılmaya hazırdır.
