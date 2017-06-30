using System.Linq;
using Xamarin.Forms;

namespace GestionServicios.Core.Behaviors
{
    public class EditorBehavior : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Editor bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var editor = ((Editor)sender);
            var newLinesCount = textChangedEventArgs.NewTextValue.ToCharArray().ToList().Count(c => c.Equals('\n'));
            editor.HeightRequest = 40 + 20 * newLinesCount;
        }
    }
}