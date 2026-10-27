<div align="center">

# ✦ NatureApi — Parks & Trails REST API

**API backend for the NatureApp project, with controllers, SQL Server persistence and OpenAPI documentation.**

![Documentation](https://img.shields.io/badge/Documentation-Updated-8B5CF6?style=for-the-badge) ![Project](https://img.shields.io/badge/Greys2004-Portfolio-4C1D95?style=for-the-badge)

</div>

---

## Overview

API backend for the NatureApp project, with controllers, SQL Server persistence and OpenAPI documentation.

## Technology

ASP.NET Core, Entity Framework Core, SQL Server, Swagger and Docker.

## Local development

Clone this repository and enter its directory. Then run:

```bash
dotnet restore NatureApi.sln
dotnet run --project natureApi
```

Install the matching .NET SDK and configure the sqlServer connection string securely.

## Related repository

[NatureApp](https://github.com/Greys2004/NatureApp)

## Notes

This README documents the project's verified technologies and intended use. Deployment credentials and application-specific environment values are not included. Do not commit API keys or production secrets.

**Security review:** the current startup code logs sensitive configuration values. Remove that logging and review CORS/authentication before deploying to production.

## Author

**Greys Alexa Almanza Vega** · [GitHub](https://github.com/Greys2004) · [Portfolio](https://greys2004.github.io/Curriculum/)
