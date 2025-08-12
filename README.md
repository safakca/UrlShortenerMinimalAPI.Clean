# UrlShortenerMinimalAPI - Clean Version

A clean code implementation of a URL shortener built with **.NET 9 Minimal API**.  
Includes **xUnit** tests to ensure functionality and maintainability.

---

## Features
- **POST /shorten** – Accepts a long URL and returns a short code.
- **GET /{code}** – Redirects to the original URL using the short code.
- **In-memory storage** using `Dictionary<string, string>`.
- **Base32** character set for short code generation.
- **Clean code principles** applied for better structure and readability.
- **Unit tests** written with **xUnit**.

---

## Technologies
- [.NET 9](https://dotnet.microsoft.com/)
- Minimal API
- C#
- xUnit (for testing)
- Swagger (for API documentation)

---

## How to Run
1. **Clone the repository**
   ```bash
   git clone https://github.com/safakca/UrlShortenerMinimalAPI.Clean.git
