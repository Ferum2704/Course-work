
namespace LibraryWallet
{
    public delegate void AccountHandler(object sender, AccountEventArgs e);
    public class AccountEventArgs
    {
        public string Message { get; private set; }
        public AccountEventArgs(string someMessage)
        {
            Message = someMessage;
        }
    }
}
