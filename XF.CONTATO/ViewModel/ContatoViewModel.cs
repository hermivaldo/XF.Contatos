using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XF.CONTATO.Entity;
using XF.CONTATO.API;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace XF.CONTATO.ViewModel
{
    public class ContatoViewModel : INotifyPropertyChanged
    {
        public ContatoE contatoModel { get; set; }
        public IEnumerable<ContatoE> Contatos { get; private set; }

        public onCallCMD CallCMD { get; set; }
        public onEditCMD EditCMD { get; set; }

        public ContatoViewModel(){
            IContacList contatList = DependencyService.Get<IContacList>();

            try {
                this.Contatos = contatList.GetContatoEs();
            } catch {
                App.Current.MainPage.DisplayAlert("Error", "Falha ao carregar contatos", "OK");
            }

            this.CallCMD = new onCallCMD(this);
            this.EditCMD = new onEditCMD(this);

        }


        public async void Call(ContatoE contato){
            var resposta = await App.Current.MainPage.DisplayAlert("Voce está ligando para: ",
                                                                   $"tel: {contato.PhoneNumber}", "SIM", "NÃO");

            if (resposta){
                var telefone = DependencyService.Get<ILigar>();
                if (telefone != null) telefone.Discar(contato.PhoneNumber);
            }
        }

        public async void Edit(ContatoE contato){
            App.ContatoVM.contatoModel = contato;

            await App.Current.MainPage.Navigation.PushAsync(new ContatoView() { BindingContext = App.ContatoVM });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void EventPropertyChanged([CallerMemberName] string propertyName = null){
            if (this.PropertyChanged != null){
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class onCallCMD : ICommand{

        private ContatoViewModel contatoViewModel;

        public onCallCMD(ContatoViewModel paramVM){
            this.contatoViewModel = paramVM;
        }

        public event EventHandler CanExecuteChanged;
        public void LigarCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object param) => ((param != null) && (!string.IsNullOrWhiteSpace(((ContatoE)param).PhoneNumber)));
        public void Execute(object param){
            contatoViewModel.Call(param as ContatoE);
        }
    }

    public class onEditCMD : ICommand {
        private ContatoViewModel contatoViewModel;

        public onEditCMD(ContatoViewModel paramVM)
        {
            this.contatoViewModel = paramVM;
        }

        public event EventHandler CanExecuteChanged;
        public void LigarCanExecute() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object param) => ((param != null) && (!string.IsNullOrWhiteSpace(((ContatoE)param).PhoneNumber)));
        public void Execute(object param)
        {
            contatoViewModel.Edit(param as ContatoE);
        }
    }
}
