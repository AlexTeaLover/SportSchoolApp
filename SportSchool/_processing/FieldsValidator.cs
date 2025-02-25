using System.Windows.Controls;
using System.Windows.Media;

namespace SportSchool._processing
{
    public class FieldsValidator
    {
        public static bool IsValid(List<TextBox> textBoxes)
        {
            bool isValid = true;

            foreach (var item in textBoxes)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    item.BorderBrush = Brushes.Red;
                    isValid = false;
                }
                else
                {
                    item.BorderBrush = Brushes.Black;
                }
            }

            return isValid;
        }
    }
}
