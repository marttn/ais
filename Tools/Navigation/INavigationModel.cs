using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Tools.Navigation
{
    internal enum ViewType
    {
        SignIn,
        SignUp,
        Admin,
        Designer, 
        //NewOrder,
        //NewCustomer,
        //NewCornices,
        //NewWorkshop,
        //NewContractor,
        //NewContractorTel,
        //NewSelContractorTel,
        //NewGoods,
        //NewContractorGoods,
        //NewOrderGoods,
        //NewContract,
        //NewContractGoods,
        //NewCustTel,
        //NewSelCustTel,
        //UpdOrder,
        //UpdCustomer,
        //UpdCornices,
        //UpdWorkshop,
        //UpdContractor,
        //UpdContractorTel,
        //UpdCustTel,
        //UpdGoods,
        //UpdContractorGoods,
        //UpdOrderGoods,
        //UpdContract,
        //UpdContractGoods
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
