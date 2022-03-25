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

        private void OnSave ( object sender, EventArgs e )
        {
            //Create the Character
            var character = new Character();

            //Set properties from UI
            character.Name = _txtName.Text;
            character.Proffesion = _ddlProfession.Text;
            character.Race = _ddlRace.Text;
            character.Attributes[0] = ReadAsInt32(_txtStrength, -1);
            character.Attributes[1] = ReadAsInt32(_txtIntelligence, -1);
            character.Attributes[2] = ReadAsInt32(_txtConstitution, -1);
            character.Attributes[3] = ReadAsInt32(_txtDexterity, -1);
            character.Attributes[4] = ReadAsInt32(_txtCharisma, -1);
            character.Description = _txtDescription.Text;

            //Validate : Check
            var error = character.Validate();
            if(String.IsNullOrEmpty(error))
            {
                //Validate : Confirmed
                Character = character;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            //Display Error
            MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       
    }
}
