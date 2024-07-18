using System.Text.RegularExpressions;

namespace Logger
{
    public class EmailScrubber : AbstractScrubber
    {
        private EmailScrubber() { }

        private static EmailScrubber _Instance;

        public static EmailScrubber Instance => _Instance ?? (_Instance = new EmailScrubber());

        /// <summary>
        /// Regular expression for Email:
        /// FullName@gmail.com
        /// </summary>
        protected override Regex PIIRegEx => new Regex(@"[A-Za-z0-9]{3,}@[A-Za-z]{3,}.[a-z]{3,}");
        

        public override string Scrub(string content) => this.MaskPII(content, this.MaskLettersOrNumbers);
    }
}