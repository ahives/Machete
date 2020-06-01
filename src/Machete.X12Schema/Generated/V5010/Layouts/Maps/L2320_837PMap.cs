﻿namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class L2320_837PMap :
        X12LayoutMap<L2320_837P, X12Entity>
    {
        public L2320_837PMap()
        {
            Id = "2320";
            Name = "Other Subscriber Information";
            
            Segment(x => x.SubscriberInformation, 0);
            Segment(x => x.ClaimLevelAdjustments, 1);
            Segment(x => x.CoordinationOfBenefitsPayerPaidAmount, 2,
                x => x.Condition = parser => parser.Where(p => p.AmountQualifierCode.IsEqualTo("D")));
            Segment(x => x.CoordinationOfBenefitsTotalNonCoveredAmount, 3,
                x => x.Condition = parser => parser.Where(p => p.AmountQualifierCode.IsEqualTo("A8")));
            Segment(x => x.RemainingPatientLiability, 4,
                x => x.Condition = parser => parser.Where(p => p.AmountQualifierCode.IsEqualTo("EAF")));
            Segment(x => x.InsuranceCoverageInformation, 5);
            Segment(x => x.OutpatientAdjudicationInformation, 6);
            Layout(x => x.OtherSubscriber, 7);
            Layout(x => x.OtherPayer, 8);
            Layout(x => x.OtherPayerReferringProvider, 9);
            Layout(x => x.OtherPayerRenderingProvider, 10);
            Layout(x => x.OtherPayerServiceFacilityLocation, 11);
            Layout(x => x.OtherPayerSupervisingProvider, 12);
            Layout(x => x.OtherPayerBillingProvider, 13);
        }
    }
}