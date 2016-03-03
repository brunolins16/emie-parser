using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMIE.Parser.UI.Win.Utils
{
    public static class UserControlFactory
    {
        public static UserControls.BaseUserControl Instantiate(Utils.Steps step)
        {
            UserControls.BaseUserControl userControl = null;

            switch (step)
            {
                case Steps.FileUpload:
                    userControl = new UserControls.EMIEFileUploadControl();
                    break;
                case Steps.DomainFiltering:
                    userControl = new UserControls.DomainListControl();
                    break;
                case Steps.DuplicationClean:
                    userControl = new UserControls.DuplicateListControl();
                    break;
                case Steps.Download:
                   
                    break;
                default:
                    throw new ArgumentOutOfRangeException("step");
            }

            return userControl;
        }

    }
}
