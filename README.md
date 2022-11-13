# ProyAdmin

## Descripción
El proyecto está creado en ASP.NET Core 6. En donde se puede evidenciar las conexiones y las rutas protegidas para el correcto acceso del Usuario.
La manera en que fue creada esta aplicación es usando Autenthication & Authorization misma del Framework.

## Roles

Para poder usar los roles de Administrador y Cliente se utiliza la misma librería de Authorization del Framework. Lo que hace es agregar el Rol dentro de un Claims que después
se puede consultar y evaluar para que tengan ingresos especializados o para quitar permisos de visualización a las páginas que estén indicadas por el administrador

## Explicación del Core 

El administrador es el único que puede acceder a toda la información del sistema. Tanto a los Usuarios registrados como a los ejercicios asignados 
Por lo cual la autenticación se realiza para que el cliente no pueda acceder a la pestaña de Usuarios. Solo para que registre sus ejercicios. 


## Como instalar y ejecutar el proyecto 
El proyecto debe contener la última versión de ASP.NET Core, en este caso 6. Para poderlo ejecutar se debe cambiar las rutas de acceso a la base de datos dependiendo en el dispositivo donde se va a ejecutar. 
Se debe colocar el nombre del servidor dentro de: 
Connection String, que se encuentra en appsettings.json
Una vez que se haya realizado ese cambio. Se puede ejecutar el proyecto sin problemas.
## Ejemplos
### Cliente
Para poder usar la aplicación. Se puede acceder con el siguiente usuario como un cliente : 
Email: poncev625@gmail.com
Password: 248816

### Administrador

Para poder usar la aplicación. Se puede acceder con el siguiente usuario como un cliente : 
Email: administrador@gmail.com
Password: 248816


## Agradecimiento 
Para poder lograr completar este apartado de login y roles, seguí el tutorial de Código Estudiante. En donde con pautas he logrado adaptarlo para este proyecto. Te dejo el link de su video: https://www.youtube.com/watch?v=IvoDzgrjMOY&t=2467s
### Licencia 
GPL License: Permite que el código pueda ser modificado y usado con fines comerciales
