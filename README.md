# MicroserviceTemplate

Plantilla completa y extensible para crear microservicios con .NET 9, DDD, CQRS, MediatR y separación por capas.

> 🎯 Diseñada para escalar, facilitar pruebas, mantener coherencia entre servicios y servir como punto de partida robusto para arquitecturas modernas basadas en microservicios.

---

## 🧱 Estructura de carpetas

- `src/`
  - `API`: Punto de entrada HTTP (ASP.NET Core), controla rutas y middlewares.
  - `Application`: Casos de uso (CQRS), validaciones, interfaces de servicios y lógica de aplicación.
  - `Domain`: Entidades, Value Objects, Agregados, Interfaces de Repositorios, lógica pura de negocio.
  - `Infrastructure`: Implementaciones concretas (base de datos, servicios externos, logging, etc).

- `.template.config/`: Configuración para que funcione como plantilla con `dotnet new`.

- `docker-compose.general.yml`: Servicios compartidos como RabbitMQ, Elasticsearch, Kibana, SQL Server, Jaeger...

---

## 🚀 ¿Qué incluye?

- ✅ Arquitectura limpia basada en DDD y CQRS.
- ✅ Separación por capas con dependencias correctas.
- ✅ Uso de MediatR para Commands y Queries.
- ✅ Configuración de Serilog, Jaeger y OpenTelemetry para trazabilidad.
- ✅ Preparado para integración con Docker y Kubernetes.
- ✅ Posibilidad de generación por `dotnet new` desde CLI.
- ✅ Módulo de testing básico listo para usar.

---

## 🏁 Cómo empezar

1. **Instala la plantilla localmente:**

```bash
dotnet new install ./
```

2. **Genera un nuevo microservicio:**

```bash
dotnet new microtemplate -n NombreDelMicroservicio
```

3. **Levanta el entorno de desarrollo completo:**

```bash
docker compose -f docker-compose.general.yml up -d
```

---

## 📌 Requisitos

- .NET 9 SDK
- Docker
- CLI de dotnet
- (Opcional) Kubernetes, Helm, herramientas de observabilidad

---

## 📷 Observabilidad integrada
El template está preparado para funcionar con:

- Jaeger para trazas distribuidas
- Serilog + Elastic + Kibana para logs centralizados
- OpenTelemetry para métricas y trazas

---

## 🧪 Testing
Soporte inicial para tests unitarios e integración.
Uso de Moq, NUnit y WebApplicationFactory.
Puedes probar comandos, queries y controladores con facilidad.

--- 

## 💬 Comandos útiles
```bash
# Crear comando
dotnet new command --name Nombre --feature NombreFeature

# Crear query
dotnet new query --name Nombre --feature NombreFeature
```
Estos comandos son posibles si implementas tus propios generadores a partir de esta plantilla base.

---

## 📌 Roadmap futuro
- Generador de eventos de dominio
- Soporte gRPC
- Generación automática de Dockerfiles y Helm charts
- Microservicio de ejemplo preconfigurado

---

## 🧠 Créditos y Autor
Plantilla creada y mantenida por @polhernan

---

## 📝 Licencia
Este proyecto está bajo la licencia MIT. Puedes usarlo libremente en proyectos personales y comerciales.