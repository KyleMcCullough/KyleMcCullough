using LocalNote.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalNote.Commands
{
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewModels.NotesViewModel notesViewModel;

        public DeleteCommand(ViewModels.NotesViewModel notesViewModel)
        {
            this.notesViewModel = notesViewModel;
        }

        // Makes sure that the user cannot delete unsaved notes.
        public bool CanExecute(object parameter)
        {
            return notesViewModel.SelectedNote != null;
        }

        public void Execute(object parameter)
        {

            // Try to delete the file, both from the file system, and the active memory.
            try
            {
                NotesRepo.DeleteNoteFile(notesViewModel.SelectedNote.Title + ".txt");

                notesViewModel.AllNotes.Remove(notesViewModel.SelectedNote);
                notesViewModel.FilterNotes();
                notesViewModel.SelectedNote = null;
            }
            catch (Exception)
            {
                Debug.Fail("Error deleting note file from file system.");
            }
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
