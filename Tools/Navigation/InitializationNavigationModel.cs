using ais.Views;
using ais.Views.AddingRows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.SignIn:
                    ViewsDictionary.Add(viewType, new SignInView());
                    break;
                case ViewType.SignUp:
                    ViewsDictionary.Add(viewType, new SignUpView());
                    break;
                case ViewType.Admin:
                    ViewsDictionary.Add(viewType, new AdminView());
                    break;
                case ViewType.Designer:
                    ViewsDictionary.Add(viewType, new DesignerView());
                    break;
                case ViewType.NewOrder:
                    ViewsDictionary.Add(viewType, new NewOrderView());
                    break;
                case ViewType.NewCustomer:
                    ViewsDictionary.Add(viewType, new NewCustomerView());
                    break;
                case ViewType.NewCornices:
                    ViewsDictionary.Add(viewType, new NewCornicesView());
                    break;
                case ViewType.NewWorkshop:
                    ViewsDictionary.Add(viewType, new NewWorkshopView());
                    break;
                case ViewType.NewContractor:
                    ViewsDictionary.Add(viewType, new NewContractorView());
                    break;
                case ViewType.NewContractorTel:
                    ViewsDictionary.Add(viewType, new NewContractorTelView());
                    break;
                case ViewType.NewGoods:
                    ViewsDictionary.Add(viewType, new NewGoodsView());
                    break;
                case ViewType.NewContractorGoods:
                    ViewsDictionary.Add(viewType, new NewContractorGoodsView());
                    break;
                case ViewType.NewOrderGoods:
                    ViewsDictionary.Add(viewType, new NewOrderGoodsView());
                    break;
                case ViewType.NewContract:
                    ViewsDictionary.Add(viewType, new NewContractView());
                    break;
                case ViewType.NewContractGoods:
                    ViewsDictionary.Add(viewType, new NewContractGoodsView());
                    break;
                case ViewType.NewCustTel:
                    ViewsDictionary.Add(viewType, new CustTelView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
