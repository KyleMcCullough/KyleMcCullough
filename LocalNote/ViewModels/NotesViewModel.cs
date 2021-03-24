using LocalNote.Commands;
using LocalNote.Models;
using LocalNote.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNote.ViewModels
{
    public class NotesViewModel : INotifyPropertyChanged
    {

        #region Variable Definitions
        public event PropertyChangedEventHandler PropertyChanged;


        public EditCommand EditCommand { get; }
        public DeleteCommand DeleteCommand { get; }
        public AddCommand AddCommand { get; }
        public SaveCommand SaveCommand { get; }
        public ExitCommand ExitCommand { get; }
        public AboutCommand AboutCommand { get; }

        public ObservableCollection<NoteModel> Notes { get; set; }
        public List<NoteModel> AllNotes { get; set; } = new List<NoteModel>();


        private NoteModel _selectedNote;
        public string NoteText { get; set; }
        public string NoteTitle { get; set; }

        private string _filter;

        public string Filter
        {
            get { return _filter; }

            set
            {
                if (value == Filter) return;

                _filter = value;
                FilterNotes();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filter"));
            }
        }

        public NoteModel SelectedNote
        {
            get { return _selectedNote; }

            set
            {
                if (value == null)
                {
                    _selectedNote = null;
                    NoteTitle = "";
                    NoteText = "";
                }

                else
                {
                    _selectedNote = value;
                    NoteText = value.Content;
                    NoteTitle = value.Title;
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoteText"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NoteTitle"));

                EditCommand.ChangedNote();
                EditCommand.FireCanExecuteChanged();

                DeleteCommand.FireCanExecuteChanged();
                SaveCommand.FireCanExecuteChanged();
            }
        }

        #endregion

        public NotesViewModel()
        {
            EditCommand = new EditCommand(this);
            DeleteCommand = new DeleteCommand(this);
            AddCommand = new AddCommand(this);
            SaveCommand = new SaveCommand(this);
            ExitCommand = new ExitCommand();
            AboutCommand = new AboutCommand();

            this.Notes = new ObservableCollection<NoteModel>();
            LoadNotes();
        }

        // ASync function to load all notes from the file system.
        public async void LoadNotes()
        {
            this.AllNotes = await NotesRepo.LoadNotesFromFile();
            FilterNotes();
        }

        public void FilterNotes()
        {
            if (_filter == null)
            {
                _filter = "";
            }

            // Changes search term to lowercase.
            var lowerCased = _filter.ToLowerInvariant().Trim();

            // Checks all note titles to see if the search term matches.
            var result = AllNotes.Where(n => n.Title.ToLowerInvariant()
                .Contains(lowerCased))
                .ToList();

            // Remove all instances that do not match the search term.
            var remove = Notes.Except(result).ToList();
            foreach (var x in remove)
            {
                Notes.Remove(x);
            }

            // Adds values back in the correct order it was previously in.
            var resultCount = result.Count;
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > Notes.Count || !Notes[i].Equals(resultItem))
                {
                    Notes.Insert(i, resultItem);
                }
            }
        }
    }
}
