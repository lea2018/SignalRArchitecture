@'
# SignalRArchitecture

## Descripción
Proyecto desarrollado en .NET 10 para practicar la comunicación en tiempo real con SignalR. Permite enviar mensajes entre clientes conectados y separar las conversaciones mediante salas.

## Arquitectura del proyecto

La solución está dividida en tres proyectos:

- **SignalR.Hub:** servidor que administra las conexiones y distribuye los mensajes.
- **SignalR.Client:** aplicación web Razor Pages que permite seleccionar una sala y enviar mensajes.
- **SignalR.Shared:** contiene los contratos compartidos entre el servidor y el cliente.

## Tecnologías utilizadas

- C#
- .NET 10
- ASP.NET Core Razor Pages
- SignalR
- JavaScript
- Git y GitHub

## Funcionalidades implementadas

- Conexión en tiempo real entre clientes.
- Envío y recepción de mensajes.
- Selección entre las salas Desarrollo y Diseño.
- Distribución de mensajes únicamente a los participantes de la sala correspondiente.
- Validación del nombre de la sala, el usuario y el mensaje.
- Reconexión automática del cliente cuando la conexión se interrumpe.

## Requisitos

- .NET 10 SDK.
- Visual Studio o una terminal compatible con .NET.
- Un navegador web moderno.

## Cómo ejecutar el proyecto

Abre dos terminales en la carpeta raíz del repositorio.

### 1. Iniciar el servidor SignalR

```powershell
dotnet run --project SignalR.Hub --urls https://localhost:7001
