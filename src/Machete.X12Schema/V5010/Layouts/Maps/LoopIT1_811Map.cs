namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class LoopIT1_811Map :
        X12LayoutMap<LoopIT1_811, X12Entity>
    {
        public LoopIT1_811Map()
        {
            Id = "Loop IT1 811";
            Name = "Loop IT1";

            Segment(x=> x.BaseLineItemData, 0);
            Segment(x=> x.ServiceCharacteristicInformation, 1);
            Segment(x=> x.ProductItemDescription, 2);
            Segment(x=> x.Measurements, 3);
            Segment(x=> x.InstallmentInformation, 4);
            Segment(x=> x.TaxInformation, 5);
            Segment(x=> x.ReferenceInformation, 6);
            Segment(x=> x.DateTimeReference, 7);
            Segment(x=> x.MessageText, 8);
            Segment(x=> x.CarrierDetails, 9);
            Segment(x=> x.YesNoQuestion, 10);
            Segment(x=> x.IndustryCodeIdentification, 11);
            Segment(x=> x.PlaceLocationDescription, 12);
            Layout(x=> x.AMTLoop, 13);
            Layout(x=> x.QTYLoop, 14);
            Layout(x=> x.ITALoop, 15);
            Layout(x=> x.NM1Loop, 16);
        }
    }
}