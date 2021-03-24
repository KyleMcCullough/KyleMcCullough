using LocalNote.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace LocalNote.Repository
{
    class NotesRepo
    {
        private static readonly StorageFolder folder = ApplicationData.Current.LocalFolder;

        public async static void SaveNotesToFile(NoteModel selected)
        {
            String fileName = selected.Title + ".txt";

            try
            {
                StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(file, selected.Content);
            }
            catch (Exception)
            {
                Debug.WriteLine("Error saving new note to folder.");
            }
        }

        // Loads all files into a list, then returns the list as a task.
        public async static Task<List<NoteModel>> LoadNotesFromFile()
        {

            // Loads all files.
            try
            {
                IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();
                List<NoteModel> fileInfoList = new List<NoteModel>();

                // Gets information from files and adds them to the list.
                foreach (StorageFile file in files)
                {
                    fileInfoList.Add(new NoteModel(file.DisplayName, await FileIO.ReadTextAsync(file)));
                }

                return fileInfoList;
            }
            catch (Exception)
            {
                Debug.Fail("Error loading note files from file system.");
                throw;
            }

        }

        public async static void DeleteNoteFile(string fileName)
        {
            try
            {
                StorageFile file = await folder.GetFileAsync(fileName);
                await file.DeleteAsync();
            }
            catch (Exception)
            {
                Debug.Fail("Error deleting note file from file system.");
            }

        }
    }
}
