namespace CreateZF_BPProject
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using UFSoft.UBF.AopFrame;
    using UFSoft.UBF.Util.Context;
    using UFIDA.U9.ISV.MiscShipISV;
    using UFIDA.U9.CBO.Pub.Controller;
    using UFSoft.UBF.Exceptions;
    using UFSoft.UBF.Business;
    using UFIDA.U9.InvDoc.MiscRcv;
    using UFIDA.U9.Base.Organization;
    using UFIDA.U9.CBO.SCM.Warehouse;
    using UFIDA.U9.CBO.SCM.Item;
    using UFIDA.U9.Base.Currency;
    using UFIDA.U9.Base.UOM;
    using UFIDA.U9.Base.SOB;

    /// <summary>
    /// CreateZf partial 
    /// </summary>	
    public partial class CreateZf
    {
        internal BaseStrategy Select()
        {
            return new CreateZfImpementStrategy();
        }
    }

    #region  implement strategy	
    /// <summary>
    /// Impement Implement
    /// 
    /// </summary>	
    internal partial class CreateZfImpementStrategy : BaseStrategy
    {
        public CreateZfImpementStrategy() { }
        
        public override object Do(object obj)
        {
            try
            {
                //   CreateZf bpObj = (CreateZf)obj;

                //get business operation context is as follows
                // IContext context = ContextManager.Context;
              //  MiscRcvTrans miscRcvTrans = new MiscRcvTrans();
                using (ISession session =Session.Open())
                {

                    // session.Create(miscRcvTrans);
                    MiscRcvTrans miscRcvTrans = MiscRcvTrans.Create();                 
                    Organization organization = Organization.Finder.Find("Code=@Code", new UFSoft.UBF.PL.OqlParam("801")); 
                    MiscRcvDocType miscRcvDocType = MiscRcvDocType.Finder.Find("ID=1001007141248361");
                    miscRcvTrans.MiscRcvDocType = miscRcvDocType;
                    miscRcvTrans.BusinessDate = DateTime.Now;                    
                    miscRcvTrans.SOBAccountPeriod = SOBAccountingPeriod.Finder.FindByID(1001903313523016);
                    miscRcvTrans.Org = organization; 
                    
                    MiscRcvTransL rcvTransL = MiscRcvTransL.Create(miscRcvTrans);                     
                    rcvTransL.DocLineNo = 10;
                    rcvTransL.ItemInfo = new UFIDA.U9.CBO.SCM.Item.ItemInfo()
                    {
                        ItemID = ItemMaster.Finder.Find("Org=" + organization.ID + " and Code='4-14-13'")


                    };
                    rcvTransL.Org = organization; 
                    
                    rcvTransL.CostPrice = 1;
                    rcvTransL.CostMny = 1;
                    rcvTransL.BenefitOwnerOrg= organization;
                    rcvTransL.SobCurrency = Currency.FindByCode("C001");
                    rcvTransL.StoreUOM = UOM.FindByCode("PCS");
                    rcvTransL.SUToCURate = 1;
                    rcvTransL.SUToSBURate = 1;
                    rcvTransL.SUTOSMURate = 1;
                    rcvTransL.CostUOM= UOM.FindByCode("PCS");
                    rcvTransL.TradeUOM = UOM.FindByCode("PCS");
                    rcvTransL.StoreType = UFIDA.U9.CBO.Enums.StorageTypeEnum.Useable;
                    rcvTransL.StoreBaseUOM = UOM.FindByCode("PCS");
                    rcvTransL.CostBaseUOM = UOM.FindByCode("PCS");
                    rcvTransL.BenefitWh= Warehouse.Finder.Find("ID=1001007148477420");

                    rcvTransL.OwnerOrg = organization;
                    rcvTransL.BenefitOrg = organization;
                    rcvTransL.StoreUOMQty = 1;                    
                    rcvTransL.Wh = Warehouse.Finder.Find("ID=1001007148477420");                    
                     //rcvTransL.IsZeroCost = true;
                    //MiscRcvTrans miscRcvTrans = MiscRcvTrans.Finder.FindByID(1001712054171238);
                    //miscRcvTrans.Memo = "yuchengren is a good man";
                    //session.Modify(miscRcvTrans);
                    session.Commit();
                }

                return "成功";
                
              //  CommonCreateMiscShip miscShip = new CommonCreateMiscShip();
                //CommonUnApporveMiscShipSV miscShipSV = new CommonUnApporveMiscShipSV()
                //{
                //    MiscShipmentKeyList = new List<CommonArchiveDataDTO>()
                //     {
                //          new CommonArchiveDataDTO()
                //          {
                //               Code = "Mis2009120007"

                //          }


                //     }



                //};

                //miscShip.ContextFrom = new ContextDTO()
                //{
                //    CultureName = context["CultureName"].ToString(),
                //    EntCode = context["EntCode"].ToString(),
                //    OrgID = long.Parse(context["OrgID"].ToString()),
                //    UserID = long.Parse(context["UserID"].ToString())

                //};
                //    miscShip.MiscShipmentDTOList = new List<IC_MiscShipmentDTO>()
                //{
                //     new IC_MiscShipmentDTO()
                //        {
                //             Org=new CommonArchiveDataDTO(){ID=miscShip.ContextFrom.OrgID},
                //              BenefitOrg= miscShip.ContextFrom.OrgID,
                //              MiscShipDocType= new CommonArchiveDataDTO(){ Code="MiscShip001"},
                //               MiscShipLs=new List<IC_MiscShipmentLDTO>()
                //               {
                //                    new IC_MiscShipmentLDTO()
                //                    {
                //                         OwnerOrg=new CommonArchiveDataDTO(){ID=miscShip.ContextFrom.OrgID},
                //                         BenefitOrg=miscShip.ContextFrom.OrgID,
                //                         ItemInfo =new UFIDA.U9.CBO.SCM.Item.ItemInfo(){ ItemCode="1-03-14" },
                //                         StoreUOMQty=1,
                //                         IsZeroCost=true,
                //                         SysState =  UFSoft.UBF.PL.Engine.ObjectState.Inserted,
                //                         Wh =new CommonArchiveDataDTO(){ Code="inv2002"},
                //                         HandleDept =new CommonArchiveDataDTO(){ Code="101"}

                //                    }




                //               }


                //        }


                //};
                //  return miscShip.Do();
              //return  miscShipSV.Do();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
          
            //auto generating code end,underside is user custom code
            //and if you Implement replace this Exception Code...
            //throw new NotImplementedException();
        }
    }

    #endregion


}