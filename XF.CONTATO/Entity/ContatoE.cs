using System;
using System.Collections.Generic;

namespace XF.CONTATO.Entity
{
    public class ContatoE
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUri { get; set; }

        public string Nome { get => $"{FirstName} {LastName}"; }

    }

    public interface IContacList {

        IEnumerable<ContatoE> GetContatoEs();

    }
}
