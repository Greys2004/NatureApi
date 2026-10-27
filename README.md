<div align="center">

# ✦ NatureApi

### NatureApp backend

REST API for NatureApp with SQL Server database integration and Swagger documentation.

![Tech](https://img.shields.io/badge/Purple_Future-Portfolio-974ECA?style=for-the-badge&labelColor=251139)

[GitHub profile](https://github.com/Greys2004) · [Related application](https://github.com/Greys2004/NatureApp)

</div>

---

## ✦ Highlights

- ASP.NET Core controllers
- Entity Framework Core and SQL Server
- Swagger/OpenAPI endpoints
- Database connection resiliency

## ⚙️ Technologies

`ASP.NET Core` · `Entity Framework Core` · `SQL Server` · `Swagger`

## 🚀 Run locally

```bash
dotnet restore NatureApi.sln
dotnet run --project natureApi
```

Install the matching .NET SDK, then configure the `sqlServer` connection string securely. Swagger is available at `/swagger` when running.

## 📌 Notes

**Security:** current startup code logs configuration values that may contain secrets and allows any CORS origin. Remove sensitive logging and review deployment security before production.

Never commit production secrets or credentials.

---

<div align="center">**Greys Alexa Almanza Vega** · Software Engineer 💜</div>
