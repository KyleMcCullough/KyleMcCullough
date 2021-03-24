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
    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly ViewModels.NotesViewModel notesViewModel;

        public SaveCommand(ViewModels.NotesViewModel notesViewModel)
        {
            this.notesViewModel = notesViewModel;
        }

        public bool CanExecute(object parameter)
        {
            TextBox box = (TextBox)parameter;
            return box != null && box.IsReadOnly == false;
        }

        public async void Execute(object parameter)
        {


            SaveDialog saveDialog = new SaveDialog();
            ContentDialogResult result = await saveDialog.ShowAsync();

            // Creates an error message and returns.
            if (result != ContentDialogResult.Primary)
            {
                new ContentDialog() { Title = "Cancelled Creation.", PrimaryButtonText = "Okay." };
                return;
            }

            TextBox box = (TextBox)parameter;
            Models.NoteModel newNote = new Models.NoteModel(saveDialog.NoteTitle, box.Text);

            // Trys to save the new note to the file system.
            try
            {
                Repository.NotesRepo.SaveNotesToFile(newNote);
            }
            catch (Exception)
            {
                Debug.WriteLine("Error saving new note to folder.");
                return;
            }

            // Adds note to the list, changes the selected node, and refreshes the list visually.
            notesViewModel.AllNotes.Add(newNote);
            notesViewModel.SelectedNote = newNote;
            notesViewModel.FilterNotes();

            new ContentDialog() { Title = "Saved Note Sucessfully.", PrimaryButtonText = "Okay." };
        }
        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
