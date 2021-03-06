﻿using ais.Views;
using ais.Views.AddingRows;
using ais.Views.UpdatingRows;
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
                //case ViewType.NewOrder:
                //    ViewsDictionary.Add(viewType, new NewOrderView());
                //    break;
                //case ViewType.NewCustomer:
                //    ViewsDictionary.Add(viewType, new NewCustomerView());
                //    break;
                //case ViewType.NewCornices:
                //    ViewsDictionary.Add(viewType, new NewCornicesView());
                //    break;
                //case ViewType.NewWorkshop:
                //    ViewsDictionary.Add(viewType, new NewWorkshopView());
                //    break;
                //case ViewType.NewContractor:
                //    ViewsDictionary.Add(viewType, new NewContractorView());
                //    break;
                //case ViewType.NewContractorTel:
                //    ViewsDictionary.Add(viewType, new NewContractorTelView());
                //    break;
                //case ViewType.NewGoods:
                //    ViewsDictionary.Add(viewType, new NewGoodsView());
                //    break;
                //case ViewType.NewContractorGoods:
                //    ViewsDictionary.Add(viewType, new NewContractorGoodsView());
                //    break;
                //case ViewType.NewOrderGoods:
                //    ViewsDictionary.Add(viewType, new NewOrderGoodsView());
                //    break;
                //case ViewType.NewContract:
                //    ViewsDictionary.Add(viewType, new NewContractView());
                //    break;
                //case ViewType.NewContractGoods:
                //    ViewsDictionary.Add(viewType, new NewContractGoodsView());
                //    break;
                //case ViewType.NewCustTel:
                //    ViewsDictionary.Add(viewType, new CustTelView());
                //    break;
                //case ViewType.NewSelCustTel:
                //    ViewsDictionary.Add(viewType, new SelectCustTel());
                //    break;
                //case ViewType.NewSelContractorTel:
                //    ViewsDictionary.Add(viewType, new SelectContractorTel());
                //    break;
                //case ViewType.UpdOrder:
                //    ViewsDictionary.Add(viewType, new UpdOrderView());
                //    break;
                //case ViewType.UpdCustomer:
                //    ViewsDictionary.Add(viewType, new UpdCustomerView());
                //    break;
                //case ViewType.UpdCornices:
                //    ViewsDictionary.Add(viewType, new UpdCornicesView());
                //    break;
                //case ViewType.UpdWorkshop:
                //    ViewsDictionary.Add(viewType, new UpdWorkshopView());
                //    break;
                //case ViewType.UpdContractor:
                //    ViewsDictionary.Add(viewType, new UpdContractorView());
                //    break;
                //case ViewType.UpdContractorTel:
                //    ViewsDictionary.Add(viewType, new UpdContractorTel());
                //    break;
                //case ViewType.UpdGoods:
                //    ViewsDictionary.Add(viewType, new UpdGoodsView());
                //    break;
                //case ViewType.UpdContractorGoods:
                //    ViewsDictionary.Add(viewType, new UpdContractorGoodsView());
                //    break;
                //case ViewType.UpdOrderGoods:
                //    ViewsDictionary.Add(viewType, new UpdOrderGoodsView());
                //    break;
                //case ViewType.UpdContract:
                //    ViewsDictionary.Add(viewType, new UpdContractView());
                //    break;
                //case ViewType.UpdContractGoods:
                //    ViewsDictionary.Add(viewType, new UpdContractGoodsView());
                //    break;
                //case ViewType.UpdCustTel:
                //    ViewsDictionary.Add(viewType, new UpdCustTel());
                //    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
