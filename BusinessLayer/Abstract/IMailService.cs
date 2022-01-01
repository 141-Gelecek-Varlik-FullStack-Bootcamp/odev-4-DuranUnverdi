using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IMailService
    {
        void Send(Model.Email mail);
    }
}
