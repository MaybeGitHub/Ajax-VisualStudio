using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;

namespace AJAX
{
    public class Autentificador
    {
        private string path = @"C:/Users/Maybe/Documents/GitHubVisualStudio/Ajax-VisualStudio/Ajax Visual Studio/AJAX/usuarios.txt";
        private string login;
        private string password;
        public string Login
        {
            get { return login; }
            set
            {
                login = File.ReadAllLines(path).Where(linea => linea.Split(':')[0] == value).Select(linea => linea.Split(':')[0]).SingleOrDefault();
                if ( login == null)
                {
                    salida += 2;
                }             
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = File.ReadAllLines(path).Where(linea => linea.Split(':')[1] == value).Select(linea => linea.Split(':')[1]).SingleOrDefault();
                if( login == null || password == null )
                {
                    salida += 1;
                }
            }
        }
        public int salida { get; set; }

        private string[] mensajes = new string[] { "Ok", "Password incorrecto", null, "No existe usuario" };

        public Autentificador()
        {
            salida = 0;
        }

        public override string ToString()
        {            
            return "{\"salida\":" + salida + ", \"mensaje\":\"" + mensajes[salida] + "\"}";
        }
    }
}