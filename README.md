# SG_MAUI_RamSerDav_

## Descripci�n

El programa consiste en realizar un ejercicio propuesto con el IDE Visual Studio y usando Maui (*.NET Multi-platform App UI*), que es una tecnolog�a de Microsoft que permite desarrollar aplicaciones de interfaz de usuario multiplataforma utilizando el lenguaje de programaci�n C# y el framework .NET. Este ejercicio consta de 3 ventanas diferenciadas: *Login*, *Gesti�n de Usuarios* y *PPrincipal*.

### Enunciado Completo

Se encuentra dentro del repositorio en el nivel 0, su nombre es "11. Aplicaci�n *NET MAUI con acceso a SQLITE.pdf*"

## Instalaci�n

Para iniciar el proyecto debemos descargar el proyecto Master y, al iniciar en el IDE, seleccionar el archivo SG_MAUI_RamSerDav_.sln de la carpeta "SG_MAUI_RamSerDav_".

## Prerrequisitos

- Visual Studio con soporte para desarrollo de aplicaciones m�viles con .NET MAUI.
- SDK de .NET 6 (m�nimo).

## Pasos de Instalaci�n

1. Clona el repositorio: `git clone https://github.com/SergioAlmagre/SG_MAUI_RamSerDav_`
2. Abre el proyecto en Visual Studio.
3. Compila y ejecuta la aplicaci�n.

## Uso

El funcionamiento de la aplicaci�n se divide en tres Ventanas:

### P�gina de Login

La p�gina inicial de la aplicaci�n es un formulario de inicio de sesi�n que consta de los siguientes elementos:

- Una imagen seleccionada por el alumno.
- Dos campos de entrada ("Entry") para el nombre de usuario y la contrase�a. El campo de contrase�a debe mostrar asteriscos al escribir.
- Dos botones: "Aceptar" y "Limpiar".

El bot�n "Limpiar" elimina el contenido de los campos de entrada.

El bot�n "Aceptar" solo est� activo cuando se ha ingresado contenido v�lido en ambos campos de entrada.

El bot�n de "Salir" iniciar� una ventana emergente de "S�" o "No". Si se selecciona "S�", se cerrar� el programa.

El comportamiento del bot�n "Aceptar" depende de si hay registros de usuarios en la base de datos de la aplicaci�n:
- Si no hay registros, se inserta un nuevo usuario con la informaci�n proporcionada y se muestra la p�gina principal de la aplicaci�n.
- Si hay registros, se verifica si el nombre de usuario y la contrase�a coinciden con alg�n registro existente. Si coinciden, se muestra la p�gina principal de la aplicaci�n.

Ninguna de las ventanas muestra la barra de navegaci�n.

### P�gina Principal

La p�gina principal muestra dos botones de imagen ("ImageButton") para realizar las siguientes acciones:
- Gesti�n de Usuarios
- Salir

### P�gina de Gesti�n de Usuarios

Esta p�gina permite gestionar los usuarios de la aplicaci�n e incluye:
- Controles para ingresar y modificar los datos de los usuarios.
- Botones para guardar y eliminar usuarios.
- Una lista de usuarios que se actualiza autom�ticamente cuando se realizan cambios.
- Selecci�n de un usuario para editar sus datos.

La p�gina de gesti�n de usuarios permite volver a la p�gina principal.

Para interactuar con la aplicaci�n:

1. Inicia sesi�n, introduce un usuario y contrase�a que cumpla las condiciones de la l�gica respectivamente, finalmente si existe el usuario ya en la base de datos ir� a la siguiente pesta�a, en caso contrario preguntar� si desea registrarse e ir� a la siguiente ventana.
2. Desde la p�gina principal, selecciona una acci�n.
3. Realiza las acciones correspondientes en la p�gina de gesti�n de usuarios.
4. Si deseas salir, puedes hacerlo usando cualquiera de los botones de navegaci�n, ya que existe una navegaci�n completa entre ventanas.

### Tareas Extras

- Degradado de fondo de pantalla en la p�gina inicial.
- Posibilidad de cambiar el Tema (Claro a Oscuro).
- Atributo Extra al Modelo Usuario, esDelegado.
- Este atributo aportar� una nueva funcionalidad en la Ventana Gesti�n de Usuarios. El usuario podr� cambiar a Delegado seleccionando en la checkBox.
- Expresiones regulares para los campos de Contrase�a y Email en las ventanas Login y P�gina de Gesti�n de Usuarios.
- Realizado un "Selector" para pintar las CardView de los Usuarios que son Delegados.
- Eventos de ventanas emergentes cuando la opci�n se requiera.
- Cifrado de contrase�as para aumentar la seguridad de las contrase�as de nuestros usuarios.
- Conversor de los datos Booleans a texto.

## Caracter�sticas Usadas


# Licencia
Este proyecto est� bajo la Licencia MIT.
Para realizarlo se ha necesitado de una cuenta *Github Pro* para usar *Gitkraken Pro*

# Contacto
Master: [Sergio Almagre](https://github.com/SergioAlmagre)
Colaboradores: 
	[DavidAM00](https://github.com/DavidAM00), 
	[ralmodovarl01](https://github.com/ralmodovarl01)
			  
Enlace al proyecto: [SG_MAUI_RamSerDav_](https://github.com/SergioAlmagre/SG_MAUI_RamSerDav_)
