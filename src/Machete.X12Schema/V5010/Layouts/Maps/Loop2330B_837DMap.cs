﻿namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class Loop2330B_837DMap :
        X12LayoutMap<Loop2330B_837D, X12Entity>
    {
        public Loop2330B_837DMap()
        {
            Id = "2330B";
            Name = "Other Payer Name";
            
            Segment(x => x.OtherPayer, 0, x => x.IsRequired());
            Segment(x => x.Address, 1);
            Segment(x => x.GeographicInformation, 2);
            Segment(x => x.ClaimCheckOrRemittanceDate, 3);
            Segment(x => x.SecondaryIdentification, 4,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("2U") ||
                                                               p.ReferenceIdentificationQualifier.IsEqualTo("EI") ||
                                                               p.ReferenceIdentificationQualifier.IsEqualTo("FY") ||
                                                               p.ReferenceIdentificationQualifier.IsEqualTo("NF")));
            Segment(x => x.PriorAuthorizationNumber, 5,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("G1")));
            Segment(x => x.ReferralNumber, 6,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("9F")));
            Segment(x => x.ClaimAdjustmentIndicator, 7,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("T4")));
            Segment(x => x.PredeterminationIdentification, 8,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("G3")));
            Segment(x => x.ClaimControlNumber, 9,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("F8")));
        }
    }
}