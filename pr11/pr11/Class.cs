using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr11
{
    namespace TextEditorUsingPatternMemento
    {
        public interface TextInt
        {
            string Text { get; set; }
        }
        public class TextClass : TextInt
        {
            private string _text;
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

            private TextClassClone original = new TextClassClone();
            public TextClassClone Original
            {
                get { return original; }
                set { original = value; }
            }
            public void Revert()
            {
                this.Text = Original.Text;
            }
            public Boolean IsModified()
            {
                return !(this.Text.Equals(Original.Text));
            }
        }

        public class TextClassClone : TextInt
        {
            private string _text;
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }
        }
    }
}
