using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTallerTEC
{
    /*
     * Clase UserSingleton
     * Esta clase utiliza el patron de diseno singleton para almacenar de manera unica el id del cliente que inicio sesion
     */
    public sealed class UserSingleton
    {
        //Constructor de la clase
        private UserSingleton() { }
        //Instancia singleton de la clase
        private static UserSingleton _instance;
        //Id del cliente
        public string Id { get; set; }
        //Instansiacion publica de la de la clase
        //Retorna una clase del tipo UserSingleton nueva o almacenada en el atributo _instance
        public static UserSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserSingleton();
            }
            return _instance;
        }

    }
}
