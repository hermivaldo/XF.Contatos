using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

using XF.CONTATO.API;
using Plugin.MapsPlugin;

namespace XF.CONTATO
{
    public partial class ContatoView : ContentPage
    {
        public ContatoView()
        {
            InitializeComponent();
        }

        private void altera_imagem(object sender, EventHandler e){
            var photo = Plugin.Media.CrossMedia.Current.TakePhotoAsync(
               new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() =>
                {
                    return photo.Result.GetStream();
                });
            }


        }

        private void busca_coordenada(object sender, EventHandler e){
            ILocalizacao localizacao = DependencyService.Get<ILocalizacao>();
            localizacao.GetCoordenada();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>(this, "coordernada", (objecto, geo) =>
            {
                lbLatitude.Text = geo.Lat;
                lbLongitude.Text = geo.Lon;
            });
        }

        private void mostra_mapa(object sender, EventHandler e){
            ILocalizacao geo = DependencyService.Get<ILocalizacao>();

            geo.GetCoordenadaMapa();

            MessagingCenter.Subscribe<ILocalizacao, Coordenada>
            (this, "coordernada_map", (objecto, test) => {
                    CrossMapsPlugin.Current.PinTo("Contato",
                                                  Convert.ToDouble(test.Lat),
                                                  Convert.ToDouble(test.Lon), 7);
            });
        }
    }
}
