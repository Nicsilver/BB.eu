using System;
using BB.eu.Shared.Models;

namespace BB.eu.Web.Data
{
    public class LoginState
    {
        public bool IsLoggedIn { get; set; }
        public Renter Renter { get; private set; } = new();
        public event Action OnChange;

        public void SetLogin(bool login, Renter renter)
        {
            IsLoggedIn = login;
            Renter = renter;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}