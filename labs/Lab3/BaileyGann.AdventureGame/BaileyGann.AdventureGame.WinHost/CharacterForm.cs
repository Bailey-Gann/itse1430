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
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }
        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _ddlProfession.Text = Character.Proffesion;
                _ddlRace.Text = Character.Race;
                _txtStrength.Text = Character.Strength.ToString();
                _txtIntelligence.Text = Character.Intelligence.ToString();
                _txtConstitution.Text = Character.Constitution.ToString();
                _txtDexterity.Text = Character.Dexterity.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
                _txtDescription.Text = Character.Description;
            }
        }

        private void OnSave ( object sender, EventArgs e )
        {
            //Create the Character
            var character = new Character();

            //Set properties from UI
            character.Name = _txtName.Text;
            character.Proffesion = _ddlProfession.Text;
            character.Race = _ddlRace.Text;
            character.Strength = ReadAsInt32(_txtStrength, -1);
            character.Intelligence = ReadAsInt32(_txtIntelligence, -1);
            character.Constitution = ReadAsInt32(_txtConstitution, -1);
            character.Dexterity = ReadAsInt32(_txtDexterity, -1);
            character.Charisma = ReadAsInt32(_txtCharisma, -1);
            character.Description = _txtDescription.Text;

            //Validate : Check
           if(ObjectValidator.TryValidateObject(character, out var errors))
            {
                Character = character;
                DialogResult = DialogResult.OK;
                Close();
                return;
            };

            //Display Error
            MessageBox.Show(this, "Movie is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private int ReadAsInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var result))
                return result;

            return defaultValue;
        }

        private void OnAttributeCheck ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            var value = ReadAsInt32(control, -1);
            if (value < 0 || value > 100)
            {
                _errors.SetError(control, $"Attributes must be between 0 and 100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnNameValidating ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnProfessionCheck ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if(String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Profession is required");
                e.Cancel = true;
            }
             else
                _errors.SetError(control, "");
        }

        private void OnRaceCheck ( object sender, CancelEventArgs e )
        {
            var control = sender as Control;
            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "Race is required");
                e.Cancel = true;
            }
            else
                _errors.SetError(control, "");
        }
    }
}
