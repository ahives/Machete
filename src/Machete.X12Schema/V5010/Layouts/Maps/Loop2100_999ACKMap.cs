﻿namespace Machete.X12Schema.V5010.Maps
{
    using X12;
    using X12.Configuration;


    public class Loop2100_999ACKMap :
        X12LayoutMap<Loop2100_999ACK, X12Entity>
    {
        public Loop2100_999ACKMap()
        {
            Id = "Loop_2100_999_ACK";
            Name = "Error Identification";
            
            Segment(x => x.ErrorIdentification, 0);
            Segment(x => x.SegmentContext, 1);
            Segment(x => x.BusinessUnitIdentifier, 2);
            Layout(x => x.Loop2110, 3);
        }
    }
}