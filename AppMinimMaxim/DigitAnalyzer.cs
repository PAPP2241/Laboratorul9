using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppMinimMaxim
{
    public class DigitAnalyzer: DependencyObject
    {
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register(
                nameof(Number),
                typeof(string),
                typeof(DigitAnalyzer),
                new PropertyMetadata(string.Empty, OnNumberChanged)
                );

        private static void OnNumberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           var num = (DigitAnalyzer)d;
           var s = e.NewValue as string ?? string.Empty;
            var digit = s.Where(char.IsDigit).Select(c=>c - '0').ToList();

            if (digit.Count==0)
            {
                num.MaxDigit = null;
                num.MinDigit = null;
                return;
            }
            num.MaxDigit = digit.Max();
            num.MinDigit= digit.Min();
        }

        public string Number
        {
            get=> (string)GetValue(NumberProperty);
            set => SetValue(NumberProperty, value);
        }

        public static readonly DependencyProperty MaxDigitProperty =
            DependencyProperty.Register(
                nameof(MaxDigit),
                typeof(int?),
                typeof(DigitAnalyzer),
                new PropertyMetadata(null)
                );
        public int? MaxDigit
        {
            get=> (int?)GetValue(MaxDigitProperty);
            private set => SetValue(MaxDigitProperty, value);
        }

        public static readonly DependencyProperty MinDigitProperty =
            DependencyProperty.Register(
                nameof(MinDigit),
                typeof(int?),
                typeof(DigitAnalyzer),
                new PropertyMetadata(null)
                );
        public int? MinDigit
        {
            get=> (int?)GetValue(MinDigitProperty);
            set=> SetValue(MinDigitProperty, value);
        }

        public static readonly DependencyProperty ResultTextProperty =
            DependencyProperty.Register(
                nameof(ResultText),
                typeof(string),
                typeof(DigitAnalyzer),
                new PropertyMetadata(null)
                );
        public string ResultText
        {
            get => (string)GetValue(ResultTextProperty);
            set=> SetValue(ResultTextProperty, value);
        }
    }
}
