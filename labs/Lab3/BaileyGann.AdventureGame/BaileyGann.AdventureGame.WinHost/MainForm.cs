using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BaileyGann.AdventureGame.Memory;

namespace BaileyGann.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load ( object sender, EventArgs e )
        {

        }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);


            IEnumerable<Character> items = _characters.GetAll();
            if(!items.Any())
            {
                if(MessageBox.Show(this, "Do you want to seed the database?", "Seed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==DialogResult.Yes)
                {
                    _characters.Seed();
                    UpdateUI();
                }
            };
        }



        #region Menu Commands

        private void OnCharacterAdd (object sender, EventArgs e )
        {
            var dlg = new CharacterForm();

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Add(dlg.Character);
                if(String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                }

                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            //Get selected Character
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            //Open selected Character
            var dlg = new CharacterForm();
            dlg.Character = character;

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return;

                var error = _characters.Update(character.Id, dlg.Character);
                if(String.IsNullOrEmpty(error))
                {
                    UpdateUI();
                    return;
                };

                MessageBox.Show(this, error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
                      
        }
        private void OnCharacterDelete ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            //Confirm delete
            if (MessageBox.Show(this, $"Are you sure you want to delete {character.Name}?", "Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //Delete
            _characters.Delete(character.Id);
            UpdateUI();
        }

        #endregion

        #region Helper Functions
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var form = new AboutBox();
            form.ShowDialog(this);
        }

        private Character GetSelectedCharacter()
        {
            return _lstCharacters.SelectedItem as Character;
        }

        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            //Confirm exit
            DialogResult dr = MessageBox.Show(this, "Are you sure you want to quit?", "Quit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes)
                e.Cancel = true;

        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }
        private void UpdateUI()
        {
            _lstCharacters.Items.Clear();

            var characters = _characters.GetAll().OrderBy(x => x.Name).ThenBy(x => x.Id);
            
           
                _lstCharacters.Items.AddRange(characters.ToArray());
        }

        private readonly ICharacterRoster _characters = new MemoryCharacterRoster();

        #endregion

       
    }
}
