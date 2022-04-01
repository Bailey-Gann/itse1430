﻿using System;
using System.Windows.Forms;

using MovieLib.Memory;

namespace MovieLib.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }


        #region Movie Commands
        //private void OnFormReset( object sender, EventArgs e)
        //{
        //    _movies = new MemoryMovieDatabase();

        //    if (MessageBox.Show(this, "Do you want to reset the database?", "Reset",
        //           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        //Seed database
        //        var seed = new SeedDatabase();
        //        seed.Seed(_movies);
        //        UpdateUI();
        //    };
        //}

        private void OnMovieAdd ( object sender, EventArgs e )
        {
            var dlg = new MovieForm();

            //Show modally - blocking call
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Save movie
                var error = _movies.Add(dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    dlg.Movie.Title = "Star Wars";
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieEdit ( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //TODO: Get selected movie
            var dlg = new MovieForm();
            dlg.Movie = movie;


            do
            {
                //Show modally - blocking call
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                //TODO: Update movie
                var error = _movies.Update(movie.Id, dlg.Movie);
                if (String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnMovieDelete ( object sender, EventArgs e )
        {
            //Get selected movie
            var movie = GetSelectedMovie();
            if (movie == null)
                return;

            //Confirm delete
            if (MessageBox.Show(this, $"Are you sure you want to delete {movie.Title}?", "Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //TODO: Delete
            _movies.Delete(movie.Id);
            UpdateUI();
        }
        #endregion

        #region Helper Functions
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if(_movies.GetAll().Length == 0)
            {
                if (MessageBox.Show(this, "Do you want to seed the database?", "Seed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Seed database
                    var seed = new SeedDatabase();
                    seed.Seed(_movies);
                    UpdateUI();
                };
            };
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            //Confirm exit
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to quit?", "Quit",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                e.Cancel = true;
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private Movie GetSelectedMovie ()
        {
            return _lstMovies.SelectedItem as Movie;
        }

        private void UpdateUI ()
        {
            _lstMovies.Items.Clear();

            var movies = _movies.GetAll();
            //BreakMovies(movies);

            _lstMovies.Items.AddRange(movies);
        }

        private void BreakMovies ( Movie[] movies )
        {
            if (movies.Length > 0)
            {
                var firstMovie = movies[0];

                ///movies[0] = new Movie();
                firstMovie.Title = "Star Wars";
            };
        }
        #endregion

        private readonly MemoryMovieDatabase _movies = new MemoryMovieDatabase();
    }
}
