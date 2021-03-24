using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace LocalNote.Commands
{
    public class AddCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewModels.NotesViewModel notesViewModel;

        public AddCommand(ViewModels.NotesViewModel notesViewModel)
        {
            this.notesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            notesViewModel.SelectedNote = null;

            // Creates a blank page.
            notesViewModel.NoteTitle = "Untitled Note";
            new ContentDialog() { Title = "Create New Note Sucessfully.", PrimaryButtonText = "Okay."};
        }
    }
}
