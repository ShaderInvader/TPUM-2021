using System.Threading.Tasks;
using System.Windows.Input;

namespace PresentationLayer.ViewModels.Util.Interfaces
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
