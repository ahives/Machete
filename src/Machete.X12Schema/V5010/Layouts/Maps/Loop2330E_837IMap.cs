﻿namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class Loop2330E_837IMap :
        X12LayoutMap<Loop2330E_837I, X12Entity>
    {
        public Loop2330E_837IMap()
        {
            Id = "Loop_2330E_837I";
            Name = "Other Payer Other Operating Physician";
            
            Segment(x => x.OtherPayerOperatingPhysician, 0);
            Segment(x => x.SecondaryIdentification, 1,
                x => x.Condition = parser => parser.Where(p => p.ReferenceIdentificationQualifier.IsEqualTo("0B") ||
                                                                            p.ReferenceIdentificationQualifier.IsEqualTo("1G") ||
                                                                            p.ReferenceIdentificationQualifier.IsEqualTo("G2") ||
                                                                            p.ReferenceIdentificationQualifier.IsEqualTo("LU")));
        }
    }
}