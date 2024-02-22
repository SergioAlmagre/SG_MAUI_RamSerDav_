# SG_MAUI_RamSerDav_

## Descripción

El programa consiste en realizar un ejercicio propuesto con el IDE Visual Studio y usando Maui (*.NET Multi-platform App UI*), que es una tecnología de Microsoft que permite desarrollar aplicaciones de interfaz de usuario multiplataforma utilizando el lenguaje de programación C# y el framework .NET. Este ejercicio consta de 3 ventanas diferenciadas: *Login*, *Gestión de Usuarios* y *PPrincipal*.

### Enunciado Completo

Se encuentra dentro del repositorio en el nivel 0, su nombre es "11. Aplicación *NET MAUI con acceso a SQLITE.pdf*"

## Instalación

Para iniciar el proyecto debemos descargar el proyecto Master y, al iniciar en el IDE, seleccionar el archivo SG_MAUI_RamSerDav_.sln de la carpeta "SG_MAUI_RamSerDav_".

## Prerrequisitos

- Visual Studio con soporte para desarrollo de aplicaciones móviles con .NET MAUI.
- SDK de .NET 6 (mínimo).

## Pasos de Instalación

1. Clona el repositorio: `git clone https://github.com/SergioAlmagre/SG_MAUI_RamSerDav_`
2. Abre el proyecto en Visual Studio.
3. Compila y ejecuta la aplicación.

## Uso

El funcionamiento de la aplicación se divide en tres Ventanas:

### Página de Login

La página inicial de la aplicación es un formulario de inicio de sesión que consta de los siguientes elementos:

- Una imagen seleccionada por el alumno.
- Dos campos de entrada ("Entry") para el nombre de usuario y la contraseña. El campo de contraseña debe mostrar asteriscos al escribir.
- Dos botones: "Aceptar" y "Limpiar".

El botón "Limpiar" elimina el contenido de los campos de entrada.

El botón "Aceptar" solo está activo cuando se ha ingresado contenido válido en ambos campos de entrada.

El botón de "Salir" iniciará una ventana emergente de "Sí" o "No". Si se selecciona "Sí", se cerrará el programa.

El comportamiento del botón "Aceptar" depende de si hay registros de usuarios en la base de datos de la aplicación:
- Si no hay registros, se inserta un nuevo usuario con la información proporcionada y se muestra la página principal de la aplicación.
- Si hay registros, se verifica si el nombre de usuario y la contraseña coinciden con algún registro existente. Si coinciden, se muestra la página principal de la aplicación.

Ninguna de las ventanas muestra la barra de navegación.

### Página Principal

La página principal muestra dos botones de imagen ("ImageButton") para realizar las siguientes acciones:
- Gestión de Usuarios
- Salir

### Página de Gestión de Usuarios

Esta página permite gestionar los usuarios de la aplicación e incluye:
- Controles para ingresar y modificar los datos de los usuarios.
- Botones para guardar y eliminar usuarios.
- Una lista de usuarios que se actualiza automáticamente cuando se realizan cambios.
- Selección de un usuario para editar sus datos.

La página de gestión de usuarios permite volver a la página principal.

Para interactuar con la aplicación:

1. Inicia sesión, introduce un usuario y contraseña que cumpla las condiciones de la lógica respectivamente, finalmente si existe el usuario ya en la base de datos irá a la siguiente pestaña, en caso contrario preguntará si desea registrarse e irá a la siguiente ventana.
2. Desde la página principal, selecciona una acción.
3. Realiza las acciones correspondientes en la página de gestión de usuarios.
4. Si deseas salir, puedes hacerlo usando cualquiera de los botones de navegación, ya que existe una navegación completa entre ventanas.

### Tareas Extras

- Degradado de fondo de pantalla en la página inicial.
- Posibilidad de cambiar el Tema (Claro a Oscuro).
- Atributo Extra al Modelo Usuario, esDelegado.
- Este atributo aportará una nueva funcionalidad en la Ventana Gestión de Usuarios. El usuario podrá cambiar a Delegado seleccionando en la checkBox.
- Expresiones regulares para los campos de Contraseña y Email en las ventanas Login y Página de Gestión de Usuarios.
- Realizado un "Selector" para pintar las CardView de los Usuarios que son Delegados.
- Eventos de ventanas emergentes cuando la opción se requiera.
- Cifrado de contraseñas para aumentar la seguridad de las contraseñas de nuestros usuarios.
- Conversor de los datos Booleans a texto.

## Características Usadas


# Licencia
Este proyecto está bajo la Licencia MIT.
Para realizarlo se ha necesitado de una cuenta *Github Pro* para usar *Gitkraken Pro*

# Contacto
Master: [Sergio Almagre](https://github.com/SergioAlmagre)
Colaboradores: 
	[DavidAM00](https://github.com/DavidAM00), 
	[ralmodovarl01](https://github.com/ralmodovarl01)
			  
Enlace al proyecto: [SG_MAUI_RamSerDav_](https://github.com/SergioAlmagre/SG_MAUI_RamSerDav_)
