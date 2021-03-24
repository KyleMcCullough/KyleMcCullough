using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace LocalNote.Commands
{
    public class EditCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewModels.NotesViewModel notesViewModel;
        private bool newNote = false;

        public EditCommand(ViewModels.NotesViewModel notesViewModel)
        {
            this.notesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            TextBox box = (TextBox)parameter;

            // Resets the box to readonly mode if it is a new note.
            if (newNote)
            {
                box.IsReadOnly = true;
                newNote = false;
            }

            // Check if the box is in readonly mode.
            return box != null && box.IsReadOnly == true;
        }

        public void Execute(object parameter)
        {
            TextBox box = (TextBox)parameter;
            box.IsReadOnly = false;

            // Calls execute changed to disable button. Also calls the save command to refresh.
            notesViewModel.SaveCommand.FireCanExecuteChanged();
            FireCanExecuteChanged();
            return;
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangedNote()
        {
            newNote = true;
        }
    }
}
