using System;
using Xamarin.Forms;
using Plugin.Geolocator;
using XF.CONTATO.API;
using XF.CONTATO.Droid;

[assembly: Dependency(typeof(GeoLocation_Android))]
namespace XF.CONTATO.Droid
{
    public class GeoLocation_Android : ILocalizacao
    {

        async public void GetCoordenada(){
            var location = CrossGeolocator.Current;

            var position = await location.GetPositionAsync(TimeSpan.FromSeconds(10));

            var coordenada = new Coordenada()
            {
                Lat = position.Latitude.ToString(),
                Lon = position.Longitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordernada", coordenada);
        }

        async public void GetCoordenadaMapa()
        {
            var location = CrossGeolocator.Current;

            var position = await location.GetPositionAsync(TimeSpan.FromSeconds(10));

            var coordenada = new Coordenada()
            {
                Lat = position.Latitude.ToString(),
                Lon = position.Longitude.ToString()
            };
            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordernada_map", coordenada);
           
        }

    }
}
