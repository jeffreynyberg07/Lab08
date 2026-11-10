// Name: Jeffrey Nyberg
using System;
class Program
{
    static void Main(string[] args)
    {
        // Part 1: create the lists
        List<string> playlist = new List<string> { "Yellow", "Halo", "Believer" };
        List<string> removedSongs = new List<string>();
        // Part 2: menu loop
        bool running = true;
        
        while (running)
        {
            Console.Write(@"
            === Playlist Manager ===
            1. Show playlist
            2. Add a song to the end
            3. Insert a song at a position
            4. Remove a song
            5. Move a song to a new position
            6. Search for a song
            7. Sort A to Z
            8. Reverse the order
            9. Undo last remove (bonus)
            0. Quit
            Choose an option: ");
            string choice = Console.ReadLine();
            
            string song_name;
            int position;
            string search_word;

            if (choice == "1")
            {
                PrintPlaylist(playlist);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Song: ");
                song_name = Console.ReadLine();
                AddSong(playlist,song_name);
            }
            else if (choice == "3")
            {
                Console.WriteLine("Song: ");
                song_name = Console.ReadLine();
                Console.WriteLine("Position (1-"+playlist.Count+1+"): ");
                position = int.Parse(Console.ReadLine());
                InsertSong(playlist,song_name,position);
            }
            else if (choice == "4")
            {
                Console.WriteLine("Song: ");
                song_name = Console.ReadLine();
                RemoveSong(playlist,removedSongs,song_name);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Song: ");
                song_name = Console.ReadLine();
                Console.WriteLine("Position: ");
                position = int.Parse(Console.ReadLine());
                MoveSong(playlist,song_name,position);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Enter a keyword: ");
                search_word = Console.ReadLine();
                SearchSongs(playlist, search_word);    
            }
            else if (choice == "7")
            {
               playlist.Sort();
            }
            else if (choice == "8")
            {
               playlist.Reverse();
            }
            else if (choice == "9")
            {
               
            }
            else if (choice == "0")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else{Console.WriteLine("PLease choose 0 to 9.");}

        }
    }
    static void PrintPlaylist(List<string> songs)
    {
        if (songs.Count == 0)
        {
            Console.WriteLine("The Playlist is empty.");
            return;
        }
        for (int i = 0; i < songs.Count; i++)
        {
            Console.WriteLine(i+1 + ". " + songs[i]);
        }
        Console.WriteLine("Total songs: " + songs.Count);
    }
    static void AddSong(List<string> songs, string song)
    {
        if (songs.Contains(song))
        {
            Console.WriteLine(song + " is already in the playlist.");
            return;
        }
        songs.Add(song);
        Console.WriteLine(song + " was added.");
    }
    static void InsertSong(List<string> songs, string song, int position)
    {
        if (songs.Contains(song))
        {
            Console.WriteLine(song + " is already in the playlist.");
            return;
        }
        if (position < 1 || position > songs.Count+1)
        {
            Console.WriteLine("Position must be from 1 to " + songs.Count+1);
            return;
        }
        songs.Insert(position-1,song);
        Console.WriteLine(song + " was added at position " + position);
        //position is -1 so it fits into the index
    }
    static void RemoveSong(List<string> songs, List<string> removedSongs, string song)
    {
        bool remove_check = songs.Remove(song);
        if (remove_check)
        {
            Console.WriteLine(song + " was removed.");
            removedSongs.Add(song);
        }
        else{Console.WriteLine(song + "is not in the playlist");}
    }

    static void MoveSong(List<string> songs, string song, int newPosition)
    {
        // DEBUG MOVE SONG
        if ((newPosition < 1) || (newPosition > songs.Count))
        {Console.WriteLine("Position must be from 1 to " + songs.Count); return;}
        if (songs.Contains(song) == false) {Console.WriteLine(song + " is not inthe playlist.");}
        // Remove song at the index it is in, and then insert that song into the new position
        songs.RemoveAt(songs.IndexOf(song));
        songs.Insert(newPosition-1,song);
        Console.WriteLine(song + " moved to position " + newPosition);
    }
    static void SearchSongs(List<string> songs, string word)
    {
        int songs_found = 0;
        for (int i = 0; i < songs.Count; i++)
        {
            if (songs[i].ToLower() == word.ToLower())
            {
                songs_found++;
                Console.WriteLine(i + ". " + songs[i]);
            }
        }
        if (songs_found == 0)
        {
            Console.WriteLine("No songs found.");
        }
        else
        {
        Console.WriteLine(songs_found + " song(s) found.");   
        }
    }
}