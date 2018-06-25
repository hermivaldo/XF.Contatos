using System;
namespace XF.CONTATO.API
{
    public interface ILocalizacao
    {
        void GetCoordenada();
        void GetCoordenadaMapa();
    }

    public class Coordenada {
        public string Lat { get; set; }
        public string Lon { get; set; }
    }
}
