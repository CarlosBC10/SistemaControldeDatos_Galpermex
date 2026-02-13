# Sistema de Control de Datos - Galpermex

Proyecto desarrollado como parte de las residencias profesionales en el Instituto Tecnológico de Ciudad Madero.  
El sistema web fue diseñado para la empresa **Galpermex**, con el objetivo de optimizar la gestión de empleados, clientes y clientes potenciales, integrando bitácoras de conexiones, reportes PDF y notificaciones automáticas vía correo electrónico.

---

## 🎯 Objetivo del proyecto
- Digitalizar procesos internos de la empresa.
- Reducir tiempos de gestión de clientes y empleados.
- Mejorar la trazabilidad mediante bitácoras de acciones y conexiones.
- Facilitar la comunicación con clientes potenciales mediante formularios y notificaciones.

---

## 🚀 Tecnologías utilizadas
**Lenguajes de programación:**
- C#
- SQL
- HTML
- CSS
- JavaScript

**Frameworks y arquitectura:**
- ASP.NET MVC Framework 5
- Entity Framework (para conexión con la base de datos)
- Arquitectura en capas (CapaDatos, CapaEntidad, CapaNegocio, Vistas)

**IDE y herramientas:**
- Visual Studio Community
- SQL Server Management Studio 2019

**Base de datos:**
- SQL Server Express
- 9 tablas principales: Empleados, Clientes, Roles, Acción, BitacoraConexiones, ContactoAsesores, Asunto_Contacto, ArchivosPDF, BitacoraArchivos
- Procedimientos almacenados para registro, edición, inicio/cierre de sesión, solicitudes de asesor

**Frontend y librerías:**
- HTML, CSS
- JavaScript
- Bootstrap
- jQuery
- jQuery Validate
- Modernizr
- FontAwesome

**Metodología de desarrollo:**
- Scrum (6 fases: análisis, diseño, implementación, pruebas, revisión/lanzamiento, mantenimiento)

---

## 👥 Roles y privilegios
- **Administrador:** CRUD de empleados y clientes, bitácoras, subir/eliminar archivos.  
- **Asesor:** CRUD de clientes, subir/descargar/eliminar archivos.  
- **Cliente:** Descargar archivos.  
- **Cliente potencial:** Enviar mensajes de solicitud vía formulario de contacto.  

---

## 📌 Funcionalidades principales
- Inicio de sesión con validación de credenciales y rol.  
- Registro, edición, habilitación/inhabilitación de empleados y clientes.  
- Bitácora de conexiones y acciones.  
- Gestión de reportes PDF (subida, descarga, eliminación).  
- Formulario de contacto para clientes potenciales con notificación automática vía correo electrónico.  

---

## 🌱 Interfaces del sistema
- **Login:** acceso por rol, correo y contraseña.  
- **Panel administrador:** gestión de empleados, clientes y bitácoras.  
- **Panel asesor:** gestión de clientes y reportes.  
- **Página de presentación:** formulario de contacto para clientes potenciales.  

---

## 💡 Experiencia adquirida
- Aplicación de arquitectura **MVC** en un entorno empresarial real.  
- Diseño de base de datos relacional con procedimientos almacenados para seguridad y eficiencia.  
- Implementación de bitácoras de conexiones y acciones para auditoría interna.  
- Manejo de roles y privilegios diferenciados.  
- Elaboración de **manual técnico y manual de usuario**, demostrando capacidad de documentación profesional.  
- Trabajo bajo metodología ágil **Scrum**, con entregas iterativas y validación continua.  

---

## 📄 Documentación
El proyecto cuenta con:
- **Manual Técnico:** análisis, diseño, base de datos, procedimientos, arquitectura y configuración.  
- **Manual de Usuario:** uso detallado de cada módulo (login, gestión de empleados/clientes, bitácoras, reportes, formulario de contacto).  
