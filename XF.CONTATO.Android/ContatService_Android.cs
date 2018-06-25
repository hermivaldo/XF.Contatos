using System;
using Android.Provider;
using Xamarin.Forms;
using System.Collections.Generic;
using XF.CONTATO.Entity;
using XF.CONTATO.Droid;

[assembly: Dependency(typeof(ContatService_Android))]
namespace XF.CONTATO.Droid{
    
    public class ContatService_Android : IContacList
    {
        public IEnumerable<ContatoE> GetContatoEs(){
            var contatos = new List<ContatoE>();

            using (var telefones = Android.App.Application.Context.ContentResolver.Query(
                ContactsContract.CommonDataKinds.Phone.ContentUri,
                null, null, null, null)){
                if (telefones != null){
                    while (telefones.MoveToNext()){
                        string name = telefones.GetString(telefones.GetColumnIndex(
                            ContactsContract.Contacts.InterfaceConsts.DisplayName));

                        string fotoUri = telefones.GetString(telefones.GetColumnIndex(
                            ContactsContract.Contacts.InterfaceConsts.PhotoUri));

                        string telefone = telefones.GetString(telefones.GetColumnIndex(
                            ContactsContract.CommonDataKinds.Phone.Number));

                        string[] nm = name.Split(' ');
                        var contato = new ContatoE();
                        contato.FirstName = nm[0];

                        if (nm.Length > 1)
                        {
                            contato.LastName = nm[1];
                        }
                        else
                            contato.LastName = "";

                        contato.PhoneNumber = telefone;
                        contato.PhotoUri = fotoUri;
                        contatos.Add(contato);
                    }
                }
                telefones.Close();
            }
            return contatos;
        }

      
    }
}
