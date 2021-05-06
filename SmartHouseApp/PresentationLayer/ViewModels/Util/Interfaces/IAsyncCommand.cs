using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientPresentationLayer.ViewModels.Util.Interfaces
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
