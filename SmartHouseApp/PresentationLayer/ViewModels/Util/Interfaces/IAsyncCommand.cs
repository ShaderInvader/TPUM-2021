using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientPresentationLayer.ViewModels
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
