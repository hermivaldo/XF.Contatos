using System;
using XF.CONTATO.Droid;
using Xamarin.Forms;
using XF.CONTATO.API;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Telephony;

[assembly: Dependency(typeof(Ligar_Android))]
namespace XF.CONTATO.Droid
{
    public class Ligar_Android : ILigar
    {
        public bool Discar(string telefone){

            var context = MainApplication.CurrentContext as Activity;

            if (context == null) return false;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + telefone));

            context.StartActivity(intent);

            return true;
  
        }
    }
}
