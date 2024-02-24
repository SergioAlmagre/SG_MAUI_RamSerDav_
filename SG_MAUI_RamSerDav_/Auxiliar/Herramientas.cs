using System.Text.RegularExpressions;

namespace SG_MAUI_RamSerDav_.Auxiliar
{
    /// <summary>
    /// Clase auxiliar que proporciona métodos de utilidad.
    /// </summary>
    class Herramientas
    {
        /// <summary>
        /// Constructor de la clase Herramientas.
        /// </summary>
        public Herramientas()
        {

        }

        /// <summary>
        /// Muestra un mensaje informativo de forma asíncrona.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        public static async Task MensajeInfomativoAsync(string mensaje)
        {
            //App.Current.MainPage.DisplayAlert("Información para el usuario", mensaje, "Aceptar");
            var currentPage = Application.Current.MainPage;
            await currentPage.DisplayAlert("Información", mensaje, "OK");
        }

        /// <summary>
        /// Verifica si un correo electrónico ya está en uso en la base de datos.
        /// </summary>
        /// <param name="email">Correo electrónico a verificar.</param>
        /// <returns>True si el correo electrónico está en uso, False si no lo está.</returns>
        public static bool CorreoElectronicoEnUso(string email)
        {
            var usuarioExistente = App.UsuarioRepo.GetItem(u => u.Email == email); // Obtener correo existente en bbdd
            return usuarioExistente != null;
        }

        /// <summary>
        /// Muestra un mensaje de confirmación de forma asíncrona.
        /// </summary>
        /// <param name="titulo">Título del mensaje de confirmación.</param>
        /// <param name="mensaje">Mensaje a mostrar en la confirmación.</param>
        /// <returns>True si se acepta la confirmación, False si se cancela.</returns>
        public static async Task<bool> MensajeConfirmacion(string titulo, string mensaje)
        {
            var currentPage = Application.Current.MainPage;
            return await currentPage.DisplayAlert(titulo, mensaje, "Aceptar", "Cancelar");
        }

        /// <summary>
        /// Encripta una contraseña utilizando desplazamiento de caracteres.
        /// </summary>
        /// <param name="password">Contraseña a encriptar.</param>
        /// <returns>Contraseña encriptada.</returns>
        public static string encriptarContraseña(string password)
        {
            char[] encryptedChars = new char[password.Length];

            for (int i = 0; i < password.Length; i++)
            {
                encryptedChars[i] = (char)(password[i] + 2);
            }

            return new string(encryptedChars);
        }

        /// <summary>
        /// Desencripta una contraseña encriptada con encriptarContraseña.
        /// </summary>
        /// <param name="password">Contraseña encriptada.</param>
        /// <returns>Contraseña desencriptada.</returns>
        public static string desencriptarContraseña(string password)
        {
            char[] decryptedChars = new char[password.Length];

            for (int i = 0; i < password.Length; i++)
            {
                decryptedChars[i] = (char)(password[i] - 2);
            }

            return new string(decryptedChars);
        }

        /// <summary>
        /// Valida un correo electrónico utilizando expresiones regulares.
        /// </summary>
        /// <param name="email">Correo electrónico a validar.</param>
        /// <returns>True si el correo es válido, False si no lo es.</returns>
        public static bool emailCumpleMascara(string email)
        {
            string emailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, emailPattern);
        }

        /// <summary>
        /// Valida una contraseña para que tenga al menos 6 caracteres, al menos 1 número y una letra mayúscula.
        /// </summary>
        /// <param name="password">Contraseña a validar.</param>
        /// <returns>True si la contraseña es válida, False si no lo es.</returns>
        public static bool passwordCumpleMascara(string password)
        {
            string passwordPattern = @"^(?=.*[A-Z])(?=.*\d).{6,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

    }
}