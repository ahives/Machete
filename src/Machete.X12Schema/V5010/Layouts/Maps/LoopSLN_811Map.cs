namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopSLN_811Map :
        X12LayoutMap<LoopSLN_811, X12Entity>
    {
        public LoopSLN_811Map()
        {
            Id = "Loop SLN 811";
            Name = "Loop SLN";

            Segment(x => x.SublineItemDetail, 0);
            Segment(x => x.ServiceCharacteristicIdentification, 1);
            Segment(x => x.ProductItemDescription, 2);
            Segment(x => x.Measurements, 3);
            Segment(x => x.Currency, 4);
            Segment(x => x.InstallmentInformation, 5);
            Segment(x => x.AllowanceChargeOrService, 6);
            Segment(x => x.TaxInformation, 7);
            Segment(x => x.ReferenceInformation, 8);
            Segment(x => x.AdministrativeCommunicationsContact, 9);
            Segment(x => x.DateTimeReference, 10);
            Segment(x => x.MonetaryAmountInformation, 11);
            Segment(x => x.MessageInformation, 12);
            Layout(x => x.LoopQty, 13);
            Layout(x => x.LoopNM1, 14);
        }
    }
}