using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                #region Menu Commands

        private void OnCharacterAdd (object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            _character = dlg.Character;
            UpdateUI();
        }

        private void OnCharacterEdit ( object sender, EventArgs e )
        {
            var menuItem = sender as ToolStripMenuItem;

            //Get selected Character
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            //Open selected Character
            var dlg = new CharacterForm();
            dlg.Character = character;

            if (dlg.ShowDialog(this) != DialogResult.OK)
                return;

            //Update _lstCharacter
            _character = dlg.Character;
            UpdateUI();
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
            _character = null;
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
            if (_character != null)
                _lstCharacters.Items.Add(_character);
        }

        private Character _character;

        #endregion

       
    }
}
