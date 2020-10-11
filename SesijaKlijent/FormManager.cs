using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SesijaKlijent
{
    public class FormManager
    {

        public static readonly FormManager Instance = new FormManager();

        public List<Form> FormsOpened { get; set; }
        private FormManager()
        {
            FormsOpened = new List<Form>();
        }

        public void AddForm(Form form)
        {
            FormsOpened?.Add(form);
        }

        public void RemoveForm(Form form)
        {
            FormsOpened?.Remove(form);
        }

        public void ServerDown()
        {
            foreach (var item in FormsOpened)
            {
                item.Close();
            }
            FormsOpened?.Clear();
        }

    }
}
