using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailComposer.Mail
{
    class MessageModel
    {
        private List<string> _To;
        private string _From;
        private List<string> _Attachments;
        private string _Subject;
        private string _Body;

        public List<string> To
        {
            get
            {
                return this._To;
            }
            set
            {
                this._To = value;
            }

        }

        public List<string> Attachments
        {
            get
            {
                return this._Attachments;
            }
            set
            {
                this._Attachments = value;
            }

        }

        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }

        public string Body
        {
            get
            {
                return this._Body;
            }
            set
            {
                this._Body = value;
            }

        }

        public string From
        {
            get
            {
                return this._From;
            }
            set
            {
                this._From = value;
            }

        }
    }
}
